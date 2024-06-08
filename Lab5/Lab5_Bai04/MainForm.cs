using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tcpSerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Server sv = new Server();
            sv.ShowDialog();
            this.Close();
        }

        private void openNewCliBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client cl = new Client();
            cl.ShowDialog();
            this.Close();
        }
    }
}
