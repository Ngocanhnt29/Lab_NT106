using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;

namespace Lab5
{
    public partial class Lab5_Bai01 : Form
    {
        public Lab5_Bai01()
        {
            InitializeComponent();
             
            textBox2.PasswordChar = '*';
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            string from, to, pass, content, subject;
            from = textBox1.Text.Trim();
            to = textBox5.Text.Trim();
            pass = textBox2.Text.Trim();
            subject = textBox3.Text.Trim();
            content = textBox4.Text.Trim();

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Sender Name", from));
                message.To.Add(new MailboxAddress("", to));
                message.Subject = subject;
                message.Body = new TextPart("plain")
                {
                    Text = content
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(from, pass);
                    client.Send(message);
                    client.Disconnect(true);
                }

                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

       
    }
}
