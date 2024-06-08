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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab5_Bai01 Bai01 = new Lab5_Bai01();
            Bai01.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai02_03 bai02_03 = new Bai02_03();
            bai02_03.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab5_Bai03 Bai03 = new Lab5_Bai03();
            Bai03.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lab5_Bai04 Bai04 = new Lab5_Bai04();
            Bai04.Show();
        }
    }
}
