using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Task4
{
    
    public partial class Server : Form
    {
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        Dictionary<string, seatBuy> room = new Dictionary<string, seatBuy>();       //Lưu dữ liệu các phòng
        Dictionary<string, string> seatBuyed = new Dictionary<string, string>();    //Lưu dữ liệu các ghế đã được mua
        seatBuy[] allRoom; //Lưu dữ liệu tất cả các phòng

        List<Movie> movies;

        List<MovieInfor> shows;

        public Server()
        {
            InitializeComponent();
            server = null;

            string inputJson, outputJson;
            inputJson = File.ReadAllText("input4.json");
            movies = JsonConvert.DeserializeObject<List<Movie>>(inputJson);

            outputJson = File.ReadAllText("output4.json");
            shows = JsonConvert.DeserializeObject<List<MovieInfor>>(outputJson);

            int totalRooms = 0;
            foreach (Movie movie in movies)
                totalRooms += movie.room.Length;
            allRoom = new seatBuy[totalRooms];

            int curRoom = 0;
            foreach (Movie movie in movies)
                for (int i = 0; i < movie.room.Length; i++)
                {
                    room.Add(movie.name + (i + 1).ToString(), allRoom[curRoom] = new seatBuy(movie.standardTicket, movie.name));
                    seatBuyed.Add(movie.name + (i + 1).ToString(), "");
                    curRoom++;
                }
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Close();
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private Dictionary<Socket, bool> initialDataSentMap = new Dictionary<Socket, bool>(); // Lưu trạng thái gửi dữ liệu ban đầu của từng client
        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4444);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);
                        Invoke(new MethodInvoker(delegate {
                            dataLv.Items.Add(new ListViewItem(DateTime.Now.ToString("HH:mm:ss") + ": New client connected!!!"));

                            //Đưa client dữ liệu hiện tại
                            foreach (KeyValuePair<string, string> curSeat in seatBuyed)
                                client.Send(Serialize(curSeat.Key, curSeat.Value));
                        }));

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4444);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            listen.IsBackground = true;
            listen.Start();
            MessageBox.Show("Server đã mở kết nối", "Thông báo", MessageBoxButtons.OK);
        }

        void Receive(Object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while(true)
                {
                    byte[] data = new byte[1024 * 5000];
                    int receivedBytes = client.Receive(data);

                    // Chia chuỗi thành các phần JSON riêng biệt
                    string[] jsonParts = Deserialize(client, data);

                    //Xử lý nhiều dữ liệu được gửi cùng lúc
                    for (int i = 0; i < jsonParts.Length; i++)
                    {
                        //string jsonWithClosingBracket = jsonPart + "}";
                        if (i != 0)
                            jsonParts[i] = "{" + jsonParts[i];
                        if (i != jsonParts.Length - 1)
                            jsonParts[i] = jsonParts[i] + "}";

                        try
                        {
                            MyData receiveData = JsonConvert.DeserializeObject<MyData>(jsonParts[i]);
                            Transaction_Processing(receiveData.roomKey, receiveData.seatPurs);
                        }
                        catch
                        {
                            clientList.Remove(client);
                            client.Close();
                        }
                    }
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }
        byte[] Serialize(string key, string seats)
        {
            MyData myData = new MyData { roomKey = key, seatPurs = seats };
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(myData));
        }

        string[] Deserialize(Socket client, byte[] data)
        {
            foreach (Socket cli in clientList)
            {
                if (cli != client)
                    cli.Send(data);
            }

            // Phân loại dữ liệu dựa trên nội dung hoặc định dạng JSON
            string jsonDataString = Encoding.UTF8.GetString(data);
            //MyData jsonData = JsonConvert.DeserializeObject<MyData>(jsonDataString);

            // Chia chuỗi thành các phần JSON riêng biệt
            string[] jsonParts = jsonDataString.Split(new string[] { "}{" }, StringSplitOptions.RemoveEmptyEntries);
            return jsonParts;
            /*dynamic dataHeaderObject;
            using (MemoryStream ms = new MemoryStream(receive))
            {
                using (StreamReader sr = new StreamReader(ms))
                {
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        dataHeaderObject = serializer.Deserialize<object>(reader);
                    }
                }
            }
            return dataHeaderObject;*/
        }

        //Tính toán và xử lý giao dịch
        private void Transaction_Processing(string key, string seats)
        {
            seatBuyed[key] += seats;
            string[] split = seats.Split(',');
            int totalPrice = 0;
            for (int i = 0; i < split.Length - 1; i++)
            {
                int x = Convert.ToInt32(split[i][0]) - 65;
                int y = Convert.ToInt32(split[i][1]) - 48;
                room[key].set_state(x, y, true);
                totalPrice += room[key].get_price(x, y);
            }

            //Xử lý doanh thu
            foreach (MovieInfor movieIf in shows)
                if (movieIf.name == key.Substring(0, key.Length - 1))
                {
                    movieIf.exitsTicket -= split.Length - 1;
                    movieIf.soldTicket += split.Length - 1;
                    movieIf.percentSold = (((double)movieIf.exitsTicket) / movieIf.soldTicket).ToString() + "%";
                    movieIf.revenue += Convert.ToInt32(totalPrice);
                    break;
                }

            //Cập nhật rank
            int[] rankList = { shows[0].revenue, shows[1].revenue, shows[2].revenue, shows[3].revenue };
            int[] rankIndex = { shows[0].revenue, shows[1].revenue, shows[2].revenue, shows[3].revenue };
            for (int i = 1; i < rankIndex.Length; i++)
            {
                int k = rankIndex[i];
                int j = i - 1;
                while (j >= 0 && rankIndex[j] < k)
                {
                    rankIndex[j + 1] = rankIndex[j];
                    j--;
                }
                rankIndex[j + 1] = k;
            }
            for (int i = 0; i < rankList.Length; i++)
                for (int j = 0; j < rankIndex.Length; j++)
                    if (rankList[i] == rankIndex[j])
                    {
                        shows[i].rank = j + 1;
                        break;
                    }
        }


    }
}
