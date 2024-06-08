using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace Lab4_ltmcb
{
    public partial class Bai4_Lab4 : Form
    {
        // URL của trang web đặt vé xem phim
        private readonly string websiteUrl = "https://betacinemas.vn/phim.htm";
        //Danh sách phim
        private List<Movie> movieList = new List<Movie>();

        public Bai4_Lab4()
        {
            InitializeComponent();
            // Cho phép cuộn trong FlowLayoutPanel
            flowLayoutPanel1.AutoScroll = true;
            // Không bọc nội dung trong FlowLayoutPanel
            flowLayoutPanel1.WrapContents = false;
            // Tải danh sách các bộ phim từ trang web
            LoadMovies();
        }

        private void LoadMovies()
        {
            try
            {
                // Tạo đối tượng HtmlWeb để tải tài liệu HTML
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                // Tải tài liệu HTML từ URL
                HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(websiteUrl);
                // Lấy các thẻ <a> chứa tên phim
                var h3Nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='film-info film-xs-info']/h3/a");
                // Lấy các thẻ <img> chứa hình ảnh phim
                var imgNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='pi-img-wrapper']/img[@src]");
                // Kiểm tra xem có cùng số lượng thẻ <a> và <img> không
                if (h3Nodes != null && imgNodes != null && h3Nodes.Count == imgNodes.Count)
                {
                    // Duyệt qua các thẻ <a> và <img> để lấy thông tin phim
                    for (int i = 0; i < h3Nodes.Count; i++)
                    {
                        string tenPhim = h3Nodes[i].InnerText.Trim();//lấy tên phim
                        string imageUrl = imgNodes[i].GetAttributeValue("src", "");//lấy url hình ảnh
                        //lấy link chi tiết phim
                        string link = "https://betacinemas.vn/" + h3Nodes[i].GetAttributeValue("href", "");

                        PictureBox pictureBox = new PictureBox();// Tạo PictureBox để hiển thị hình ảnh
                        pictureBox.Load(imageUrl);//tải hình ảnh từ url
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;// Đặt chế độ hiển thị hình ảnh
                        // Thêm phim vào danh sách và hiển thị trên giao diện
                        AddMovie(tenPhim, imageUrl, link); 
                    }
                }
                else
                {
                    MessageBox.Show("Không có thông tin về các bộ phim hoặc hình ảnh trên trang web.");
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải nội dung HTML từ URL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        // Phương thức để thêm phim vào danh sách và hiển thị trên giao diện
        private void AddMovie(string tenPhim, string imageUrl, string link)
        {
            // Tạo đối tượng ProgressBarWithLabel để hiển thị thông tin phim
            ProgressBarWithLabel progressBarWithLabel = new ProgressBarWithLabel();
            //đặt tên phim
            progressBarWithLabel.SetLabelText(tenPhim);
            //đặt hình ảnh phim
            progressBarWithLabel.SetPictureBox(new PictureBox { ImageLocation = imageUrl, SizeMode = PictureBoxSizeMode.StretchImage });
           //đặt link chi tiết phim
            progressBarWithLabel.SetLabellinkText(link);
            // Đăng ký sự kiện khi nhấn vào ProgressBar
            progressBarWithLabel.ProgressBarClick += ProgressBarWithLabel_Click;
            // Thêm ProgressBarWithLabel vào FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(progressBarWithLabel);

             // Thêm phim vào danh sách phim
            movieList.Add(new Movie { TenPhim = tenPhim, ImageUrl = imageUrl, Link = link });
        }

        // Sự kiện khi nhấn vào ProgressBarWithLabel để hiển thị chi tiết phim
        private void ProgressBarWithLabel_Click(object sender, EventArgs e)
        {
            // Lấy đối tượng ProgressBarWithLabel đã được nhấn
            ProgressBarWithLabel progressBarWithLabel = sender as ProgressBarWithLabel;
            // Lấy link chi tiết phim
            string link = progressBarWithLabel.LinkLabelText;

            // Tìm thông tin phim trong danh sách phim
            Movie movie = movieList.Find(m => m.Link == link);
            if (movie != null)
            {
                // Tạo form chi tiết phim
                MovieDetailsForm movieDetailsForm = new MovieDetailsForm(movie);
                movieDetailsForm.Show();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin chi tiết của bộ phim.");
            }
        }

        // Phương thức để xuất dữ liệu phim ra file JSON
        private void ExportDataToJson(List<Movie> movies)
        {
            // Chuyển danh sách phim thành chuỗi JSON
            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            // Ghi chuỗi JSON vào file movies.json
            System.IO.File.WriteAllText(@"movies.json", json);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    // Lớp Movie để lưu trữ thông tin phim
    public class Movie
    {
        public string TenPhim { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }

    // Lớp MovieDetailsForm để hiển thị chi tiết phim
    public class MovieDetailsForm : Form
    {
        private Movie _movie;
        private WebBrowser _webBrowser;

        // Phương thức khởi tạo của MovieDetailsForm
        public MovieDetailsForm(Movie movie)
        {
            _movie = movie;

        //    InitializeComponent();

            // Set up UI elements
            Text = _movie.TenPhim; // Đặt tiêu đề của form là tên phim

            _webBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill // Đặt WebBrowser chiếm toàn bộ form
            };
            Controls.Add(_webBrowser); // Thêm WebBrowser vào form

            _webBrowser.Navigate(_movie.Link);// Điều hướng đến link chi tiết phim
        }
    }


}
