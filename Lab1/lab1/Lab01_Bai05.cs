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
    public partial class Lab01_Bai05 : Form
    {
        public Lab01_Bai05()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Bảng cửu chương");
            comboBox1.Items.Add("Tính toán giá trị");
        }

        private long giaithua(int n)
        {
            if (n == 0)
                return 1;
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a, b;
            a = textBox1.Text.Trim();
            b = textBox2.Text.Trim();

            int x, y;
            if (int.TryParse(a, out x) && int.TryParse(b, out y))
            {
                if(comboBox1.Text == "Bảng cửu chương" )
                {
                    string bangch = "";
                    for (int i = 1; i <= 9; i++)
                    {
                        int hieu = y - x;
                       bangch += $"{hieu} x {i} = {hieu * i}\r\n";
                    }
                    textBox3.Text = bangch;
                }
                else if (comboBox1.Text == "Tính toán giá trị")
                {
                    long kq1 = giaithua(x - y);
                    textBox3.Text = $"(A - B)! = {kq1}\r\n";
                    
                    double kq2 = 0;
                    for (int i = 1; i <= y; i++)
                    {
                        kq2 += Math.Pow(x, i);
                    }
                    textBox3.Text += $"Tổng S = {kq2}";
                }    
            } 
            else
            {
                MessageBox.Show("Hãy nhập 2 số nguyên");
            }    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
