namespace Task4
{
    partial class Server
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
            this.listenBtn = new System.Windows.Forms.Button();
            this.dataLv = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listenBtn
            // 
            this.listenBtn.FlatAppearance.BorderSize = 2;
            this.listenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listenBtn.Font = new System.Drawing.Font("UTM Avo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listenBtn.Location = new System.Drawing.Point(12, 12);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(106, 34);
            this.listenBtn.TabIndex = 0;
            this.listenBtn.Text = "Listen";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.listenBtn_Click);
            // 
            // dataLv
            // 
            this.dataLv.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLv.HideSelection = false;
            this.dataLv.Location = new System.Drawing.Point(12, 52);
            this.dataLv.Name = "dataLv";
            this.dataLv.Size = new System.Drawing.Size(639, 320);
            this.dataLv.TabIndex = 1;
            this.dataLv.UseCompatibleStateImageBehavior = false;
            this.dataLv.View = System.Windows.Forms.View.List;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Task4.Properties.Resources.Task2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(663, 384);
            this.Controls.Add(this.dataLv);
            this.Controls.Add(this.listenBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button listenBtn;
        private System.Windows.Forms.ListView dataLv;
    }
}