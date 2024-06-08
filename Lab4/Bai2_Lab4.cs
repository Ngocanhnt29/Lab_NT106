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
    public partial class Bai2_Lab4 : Form
    {
        public Bai2_Lab4()
        {
            InitializeComponent();
        }

        private string getHTML(string szURL)
        {
            WebRequest request = WebRequest.Create(szURL);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            response.Close();
            return responseFromServer;
        }
        private void Bai2_Lab4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var html = getHTML(textBox1.Text);
            richTextBox1.Text = html;
        }

        // Sự kiện được kích hoạt khi người dùng nhấn nút SAVE file
        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo một hộp thoại lưu tệp để người dùng chọn nơi lưu tệp
            SaveFileDialog saveFileDialog = new SaveFileDialog(); 
            saveFileDialog.Filter = "Text file|*.txt"; // Đặt bộ lọc cho hộp thoại chỉ cho phép lưu dưới định dạng tệp văn bản (*.txt)

            // Hiển thị hộp thoại và kiểm tra xem người dùng đã nhấn OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Tạo một đối tượng FileStream để tạo hoặc mở tệp với tên được chọn bởi người dùng
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);

                // Tạo một đối tượng StreamWriter để ghi dữ liệu vào tệp
                StreamWriter streamWriter = new StreamWriter(fileStream);

                // Ghi nội dung của richTextBox1 (nội dung HTML đã được lấy từ trang web) vào tệp
                streamWriter.WriteLine(richTextBox1.Text);

                // Đóng StreamWriter để đảm bảo tất cả dữ liệu đã được ghi vào tệp và giải phóng tài nguyên
                streamWriter.Close();

                // Đóng FileStream để giải phóng tài nguyên
                fileStream.Close();
            }
        }

    }
}
