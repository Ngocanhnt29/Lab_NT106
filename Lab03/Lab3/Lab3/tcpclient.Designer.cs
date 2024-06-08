namespace Lab3
{
    partial class tcpclient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connect = new System.Windows.Forms.Button();
            this.send = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(560, 60);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(172, 49);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(560, 147);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(172, 49);
            this.send.TabIndex = 1;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(560, 226);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(172, 49);
            this.disconnect.TabIndex = 2;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(48, 60);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(478, 276);
            this.listBox2.TabIndex = 3;
            // 
            // tcpclient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.send);
            this.Controls.Add(this.connect);
            this.Name = "tcpclient";
            this.Text = "tcpclient";
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.Button Connect;
        //private System.Windows.Forms.Button Send;
        //private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.ListBox listBox2;
    }
}