using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab4_ltmcb
{
    public partial class Bai5_Lab4 : Form
    {
        public Bai5_Lab4()
        {
            InitializeComponent();
        }
        // Tạo một đối tượng HttpClient với địa chỉ cơ bản là "https://nt106.uitiot.vn"
        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://nt106.uitiot.vn")
        };

        // Sự kiện được kích hoạt khi người dùng nhấn nút button1 để đăng nhập
        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Tạo một đối tượng FormUrlEncodedContent để chứa dữ liệu form
            var formData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            // Gửi yêu cầu POST tới "auth/token" với dữ liệu form
            HttpResponseMessage response = await httpClient.PostAsync("auth/token", formData);
            // Sử dụng khối using để đảm bảo response được giải phóng sau khi sử dụng
            using (response)
            {
                if (response.IsSuccessStatusCode) // Kiểm tra xem phản hồi có thành công không
                {
                    //đọc nd phản hồi
                    var res = await response.Content.ReadAsStringAsync();
                    // Phân tích nội dung phản hồi thành đối tượng JSON
                    JObject jsonResponse = JObject.Parse(res);
                    // Kiểm tra xem có trường "access_token" trong phản hồi không
                    if (jsonResponse["access_token"] != null)
                    {
                        // Lấy giá trị "token_type"
                        string tokenType = jsonResponse["token_type"].ToString();
                        // Lấy giá trị "access_token"
                        string accessToken = jsonResponse["access_token"].ToString();

                        richTextBox1.AppendText(tokenType + " " + accessToken + "\n");
                        richTextBox1.AppendText("Đăng nhập thành công\n");
                    }
                }
                else// Xử lý trường hợp phản hồi không thành công
                {
                    // Đọc nội dung phản hồi lỗi
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    // Phân tích nội dung phản hồi lỗi thành đối tượng JSON
                    JObject errorJson = JObject.Parse(errorResponse);
                    // Lấy giá trị "detail" từ phản hồi lỗi
                    string detail = errorJson["detail"].ToString();
                    richTextBox1.AppendText(detail + "\n");
                }
            }
        }
    }
}
