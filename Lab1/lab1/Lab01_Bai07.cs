using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Lab01_Bai07 : Form
    {
        public Lab01_Bai07()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // kiểm tra chuỗi nhập vào
            string input = textBox1.Text;
            Regex x = new Regex(@"^[\p{L}\s]+\s*,\s*\d+(\.\d+)?(\s*,\s*\d+(\.\d+)?)*$");

            if (!x.IsMatch(input))
            {
                MessageBox.Show("Cú pháp nhập bị sai");
            }
            else
            { MessageBox.Show("Đã nhập đúng format"); }
            // in ra tên
            if (x.IsMatch(input))
            {
                string[] elements = input.Split(',');
                string ten = elements[0].Trim();
                textBox2.Text = ten.ToString();
                // in điểm
                List<double> diem = elements.Skip(1).Select(double.Parse).ToList();
                string danhsachdiem = "";
                for (int i = 0; i < diem.Count; i++)
                {
                    danhsachdiem += $"Môn {i + 1}: {diem[i]}\t ";
                }
                textBox3.Text = danhsachdiem.ToString();
                // điểm trung bình, môn cao nhất, môn thấp nhất
                double dtb = 0;
                double maxd = 0;
                double mind = 0;
                if (diem.Count > 0)
                {
                    dtb = diem.Average();
                    maxd = diem.Max();
                    mind = diem.Min();
                }
                textBox8.Text = dtb.ToString();
                textBox4.Text = maxd.ToString();
                textBox5.Text = mind.ToString();
                //số môn đậu, số môn rớt
                int demdau = 0;
                int demrot = 0;
                foreach (double d in diem)
                {
                    if (d >= 5.0)
                    {
                        demdau++;
                    }
                    else
                    { demrot++; }
                }
                textBox6.Text = demdau.ToString();
                textBox7.Text = demrot.ToString();
                //xep loại
                string xepLoai = "";
                if (dtb >= 8 && diem.All(d => d >= 6.5))
                {
                    xepLoai = "Giỏi";
                }
                else if (dtb >= 6.5 && diem.All(d => d >= 5))
                {
                    xepLoai = "Khá";
                }
                else if ( dtb  >= 5 && diem.All(d => d >= 3.5))
                {
                    xepLoai = "Trung bình";
                }
                else if (dtb >= 3.5 && diem.All(d => d >= 2))
                {
                    xepLoai = "Yếu";
                }
                else
                {
                    xepLoai = "Kém";
                }
                MessageBox.Show($"Xếp loại: {xepLoai}");
            }
            }
        }
    }
