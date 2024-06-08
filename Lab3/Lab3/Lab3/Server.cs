using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Server : Form
    {
        // Biến udpClient dùng để giao tiếp qua giao thức UDP.
        private UdpClient udpClient;
        // Biến islisten để kiểm tra xem server có đang lắng nghe hay không.
        private bool islisten = false;
        // Danh sách nhanthongdiep để lưu các thông điệp nhận được.
        private List<string> nhanthongdiep = new List<string>();

        public Server()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Nếu server chưa lắng nghe, khởi động việc lắng nghe.
            if (!islisten)
            {
                try
                {
                    // Khởi tạo udpClient để lắng nghe trên cổng 8080.
                    UdpClient udpClient = new UdpClient(8080);
                    islisten = true;

                    // Tạo một luồng riêng để lắng nghe các thông điệp đến
                    Task.Run(() =>
                    {
                        while (islisten)
                        {
                            try
                            {
                                // Tạo một IPEndPoint để nhận dữ liệu từ bất kỳ IP nào.
                                IPEndPoint remoteipendpoint = new IPEndPoint(IPAddress.Any, 0);
                                // Nhận dữ liệu từ client.
                                Byte[] receiveBytes = udpClient.Receive(ref remoteipendpoint);
                                // Chuyển đổi dữ liệu nhận được thành chuỗi.
                                string returnData = Encoding.UTF8.GetString(receiveBytes);
                                // Tạo một chuỗi để hiển thị thông tin địa chỉ IP và thông điệp.
                                string display = remoteipendpoint.Address.ToString() + " : " + returnData;

                                // Thêm thông điệp vào danh sách nhanthongdiep.
                                lock (nhanthongdiep)
                                {
                                    nhanthongdiep.Add(display);
                                }

                            }
                            catch (SocketException)
                            {
                                // Kết thúc vòng lặp khi UdpClient đóng
                                break;
                            }
                        }
                    });
                }
                catch (Exception )
                {
                    MessageBox.Show("lỗi không thể nghe.");
                }
            }
            else
            {
                // Nếu server đã lắng nghe, hiển thị các thông điệp nhận được lên ListView
                lock (nhanthongdiep)
                {
                    foreach (string message in nhanthongdiep)
                    {
                        listBox1.Items.Add(message);
                    }
                    nhanthongdiep.Clear();
                }

                MessageBox.Show("Đã hiển thị các thông điệp nhận được.");
            }
            // Đóng udpClient và dừng việc lắng nghe.
            if (udpClient != null)
            {
                islisten = false;
                udpClient.Close();
            }
        }


    }
}


