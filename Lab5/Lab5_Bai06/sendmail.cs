using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MailKit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Net.Http;
using System.IO;

namespace Bai4
{
    public partial class sendmail : Form
    {
        private SmtpClient client;
        private OpenFileDialog openFileDialog = null;
        private string userMail;
        private string receiverMail = "";

        public sendmail(SmtpClient client, string userMail)
        {
            InitializeComponent();
            this.client = client;
            this.userMail = userMail;
        }

        public sendmail(string userMail, string receiverMail)
        {
            InitializeComponent();
            this.userMail = userMail;
            this.receiverMail = receiverMail;
        }

        private void sendmail_Load(object sender, EventArgs e)
        {
            fromTb.Text = userMail;
            toTb.Text = receiverMail;
            fromTb.Enabled = false;
        }

        private void sendBt_Click(object sender, EventArgs e)
        {
            string from, to, subject,name ;
            from = fromTb.Text.Trim();
            to = toTb.Text.Trim();
            name = nameTb.Text.Trim();
            subject = subjectTb.Text.Trim();
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(name, from));
                message.To.Add(new MailboxAddress("", to));
                message.Subject = subject;

                message.Body = BuildBody(messageRtb.Text, htmlCb.Checked, pathTb.Text);

                client.SendAsync(message);

                pathTb.Text = "";
                subjectTb.Text = "";
                messageRtb.Text = "";

                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private MimeEntity BuildBody(string text, bool isHtml, string filePath)
        {
            var multipart = new Multipart("mixed");

            if (isHtml)
            {
                multipart.Add(new TextPart("html")
                {
                    Text = text
                });
            }
            else
            {
                multipart.Add(new TextPart("plain")
                {
                    Text = text
                });
            }

            if (!string.IsNullOrEmpty(filePath))
            {
                multipart.Add(new MimePart()
                {
                    Content = new MimeContent(File.OpenRead(filePath), ContentEncoding.Default),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(filePath)
                });
            }
            return multipart;
        }
        private void browseBt_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathTb.Text += openFileDialog.FileName;
            }
        }
    }
}
