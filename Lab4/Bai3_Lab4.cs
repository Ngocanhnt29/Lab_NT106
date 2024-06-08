using HtmlAgilityPack;
using Lab4_ltmcb;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab4_ltmcb
{
    public partial class Bai3_Lab4 : Form
    {
        public Bai3_Lab4()
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

        private void button2_Click(object sender, EventArgs e)
        {
            var html = getHTML(textBox1.Text);
            Viewsource view = new Viewsource();
            view.Hienthi(html.ToString());
            view.Show();
        }

        private void DownloadImages(List<string> imageUrls, string destinationDirectory)
        {
            foreach (var imageUrl in imageUrls)
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string fileName = imageUrl.Substring(imageUrl.LastIndexOf("/") + 1);
                        string path = Path.Combine(destinationDirectory, fileName);
                        client.DownloadFile(imageUrl, path);
                        MessageBox.Show("Image downloaded successfully at: " + path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error downloading image: " + ex.Message);
                    }
                }
            }
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            webView21.Source = new Uri(url);
        }

        // Sự kiện được kích hoạt khi người dùng nhấn nút button3 để tải hình ảnh
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) // Kiểm tra xem URL có trống không
            {
                MessageBox.Show("Please enter a valid URL."); // Hiển thị thông báo yêu cầu nhập URL hợp lệ
                return;
            }

            HtmlWeb web = new HtmlWeb(); // Tạo một đối tượng HtmlWeb để tải tài liệu HTML
            var htmlDoc = web.Load(textBox1.Text); // Tải tài liệu HTML từ URL

            if (htmlDoc == null) // Kiểm tra xem tài liệu HTML có tải thành công không
            {
                // Hiển thị thông báo lỗi nếu không tải được tài liệu HTML
                MessageBox.Show("Failed to load HTML document."); 
                return;
            }

            var imgs = htmlDoc.DocumentNode.SelectNodes("//img"); // Lấy tất cả các thẻ <img> từ tài liệu HTML
            if (imgs == null) // Kiểm tra xem có thẻ <img> nào không
            {
                // Hiển thị thông báo nếu không có thẻ <img> nào
                MessageBox.Show("No image found in the HTML document."); 
                return;
            }

            List<string> imageUrls = new List<string>(); // Tạo một danh sách để lưu các URL hình ảnh

            foreach (var img in imgs) // Duyệt qua các thẻ <img>
            {
                var imgURL = img.GetAttributeValue("src", ""); // Lấy giá trị thuộc tính "src" của thẻ <img>
                if (!string.IsNullOrEmpty(imgURL)) // Kiểm tra xem giá trị "src" có rỗng không
                {
                    imageUrls.Add(imgURL); // Thêm URL hình ảnh vào danh sách
                }
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog(); // Tạo một hộp thoại chọn thư mục
            DialogResult result = folderBrowserDialog.ShowDialog(); // Hiển thị hộp thoại chọn thư mục
            // Kiểm tra xem người dùng có chọn thư mục và đường dẫn hợp lệ không
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath)) 
            {
                // Gọi phương thức DownloadImages để tải hình ảnh về thư mục được chọn
                DownloadImages(imageUrls, folderBrowserDialog.SelectedPath); 
            }
        }
    }
}
