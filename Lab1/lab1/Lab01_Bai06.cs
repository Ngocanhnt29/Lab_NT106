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
    public partial class Lab01_Bai06 : Form
    {
        public Lab01_Bai06()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a,b;
            a = textBox2.Text.Trim();
            b = textBox3.Text.Trim();

            int x, y;
            if (int.TryParse(a, out x) && (int.TryParse(b, out y)))
            {
                string c = "";
            switch (y)
            {
                case 1:
                   c= ( x  >= 21) ? "Bảo Bình" : "Ma Kết";
                    break;
                case 2:
                   c= ( x  <= 19) ? "Bảo Bình" : "Song Ngư";
                    break;
                case 3:
                   c = ( x  >= 21) ? "Bạch Dương" : "Song Ngư";
                    break;
                case 4:
                   c= ( x <= 20 ) ? "Bạch Dương" : "Kim Ngưu";
                    break;
                case 5:
                    c = (x  <= 21) ? "Kim Ngưu" : "Song Tử";
                    break;
                case 6:
                    c = (x  <= 21) ? "Song Tử" : "Cự Giải";
                    break;
                case 7:
                   c = ( x  <= 22) ? "Cự Giải" : "Sư Tử";
                    break;
                case 8:
                    c = (x  <= 22) ? "Sư Tử" : "Xử Nữ";
                    break;
                case 9:
                    c = (x  <= 23) ? "Xử Nữ" : "Thiên Bình";
                    break;
                case 10:
                    c = (x  <= 23) ? "Thiên Bình" : "Thần Nông";
                    break;
                case 11:
                    c = (x  <= 22) ? "Thần Nông" : "Nhân Mã";
                    break;
                case 12:
                    c= (x  <= 21) ? "Nhân Mã" : "Ma Kết";
                    break;
            }
            textBox1.Text = c;
        }
            else
            { 
                MessageBox.Show("Hãy nhập đúng ngày tháng sinh.");
            }    
            
        }
    }
  }
