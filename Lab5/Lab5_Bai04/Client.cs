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
using MailKit.Net.Smtp;
using MimeKit;

namespace Task4
{
    public partial class Client : Form
    {
        int[] yLocate = { 220, 292, 364 };
        int[] xLocate = { 377, 449, 521, 593, 665 };
        System.Windows.Forms.Button[,] seats = new System.Windows.Forms.Button[3, 5];
        Dictionary<string, seatBuy> room = new Dictionary<string, seatBuy>();
        seatBuy[] allRoom; //Lưu dữ liệu tất cả các phòng

        seatBuy currentRoom;    //Phòng đang hiển thị trên màn hình

        List<Movie> movies;

        List<MovieInfor> shows;

        IPEndPoint IP;
        Socket client = null;

        SmtpClient smtpClient;

        public Client()
        {
            InitializeComponent();
            try
            {
                IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4444);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                client.Connect(IP);
            } catch 
            {
                MessageBox.Show("Server chưa được mở!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error );
                this.Hide();
                MainForm mf = new MainForm();
                mf.ShowDialog();
                this.Close();
            }

            smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465, true);

            string inputJson, outputJson;
            inputJson = File.ReadAllText("input4.json");
            movies = JsonConvert.DeserializeObject<List<Movie>>(inputJson);

            outputJson = File.ReadAllText("output4.json");
            shows = JsonConvert.DeserializeObject<List<MovieInfor>>(outputJson);

            int totalRooms = 0;
            foreach (Movie movie in movies)
            {
                totalRooms += movie.room.Length;
                movieCB.Items.Add(movie.name);  //Lấy tên từng phim
            }
            allRoom = new seatBuy[totalRooms];

            int curRoom = 0;
            foreach (Movie movie in movies)
                for (int i = 0; i < movie.room.Length; i++)
                {
                    room.Add(movie.name + (i + 1).ToString(), allRoom[curRoom] = new seatBuy(movie.standardTicket, movie.name));
                    curRoom++;
                }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
            MessageBox.Show("Đã kết nối với Server", "Thông báo", MessageBoxButtons.OK);
        }

        //Lấy key
        private string Get_Room_Key()
        {
            if (InvokeRequired)
                return (string)Invoke((Func<string>)Get_Room_Key);
            else
            {
                string key = movieCB.Text;
                key += roomCB.Text;
                return key;
            }
        }

        //Hiển thị lại trạng thái của phòng
        private void Reload_Seats()
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)Reload_Seats);
            else
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (currentRoom.get_state(i, j))
                            seats[i, j].BackColor = Color.Gray;
                        else seats[i, j].BackColor = Color.White;
                        if (!seats[i, j].Visible) seats[i, j].Show();
                    }
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                MainForm mf = new MainForm();
                mf.ShowDialog();
                this.Close();
            }
        }

        private void Choose_Film(object sender, EventArgs e)
        {
            string selectedValue = movieCB.Text.ToString();
            int price = 0;

            roomCB.Items.Clear();
            roomCB.Text = "";
            foreach (Movie movie in movies)
                if (string.Compare(movie.name, selectedValue, true) == 0)
                {
                    foreach (int room in movie.room)
                    {
                        roomCB.Items.Add(room);
                    }
                    roomCB.SelectedIndex = -1;
                    price = movie.standardTicket;
                    break;
                }

            inforLB.Text = "Vé VIP: " + (price * 2).ToString() + "\n" +
                           "Vé thường: " + price.ToString() + "\n" +
                           "Vé vớt: " + (price / 4).ToString();
            movieCB.Refresh();
            roomCB.Refresh();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            //Tạo mảng button tương ứng với các chỗ ngồi rồi ẩn đi chờ đến khi phòng được chọn sẽ hiện lên
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 5; j++)
                {
                    //Tạo 15 button tương ứng 15 chỗ ngồi và ẩn đi
                    seats[i, j] = new System.Windows.Forms.Button();
                    seats[i, j].Text = (j + 1).ToString();
                    string nameSeats = "seats[" + i + ", " + j + "]";
                    seats[i, j].Name = nameSeats;
                    seats[i, j].Location = new Point(xLocate[j], yLocate[i]);
                    seats[i, j].Size = new Size(60, 60);
                    seats[i, j].Font = new Font("UTM Avo", 20, FontStyle.Bold);
                    seats[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    seats[i, j].BackColor = Color.White;
                    seats[i, j].FlatStyle = FlatStyle.Flat;
                    seats[i, j].FlatAppearance.BorderSize = 0;
                    Controls.Add(seats[i, j]);
                    seats[i, j].BringToFront();
                    seats[i, j].Hide();
                    seats[i, j].Click += Seats_Clicked;
                }
        }

        private void Seats_Clicked(object sender, EventArgs e)
        {   //Xử lý sự kiện ấn vào 1 chỗ ngồi
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
            string input = clickedButton.Name;  //Lấy nút đã bấm
            int x = Int32.Parse(input[6].ToString());
            int y = Int32.Parse(input[9].ToString());

            if (!currentRoom.get_state(x, y))
            {
                bool duplicate = false;

                if (ticketBuy.Text != "")
                {
                    string[] split = ticketBuy.Text.Split(',');
                    for (int i = 0; i < split.Length - 1; i++)
                        if (x == Convert.ToInt32(split[i][0]) - 65 && y == Convert.ToInt32(split[i][1]) - 48)        //Tránh trường hợp tick 1 ô 2 lần
                            duplicate = true;
                }

                if (!duplicate)
                {
                    ticketBuy.Text += (char)(x + 65) + y.ToString() + ",";
                    if (currentRoom != null)
                    {
                        seats[x, y].BackColor = Color.Orange;
                        int a = Int32.Parse(totalPrice.Text) + currentRoom.get_price(x, y);
                        totalPrice.Text = a.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn phim và phòng chiếu trước khi chọn chỗ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        totalPrice.Text = "";
                        ticketBuy.Text = "";
                    }
                }
            }
            else MessageBox.Show("Chỗ đã được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void findRoomBtn_Click(object sender, EventArgs e)
        {
            if (movieCB.Text != "" && roomCB.Text != "")
            {
                currentRoom = room[Get_Room_Key()];
                Reload_Seats();
            }
            else MessageBox.Show("Hãy chọn phim và phòng chiếu trước khi chọn chỗ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            if (ticketBuy.Text != "" && insertGmail.Text != "")
            {
                string[] split = ticketBuy.Text.Split(',');
                for (int i = 0; i < split.Length - 1; i++)
                {
                    int x = Convert.ToInt32(split[i][0]) - 65;
                    int y = Convert.ToInt32(split[i][1]) - 48;
                    currentRoom.set_state(x, y, true);
                }
                Reload_Seats();
                string infor = "Khách hàng: " + insertGmail.Text 
                    + "\nVé đã chọn: " + ticketBuy.Text 
                    + "\nTên phim: " + movieCB.Text 
                    + "\nPhòng chiếu số: " + roomCB.Text 
                    + "\nThành tiền: " + totalPrice.Text;

                try
                {
                    smtpClient.Authenticate("ngocanhdhkt764@gmail.com", "mnab rmmg znuw wpwj");
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("", "ngocanhdhkt764@gmail.com"));
                    message.To.Add(new MailboxAddress("", insertGmail.Text));
                    message.Subject = "[" + DateTime.Now + "] " + "Mua vé thành công";
                    message.Body = new TextPart("plain")
                    {
                        Text = infor + "\nChúc quý khách xem phim vui vẻ <3"
                    };
                    smtpClient.Send(message);
                    MessageBox.Show(infor, "Chúc quý khách xem phim vui vẻ <3", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Không thể mua vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reload_Seats();
                    return;
                }

                Transaction_Processing(Get_Room_Key(), ticketBuy.Text);
                Reload_Seats();
                client.Send(Serialize(Get_Room_Key(), ticketBuy.Text));

                insertGmail.Clear();
                ticketBuy.Clear();
                totalPrice.Text = "0";
            }
            else MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Tính toán và xử lý giao dịch
        private void Transaction_Processing(string key, string seats)
        {
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

        private void filmDataBtn_Click(object sender, EventArgs e)
        {
            foreach (MovieInfor movie in shows)
                if (movieCB.Text == movie.name)
                {
                    movieDataLB.Text = "Tên phim: " + movie.name + "\nVé đã bán: "
                        + movie.soldTicket + "  Còn lại: " + movie.exitsTicket + "\nTỷ lệ bán: "
                        + movie.percentSold + "\nDoanh thu: " + movie.revenue + "đ\nXếp hạng tại rạp: " + movie.rank;
                    return;
                }
        }

        void Disconnect()
        {
            client.Close();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            insertGmail.Clear();
            ticketBuy.Clear();
            totalPrice.Text = "0";
            if (currentRoom != null)
                Reload_Seats();
        }

        void Receive(Object obj)
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    int receivedBytes = client.Receive(data);

                    // Chia chuỗi thành các phần JSON riêng biệt
                    string[] jsonParts = Deserialize(client);

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
                            if (Get_Room_Key() == receiveData.roomKey)
                                Reload_Seats();                        
                        }
                        catch
                        {
                            Disconnect();
                        }
                    }
                }
            } catch
            {
                Disconnect();
            }
        }

        string[] Deserialize(Socket client)
        {
            byte[] data = new byte[1024 * 5000];
            int receivedBytes = client.Receive(data);

            // Phân loại dữ liệu dựa trên nội dung hoặc định dạng JSON
            string jsonDataString = Encoding.UTF8.GetString(data, 0, receivedBytes);
            //MyData jsonData = JsonConvert.DeserializeObject<MyData>(jsonDataString);

            // Chia chuỗi thành các phần JSON riêng biệt
            string[] jsonParts = jsonDataString.Split(new string[] { "}{" }, StringSplitOptions.RemoveEmptyEntries);
            return jsonParts;
        }

        byte[] Serialize(string key, string seats)
        {
            MyData myData = new MyData { roomKey = key, seatPurs = seats };
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(myData));
        }
    }
}
