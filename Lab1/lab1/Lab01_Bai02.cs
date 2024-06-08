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
    public partial class Lab01_Bai02 : Form
    {
        public Lab01_Bai02()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a, b, c; 
            a = textBox1.Text.Trim();
            b = textBox2.Text.Trim();
            c = textBox3.Text.Trim();

            double num1, num2, num3;
            if (double.TryParse(a, out num1) && double.TryParse(b, out num2) && double.TryParse(c, out num3 )) 
            {
                double max = Math.Max((Math.Max(num1, num2)), num3);
                double min = Math.Min((Math.Min(num1, num2)), num3);

                textBox4.Text = max.ToString();
                textBox5.Text = min.ToString();
            }
            else
            {
                MessageBox.Show("hãy nhập 3 số hợp lệ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
