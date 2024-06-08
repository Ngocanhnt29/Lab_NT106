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
    public partial class Lab01_Bai08 : Form
    {
        public Lab01_Bai08()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string monnew = textBox1.Text;
            if (!string.IsNullOrEmpty(monnew))
            {
                listBox1.Items.Add(monnew);
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >0)
            {
                Random random = new Random();
                int x = random.Next(listBox1.Items.Count);
                string monan = listBox1.Items[x].ToString();
                textBox2.Text = monan.ToString();
            } 
            else
            {
                MessageBox.Show("Hãy nhập thêm món ăn.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
