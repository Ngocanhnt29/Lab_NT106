using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Lab3_Bai01 : Form
    {
        public Lab3_Bai01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Client_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void Server_Click(object sender, EventArgs e)
        {
            Server Server = new Server();
            Server.Show();
        }
    }
}
