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
    public partial class Lab3_Bai03 : Form
    {
        public Lab3_Bai03()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcpserver tcpserver = new tcpserver();
            tcpserver.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcpclient tcpclient = new tcpclient();
            tcpclient.Show();
        }
    }
}
