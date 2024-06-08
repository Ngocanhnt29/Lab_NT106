using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Lab01 : Form
    {
        public Lab01()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab01_Bai01 Bai1 = new Lab01_Bai01();
            Bai1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab01_Bai02 Bai2 = new Lab01_Bai02();
            Bai2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab01_Bai03 Bai3 = new Lab01_Bai03();
            Bai3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lab01_Bai04 Bai4 = new Lab01_Bai04();
            Bai4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lab01_Bai05 Bai5 = new Lab01_Bai05();
            Bai5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Lab01_Bai06 Bai6 = new Lab01_Bai06();
            Bai6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Lab01_Bai07 Bai7 = new Lab01_Bai07();
            Bai7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Lab01_Bai08 Bai8 = new Lab01_Bai08();
            Bai8.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Lab01_Bai3_1 Bai3_1 = new Lab01_Bai3_1();
            Bai3_1.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
