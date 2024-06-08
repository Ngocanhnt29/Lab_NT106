using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Bai02_03 : Form
    {
        public Bai02_03()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab5_Bai02 lab5_Bai02 = new Lab5_Bai02();
            lab5_Bai02.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab5_Bai03 lab5_Bai03 = new Lab5_Bai03();
            lab5_Bai03.Show();
        }
    }
}
