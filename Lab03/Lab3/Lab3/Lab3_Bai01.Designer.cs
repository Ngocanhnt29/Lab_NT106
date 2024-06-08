namespace Lab3
{
    partial class Lab3_Bai01
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
            this.Client = new System.Windows.Forms.Button();
            this.Server = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Client
            // 
            this.Client.Location = new System.Drawing.Point(166, 174);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(172, 49);
            this.Client.TabIndex = 0;
            this.Client.Text = "Client";
            this.Client.UseVisualStyleBackColor = true;
            this.Client.Click += new System.EventHandler(this.Client_Click);
            // 
            // Server
            // 
            this.Server.Location = new System.Drawing.Point(482, 174);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(172, 49);
            this.Server.TabIndex = 1;
            this.Server.Text = "Server";
            this.Server.UseVisualStyleBackColor = true;
            this.Server.Click += new System.EventHandler(this.Server_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(482, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Lab3_Bai01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.Client);
            this.Name = "Lab3_Bai01";
            this.Text = "Lab3_Bai01";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Client;
        private System.Windows.Forms.Button Server;
        private System.Windows.Forms.Button button1;
    }
}