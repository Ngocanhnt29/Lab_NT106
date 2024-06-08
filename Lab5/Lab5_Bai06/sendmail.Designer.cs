namespace Bai4
{
    partial class sendmail
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
            this.subjectTb = new System.Windows.Forms.TextBox();
            this.toTb = new System.Windows.Forms.TextBox();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.fromTb = new System.Windows.Forms.TextBox();
            this.sendBt = new System.Windows.Forms.Button();
            this.browseBt = new System.Windows.Forms.Button();
            this.pathTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.htmlCb = new System.Windows.Forms.CheckBox();
            this.messageRtb = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // subjectTb
            // 
            this.subjectTb.Location = new System.Drawing.Point(104, 133);
            this.subjectTb.Margin = new System.Windows.Forms.Padding(4);
            this.subjectTb.Name = "subjectTb";
            this.subjectTb.Size = new System.Drawing.Size(484, 22);
            this.subjectTb.TabIndex = 29;
            // 
            // toTb
            // 
            this.toTb.Location = new System.Drawing.Point(104, 94);
            this.toTb.Margin = new System.Windows.Forms.Padding(4);
            this.toTb.Name = "toTb";
            this.toTb.Size = new System.Drawing.Size(484, 22);
            this.toTb.TabIndex = 28;
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(104, 56);
            this.nameTb.Margin = new System.Windows.Forms.Padding(4);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(484, 22);
            this.nameTb.TabIndex = 27;
            // 
            // fromTb
            // 
            this.fromTb.Location = new System.Drawing.Point(104, 13);
            this.fromTb.Margin = new System.Windows.Forms.Padding(4);
            this.fromTb.Name = "fromTb";
            this.fromTb.ReadOnly = true;
            this.fromTb.Size = new System.Drawing.Size(484, 22);
            this.fromTb.TabIndex = 26;
            // 
            // sendBt
            // 
            this.sendBt.Location = new System.Drawing.Point(489, 510);
            this.sendBt.Margin = new System.Windows.Forms.Padding(4);
            this.sendBt.Name = "sendBt";
            this.sendBt.Size = new System.Drawing.Size(100, 28);
            this.sendBt.TabIndex = 25;
            this.sendBt.Text = "Send";
            this.sendBt.UseVisualStyleBackColor = true;
            this.sendBt.Click += new System.EventHandler(this.sendBt_Click);
            // 
            // browseBt
            // 
            this.browseBt.Location = new System.Drawing.Point(490, 461);
            this.browseBt.Margin = new System.Windows.Forms.Padding(4);
            this.browseBt.Name = "browseBt";
            this.browseBt.Size = new System.Drawing.Size(100, 28);
            this.browseBt.TabIndex = 24;
            this.browseBt.Text = "Browse";
            this.browseBt.UseVisualStyleBackColor = true;
            this.browseBt.Click += new System.EventHandler(this.browseBt_Click);
            // 
            // pathTb
            // 
            this.pathTb.Location = new System.Drawing.Point(137, 461);
            this.pathTb.Margin = new System.Windows.Forms.Padding(4);
            this.pathTb.Name = "pathTb";
            this.pathTb.ReadOnly = true;
            this.pathTb.Size = new System.Drawing.Size(328, 22);
            this.pathTb.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 465);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Attachment";
            // 
            // htmlCb
            // 
            this.htmlCb.AutoSize = true;
            this.htmlCb.Location = new System.Drawing.Point(104, 173);
            this.htmlCb.Margin = new System.Windows.Forms.Padding(4);
            this.htmlCb.Name = "htmlCb";
            this.htmlCb.Size = new System.Drawing.Size(66, 20);
            this.htmlCb.TabIndex = 21;
            this.htmlCb.Text = "HTML";
            this.htmlCb.UseVisualStyleBackColor = true;
            // 
            // messageRtb
            // 
            this.messageRtb.Location = new System.Drawing.Point(25, 201);
            this.messageRtb.Margin = new System.Windows.Forms.Padding(4);
            this.messageRtb.Name = "messageRtb";
            this.messageRtb.Size = new System.Drawing.Size(563, 238);
            this.messageRtb.TabIndex = 20;
            this.messageRtb.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Body";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Subject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "From";
            // 
            // sendmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 544);
            this.Controls.Add(this.subjectTb);
            this.Controls.Add(this.toTb);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.fromTb);
            this.Controls.Add(this.sendBt);
            this.Controls.Add(this.browseBt);
            this.Controls.Add(this.pathTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.htmlCb);
            this.Controls.Add(this.messageRtb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "sendmail";
            this.Text = "sendmail";
            this.Load += new System.EventHandler(this.sendmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox subjectTb;
        private System.Windows.Forms.TextBox toTb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.TextBox fromTb;
        private System.Windows.Forms.Button sendBt;
        private System.Windows.Forms.Button browseBt;
        private System.Windows.Forms.TextBox pathTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox htmlCb;
        private System.Windows.Forms.RichTextBox messageRtb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}