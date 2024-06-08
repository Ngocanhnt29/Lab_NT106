namespace Bai4
{
    partial class checkmail
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
            this.fromLb = new System.Windows.Forms.Label();
            this.toLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // fromLb
            // 
            this.fromLb.AutoSize = true;
            this.fromLb.Location = new System.Drawing.Point(81, 27);
            this.fromLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fromLb.Name = "fromLb";
            this.fromLb.Size = new System.Drawing.Size(0, 16);
            this.fromLb.TabIndex = 12;
            // 
            // toLb
            // 
            this.toLb.AutoSize = true;
            this.toLb.Location = new System.Drawing.Point(81, 61);
            this.toLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toLb.Name = "toLb";
            this.toLb.Size = new System.Drawing.Size(0, 16);
            this.toLb.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 10;
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(556, 27);
            this.btnReply.Margin = new System.Windows.Forms.Padding(4);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(107, 50);
            this.btnReply.TabIndex = 9;
            this.btnReply.Text = "Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "From";
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(12, 116);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(667, 454);
            this.webView21.TabIndex = 13;
            this.webView21.ZoomFactor = 1D;
            // 
            // checkmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 592);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.fromLb);
            this.Controls.Add(this.toLb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Name = "checkmail";
            this.Text = "checkmail";
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fromLb;
        private System.Windows.Forms.Label toLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}