using MailKit;
using MailKit.Net.Imap;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Lab5_Bai02 : Form
    {
        public Lab5_Bai02()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.Trim();
            string pass = textBox2.Text.Trim(); 

            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate(user, pass);
                    MessageBox.Show("Login successful");

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    listView1.Items.Clear();
                    int recentCount = 0;
                    int totalCount = inbox.Count;
                    label4.Text = $"{totalCount}";

                    for (int i = 0; i < Math.Min(20, inbox.Count); i++)
                    {
                        var message = inbox.GetMessage(i);
                        var item = new ListViewItem(new[] {
                            message.Subject,
                            message.From.ToString(),
                            message.Date.ToString()
                        });
                        listView1.Items.Add(item);
                        if (message.Date >= DateTime.UtcNow.AddDays(-7))
                        {
                            recentCount++;
                        }
                    }

                    label6.Text = $"{recentCount}";

                    client.Disconnect(true);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
    }
}
