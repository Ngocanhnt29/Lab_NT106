using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Lab3
{
    public partial class Lab3_Bai02 : Form
    {
        //tạo biến kiểu Thread để chạy một luồng lắng nghe kết nối.
        private Thread listenerThread;
        // Biến kiểu TcpListener để lắng nghe kết nối TCP.
        private TcpListener tcpListener;
        public Lab3_Bai02()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            //Cập nhật thông tin lên ListBox trên form
            UpdateListBox("Server started, waiting for connection...");

            try
            {
                while (true)
                {
                    // Chấp nhận kết nối từ client
                    TcpClient client = tcpListener.AcceptTcpClient();
                    //Cập nhật thông tin kết nối mới lên ListBox.
                    UpdateListBox("Client connected!");

                    // Tạo một thread để xử lý dữ liệu từ client
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.IsBackground = true;
                    //Bắt đầu thread xử lý client.
                    clientThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
                UpdateListBox("SocketException: " + ex.Message);
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
                    UpdateListBox("Received: " + message);
                }
            }
            catch (Exception ex)
            {
                UpdateListBox("Exception: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối khi xử lý xong
                client.Close();
            }
        }

        // Hàm cập nhật ListBox an toàn luồng
        private void UpdateListBox(string message)
        {
            // Kiểm tra xem liệu việc cập nhật ListBox có cần phải thông qua thread giao diện người dùng hay không.
            if (listBox1.InvokeRequired)
            {
                //Nếu cần, thực hiện cập nhật thông qua thread giao diện người dùng.
                listBox1.Invoke(new Action<string>(UpdateListBox), message);
            }
            else
            {
                //Nếu không cần, trực tiếp cập nhật ListBox
                listBox1.Items.Add(message);
            }
        }

        private void Lab3_Bai02_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

