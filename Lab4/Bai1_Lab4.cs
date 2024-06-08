using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_ltmcb
{
    public partial class Bai1_Lab4 : Form
    {
        public Bai1_Lab4()
        {
            InitializeComponent();
        }
        // Phương thức để lấy nội dung HTML của một URL
        private string getHTML(string szURL)
        {
            WebRequest request = WebRequest.Create(szURL); // Tạo một yêu cầu web tới URL được chỉ định
            
            WebResponse response = request.GetResponse(); // Gửi yêu cầu và nhận phản hồi
            
            Stream dataStream = response.GetResponseStream(); // Lấy luồng dữ liệu từ phản hồi
           
            StreamReader reader = new StreamReader(dataStream); // Tạo một đối tượng StreamReader để đọc dữ liệu
                                                                // từ luồng
            string responseFromServer = reader.ReadToEnd(); // Đọc toàn bộ nội dung phản hồi vào một chuỗi
           
            response.Close(); // Đóng phản hồi để giải phóng tài nguyên
            
            return responseFromServer; // Trả về nội dung HTML từ phản hồi
        }

        // Sự kiện được kích hoạt khi người dùng nhấn nút GET
        private void button1_Click(object sender, EventArgs e)
        {
            var html = getHTML(textBox1.Text); // Gọi phương thức getHTML với URL nhập vào từ textBox1
                                               // và lưu nội dung HTML vào biến html
           
            richTextBox1.Text = html; // Hiển thị nội dung HTML trong richTextBox1
        }
    }
}
