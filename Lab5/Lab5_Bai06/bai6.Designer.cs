namespace Bai4
{
    partial class bai6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bai6));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.messageLv = new System.Windows.Forms.ListView();
            this.columnNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Datetime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.smtpPortTb = new System.Windows.Forms.TextBox();
            this.smtpTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imapPortTb = new System.Windows.Forms.TextBox();
            this.imapTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshBt = new System.Windows.Forms.Button();
            this.sendBt = new System.Windows.Forms.Button();
            this.LoginBt = new System.Windows.Forms.Button();
            this.passTb = new System.Windows.Forms.TextBox();
            this.userTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Maximum = 10;
            this.progressBar1.Name = "progressBar1";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // messageLv
            // 
            this.messageLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNum,
            this.From,
            this.Subject,
            this.Datetime});
            this.messageLv.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.messageLv, "messageLv");
            this.messageLv.HideSelection = false;
            this.messageLv.MultiSelect = false;
            this.messageLv.Name = "messageLv";
            this.messageLv.UseCompatibleStateImageBehavior = false;
            this.messageLv.View = System.Windows.Forms.View.Details;
            this.messageLv.SelectedIndexChanged += new System.EventHandler(this.messageLv_SelectedIndexChanged);
            // 
            // columnNum
            // 
            resources.ApplyResources(this.columnNum, "columnNum");
            // 
            // From
            // 
            resources.ApplyResources(this.From, "From");
            // 
            // Subject
            // 
            resources.ApplyResources(this.Subject, "Subject");
            // 
            // Datetime
            // 
            resources.ApplyResources(this.Datetime, "Datetime");
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.smtpPortTb);
            this.panel2.Controls.Add(this.smtpTb);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.imapPortTb);
            this.panel2.Controls.Add(this.imapTb);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // smtpPortTb
            // 
            resources.ApplyResources(this.smtpPortTb, "smtpPortTb");
            this.smtpPortTb.Name = "smtpPortTb";
            // 
            // smtpTb
            // 
            resources.ApplyResources(this.smtpTb, "smtpTb");
            this.smtpTb.Name = "smtpTb";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // imapPortTb
            // 
            resources.ApplyResources(this.imapPortTb, "imapPortTb");
            this.imapPortTb.Name = "imapPortTb";
            // 
            // imapTb
            // 
            resources.ApplyResources(this.imapTb, "imapTb");
            this.imapTb.Name = "imapTb";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshBt);
            this.panel1.Controls.Add(this.sendBt);
            this.panel1.Controls.Add(this.LoginBt);
            this.panel1.Controls.Add(this.passTb);
            this.panel1.Controls.Add(this.userTb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // refreshBt
            // 
            this.refreshBt.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.refreshBt, "refreshBt");
            this.refreshBt.Name = "refreshBt";
            this.refreshBt.UseVisualStyleBackColor = false;
            this.refreshBt.Click += new System.EventHandler(this.refreshBt_Click);
            // 
            // sendBt
            // 
            this.sendBt.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.sendBt, "sendBt");
            this.sendBt.Name = "sendBt";
            this.sendBt.UseVisualStyleBackColor = false;
            this.sendBt.Click += new System.EventHandler(this.sendBt_Click);
            // 
            // LoginBt
            // 
            this.LoginBt.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.LoginBt, "LoginBt");
            this.LoginBt.Name = "LoginBt";
            this.LoginBt.UseVisualStyleBackColor = false;
            this.LoginBt.Click += new System.EventHandler(this.LoginBt_Click);
            // 
            // passTb
            // 
            resources.ApplyResources(this.passTb, "passTb");
            this.passTb.Name = "passTb";
            // 
            // userTb
            // 
            resources.ApplyResources(this.userTb, "userTb");
            this.userTb.Name = "userTb";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // bai6
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.messageLv);
            this.Name = "bai6";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView messageLv;
        private System.Windows.Forms.ColumnHeader columnNum;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader Datetime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox smtpPortTb;
        private System.Windows.Forms.TextBox smtpTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox imapPortTb;
        private System.Windows.Forms.TextBox imapTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refreshBt;
        private System.Windows.Forms.Button sendBt;
        private System.Windows.Forms.Button LoginBt;
        private System.Windows.Forms.TextBox passTb;
        private System.Windows.Forms.TextBox userTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

