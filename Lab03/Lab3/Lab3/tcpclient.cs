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
    public partial class tcpclient : Form
    {
        public tcpclient()
        {
            InitializeComponent();
        }
        tcpClient client;

        private void send_Click(object sender, EventArgs e)
        {
            string message = listBox2.Text;
            client.Send(message);
            listBox2.Text = "";
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
               client = new tcpClient();
                client.Connect();
                send.Enabled = true;
                connect.Enabled = false;
                disconnect.Enabled = true;
            }
            catch(System.Net.Sockets.SocketException)
            {
                MessageBox.Show("Không thể kết nối server.");
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            send.Enabled = false;
            connect.Enabled = true;
            disconnect.Enabled = false;
        }
    }

   /* class client
    {
        int port = 8080;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        //TcpClient client = new TcpClient();

        public void Connect()
        {
            client.Connect(ip, port);
        }

        public void Disconnect()
        {
            client.Close();
        }

        public void Send( string message)
        {
            byte[] display = System.Text.Encoding.UTF8.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(display, 0, display.Length);
        }
    }*/

   class tcpClient
    {
        int port = 8080;
        IPAddress IP = IPAddress.Parse("127.0.0.1");
        TcpClient client = new TcpClient();

        public void Connect()
        {
            client.Connect(IP, port);
        }
        public void Disconnect()
        {
            client.Close();
        }
        public void Send( string message)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }
    }
}