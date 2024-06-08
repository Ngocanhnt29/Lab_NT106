using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class tcpserver : Form
    {

        //tạo biến kiểu Thread để chạy một luồng lắng nghe kết nối.
        private Thread listenerThread;
        // Biến kiểu TcpListener để lắng nghe kết nối TCP.
        private TcpListener tcpListener;

        public tcpserver()
        {
            InitializeComponent();
        }

        private void listen_Click(object sender, EventArgs e)
        {
            //Khởi tạo một thread mới để chạy phương thức StartListening
            listenerThread = new Thread(StartListening);
            listenerThread.IsBackground = true; // Để khi đóng form thì thread này cũng tự động đóng
            //bắt đầu lắng nghe kết nối
            listenerThread.Start();
        }

        //phương thức lawnshg nghe kết nối
        private void StartListening()
        {
            // Đặt địa chỉ IP và cổng lắng nghe
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            int port = 8080;

            // Tạo một TcpListener
            tcpListener = new TcpListener(localAddr, port);

            // Bắt đầu lắng nghe kết nối từ client
            tcpListener.Start();
            
            

            try
            {
                while (true)
                {
                    // Chấp nhận kết nối từ client
                    TcpClient client = tcpListener.AcceptTcpClient();
                    
               

                    // Tạo một thread để xử lý dữ liệu từ client
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.IsBackground = true;
                    //Bắt đầu thread xử lý client.
                    clientThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
               MessageBox.Show("SocketException: " + ex.Message);
            }
            finally
            {
                // Dừng lắng nghe khi kết thúc
                tcpListener.Stop();
            }
        }

        //pt xử lí dữ liệu từ client
        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            //Lấy NetworkStream từ client để đọc dữ liệu
            NetworkStream stream = client.GetStream();
            // Khởi tạo buffer để lưu dữ liệu nhận được.
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    // Chuyển đổi dữ liệu nhận được thành chuỗi
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received from client: " + message);
                    
                }
                Console.WriteLine("Client disconnected.");
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Client disconnected.");
                // Đóng kết nối khi xử lý xong
                client.Close();
            }
        }

        private void Lab3_Bai02_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
        }
    }
}
