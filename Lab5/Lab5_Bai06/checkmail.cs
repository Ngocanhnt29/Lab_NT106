using System;
using System.Linq;
using System.Windows.Forms;
using MimeKit;
using Microsoft.Web.WebView2.WinForms;

namespace Bai4
{
    public partial class checkmail : Form
    {
        private MimeMessage message;
        private WebView2 webView;

        public checkmail(MimeMessage message)
        {
            this.message = message;
            InitializeComponent();
            DisplayEmailContent();
        }
        private async void DisplayEmailContent()
        {
            toLb.Text = "To: " + string.Join(", ", message.To.Mailboxes.Select(m => m.Address));
            fromLb.Text = "From: " + string.Join(", ", message.From.Mailboxes.Select(m => m.Address));
            await webView21.EnsureCoreWebView2Async(null); 
            webView21.NavigateToString(message.HtmlBody);
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            sendmail sm = new sendmail(message.To.ToString(), ((MailboxAddress)message.From.First()).Address);
            sm.Show();
        }
    }
}
