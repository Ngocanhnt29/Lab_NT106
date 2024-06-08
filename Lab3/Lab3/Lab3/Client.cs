using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Lab3
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string diachi;
            string cong;
            string thongdiep;
            diachi = textBox1.Text.Trim();
            cong = textBox2.Text.Trim();
            thongdiep = textBox3.Text.Trim();
            try
            {
                // tạo kết nối udp
                UdpClient udpClient = new UdpClient();
                udpClient.Connect(diachi, int.Parse(cong));

                //mã hóa thông điệp thành utf8
                Byte[] sendBytes = Encoding.UTF8.GetBytes(thongdiep);

                //gửi 
                udpClient.Send(sendBytes, sendBytes.Length);

                MessageBox.Show("Đã gửi đến server.");

                udpClient.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Không kết nối được.");
            }
        }
    }
}
