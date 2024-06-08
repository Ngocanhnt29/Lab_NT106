using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MailKit;

namespace Bai4
{
    public partial class bai6 : Form
    {
        private ImapClient imapClient;
        private SmtpClient smtpClient;

        public bai6()
        {
            InitializeComponent();
        }

        private async void LoginBt_Click(object sender, EventArgs e)
        {
            string username = userTb.Text.Trim();
            string password = passTb.Text.Trim();
            await LoginAsync(username, password);
        }

        private async Task LoginAsync(string email, string password)
        {
            try
            {
                string imap = imapTb.Text.Trim();
                int imapPort = int.Parse(imapPortTb.Text.Trim());
                string smtp = smtpTb.Text.Trim();
                int smtpPort = int.Parse(smtpPortTb.Text.Trim());

                imapClient = new ImapClient();
                await imapClient.ConnectAsync(imap, imapPort, SecureSocketOptions.SslOnConnect);
                await imapClient.AuthenticateAsync(email, password);

                smtpClient = new SmtpClient();
                await smtpClient.ConnectAsync(smtp, smtpPort, SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(email, password);

                refreshBt.Visible = true;
                sendBt.Visible = true;

                await LoadEmailsAsync();
                MessageBox.Show("Logged in successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
            }
        }

        private async Task LoadEmailsAsync()
        {
            var inbox = imapClient.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadOnly);
            messageLv.Items.Clear();

            int totalMessages = inbox.Count;

            int fetchCount = Math.Min(100, totalMessages);

            var allMessages = await inbox.FetchAsync(totalMessages - fetchCount, -1, MessageSummaryItems.Envelope | MessageSummaryItems.UniqueId);
            var sortedMessages = allMessages.OrderByDescending(m => m.Envelope.Date).ToList();

            this.Invoke((MethodInvoker)delegate
            {
                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = sortedMessages.Count;
            });

            int number = 0;

            foreach (var message in sortedMessages)
            {
                number++;
                var item = new ListViewItem(new[]
                {
                    number.ToString(),
                    message.Envelope.From.ToString(),
                    message.Envelope.Subject,
                    message.Envelope.Date?.ToString()
                });
                item.Tag = message.UniqueId;
                messageLv.Items.Add(item);

                this.Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = number;
                });
            }
            this.Invoke((MethodInvoker)delegate
            {
                progressBar1.Visible = false;
            });

            if (sortedMessages.Count == 0)
            {
                MessageBox.Show("No emails found.");
            }
        }

        private async void messageLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (messageLv.SelectedItems.Count > 0 && imapClient != null)
            {
                var uniqueId = (UniqueId)messageLv.SelectedItems[0].Tag;
                var message = await imapClient.Inbox.GetMessageAsync(uniqueId);
                checkmail cm = new checkmail(message);
                cm.Show();
            }
        }

        private void sendBt_Click(object sender, EventArgs e)
        {
              sendmail sm = new sendmail(smtpClient,userTb.Text.Trim());
              sm.Show();
        }

        private async void refreshBt_Click(object sender, EventArgs e)
        {
            if (imapClient != null && imapClient.IsConnected)
            {
                await LoadEmailsAsync();
                MessageBox.Show("All readldy update!");
            }
        }
    }
}
