namespace Task4
{
    partial class MainForm
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
            this.tcpSerBtn = new System.Windows.Forms.Button();
            this.openNewCliBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tcpSerBtn
            // 
            this.tcpSerBtn.BackColor = System.Drawing.Color.LightGreen;
            this.tcpSerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcpSerBtn.Location = new System.Drawing.Point(69, 41);
            this.tcpSerBtn.Name = "tcpSerBtn";
            this.tcpSerBtn.Size = new System.Drawing.Size(269, 41);
            this.tcpSerBtn.TabIndex = 0;
            this.tcpSerBtn.Text = "Open TCP Server";
            this.tcpSerBtn.UseVisualStyleBackColor = false;
            this.tcpSerBtn.Click += new System.EventHandler(this.tcpSerBtn_Click);
            // 
            // openNewCliBtn
            // 
            this.openNewCliBtn.BackColor = System.Drawing.Color.LightGreen;
            this.openNewCliBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openNewCliBtn.Location = new System.Drawing.Point(69, 99);
            this.openNewCliBtn.Name = "openNewCliBtn";
            this.openNewCliBtn.Size = new System.Drawing.Size(269, 41);
            this.openNewCliBtn.TabIndex = 1;
            this.openNewCliBtn.Text = "Open new TCP client";
            this.openNewCliBtn.UseVisualStyleBackColor = false;
            this.openNewCliBtn.Click += new System.EventHandler(this.openNewCliBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(412, 193);
            this.Controls.Add(this.openNewCliBtn);
            this.Controls.Add(this.tcpSerBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tcpSerBtn;
        private System.Windows.Forms.Button openNewCliBtn;
    }
}

