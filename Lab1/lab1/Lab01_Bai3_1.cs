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
    public partial class Lab01_Bai3_1 : Form
    {
        public Lab01_Bai3_1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ConvertNumberToWords(long num)
        {
            if (num == 0)
                return "Không";

            string[] a = { "", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string[] b = { "", "Nghìn", "Triệu", "Tỷ" };

            StringBuilder words = new StringBuilder();
            int i = 0;

            while (num > 0)
            {
                int elements = (int)(num % 1000);
                if (elements > 0)
                {
                    string elementWords = ConvertThreeDigitsToWords(elements);
                    words.Insert(0, elementWords + " " + b[i] + ", ");
                }

                num /= 1000;
                i++;
            }

            return words.ToString().TrimEnd(' ', ',');
        }

        private string ConvertThreeDigitsToWords(int num)
        {
            string[] a = { "", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string[] c = { "Mười", "Mười một", "Mười hai", "Mười ba", "Mười bốn", "Mười lăm", "Mười sáu", "Mười bảy", "Mười tám", "Mười chín" };

            StringBuilder words = new StringBuilder();

            int hundreds = num / 100;
            if (hundreds > 0)
            {
                words.Append(a[hundreds] + " Trăm ");
                num %= 100;
            }

            int tens = num / 10;
            if (tens > 1)
            {
                words.Append(a[tens] + " Mươi ");
                num %= 10;
            }
            else if (tens == 1)
            {
                words.Append(c[num % 10] + " ");
                return words.ToString();
            }

            if (num > 0)
            {
                words.Append(a[num] + " ");
            }

            return words.ToString();
        }

    private void button1_Click(object sender, EventArgs e)
        {
            string input;
            input = textBox1.Text.Trim();
            long  a;
            if (long.TryParse(input, out a))
            {
                string kq  = ConvertNumberToWords(a);
                textBox2.Text = kq.ToString();
            } 
            else { MessageBox.Show("Hãy nhập dãy gồm 12 số."); }
                
           
        }

        
    }
}
