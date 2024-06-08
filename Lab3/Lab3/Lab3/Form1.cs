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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Bai1_Click(object sender, EventArgs e)
        {
           Lab3_Bai01 Bai01 = new Lab3_Bai01();
            Bai01.Show();
        }

        private void bai2_Click(object sender, EventArgs e)
        {
            Lab3_Bai02 Bai02 = new Lab3_Bai02();
            Bai02.Show();
        }

        private void bai3_Click(object sender, EventArgs e)
        {
            Lab3_Bai03 Bai03 = new Lab3_Bai03();
            Bai03.Show();
        }

        private void bai4_Click(object sender, EventArgs e)
        {
            Lab3_Bai04 Bai04 = new Lab3_Bai04();
            Bai04.Show();
        }

        private void bai5_Click(object sender, EventArgs e)
        {
            Lab3_Bai05 Bai05 = new Lab3_Bai05();
            Bai05.Show();
        }

        private void bai6_Click(object sender, EventArgs e)
        {
            Lab3_Bai06 Bai06 = new Lab3_Bai06();
            Bai06.Show();
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
