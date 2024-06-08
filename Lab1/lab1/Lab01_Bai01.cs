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
    public partial class Lab01_Bai01 : Form
    {
        public Lab01_Bai01()
        {
            InitializeComponent();
        }

        private void Lab01_Bai01_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a, b;
            a = textBox1.Text.Trim();
            b = textBox2.Text.Trim();

            int num1, num2;
            if (int.TryParse(a, out num1) && int.TryParse(b, out num2))
            {
                long sum = 0;
                sum = num1 + num2;
                textBox3.Text = sum.ToString();
            }
            else
            {
                MessageBox.Show("Hãy nhập số nguyên");
            }
        }
    }
}
