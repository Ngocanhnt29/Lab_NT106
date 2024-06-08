namespace Task4
{
    partial class Client
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
            this.movieCB = new System.Windows.Forms.ComboBox();
            this.roomCB = new System.Windows.Forms.ComboBox();
            this.inforLB = new System.Windows.Forms.Label();
            this.findRoomBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.buyBtn = new System.Windows.Forms.Button();
            this.movieDataLB = new System.Windows.Forms.Label();
            this.filmDataBtn = new System.Windows.Forms.Button();
            this.insertGmail = new System.Windows.Forms.TextBox();
            this.ticketBuy = new System.Windows.Forms.TextBox();
            this.totalPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // movieCB
            // 
            this.movieCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieCB.FormattingEnabled = true;
            this.movieCB.Location = new System.Drawing.Point(12, 54);
            this.movieCB.Name = "movieCB";
            this.movieCB.Size = new System.Drawing.Size(339, 37);
            this.movieCB.TabIndex = 1;
            this.movieCB.SelectedIndexChanged += new System.EventHandler(this.Choose_Film);
            // 
            // roomCB
            // 
            this.roomCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomCB.FormattingEnabled = true;
            this.roomCB.Location = new System.Drawing.Point(12, 153);
            this.roomCB.Name = "roomCB";
            this.roomCB.Size = new System.Drawing.Size(339, 37);
            this.roomCB.TabIndex = 2;
            // 
            // inforLB
            // 
            this.inforLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inforLB.Location = new System.Drawing.Point(41, 287);
            this.inforLB.Name = "inforLB";
            this.inforLB.Size = new System.Drawing.Size(297, 269);
            this.inforLB.TabIndex = 5;
            // 
            // findRoomBtn
            // 
            this.findRoomBtn.BackColor = System.Drawing.Color.Transparent;
            this.findRoomBtn.FlatAppearance.BorderSize = 0;
            this.findRoomBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findRoomBtn.Location = new System.Drawing.Point(185, 210);
            this.findRoomBtn.Name = "findRoomBtn";
            this.findRoomBtn.Size = new System.Drawing.Size(166, 39);
            this.findRoomBtn.TabIndex = 6;
            this.findRoomBtn.UseVisualStyleBackColor = false;
            this.findRoomBtn.Click += new System.EventHandler(this.findRoomBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Location = new System.Drawing.Point(12, 210);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(167, 39);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.BackColor = System.Drawing.Color.Transparent;
            this.delBtn.FlatAppearance.BorderSize = 0;
            this.delBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delBtn.Location = new System.Drawing.Point(381, 204);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(190, 45);
            this.delBtn.TabIndex = 8;
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // buyBtn
            // 
            this.buyBtn.BackColor = System.Drawing.Color.Transparent;
            this.buyBtn.FlatAppearance.BorderSize = 0;
            this.buyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buyBtn.Location = new System.Drawing.Point(577, 207);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(194, 45);
            this.buyBtn.TabIndex = 9;
            this.buyBtn.UseVisualStyleBackColor = false;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // movieDataLB
            // 
            this.movieDataLB.BackColor = System.Drawing.Color.Transparent;
            this.movieDataLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieDataLB.ForeColor = System.Drawing.SystemColors.Control;
            this.movieDataLB.Location = new System.Drawing.Point(834, 54);
            this.movieDataLB.Name = "movieDataLB";
            this.movieDataLB.Size = new System.Drawing.Size(311, 137);
            this.movieDataLB.TabIndex = 14;
            this.movieDataLB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // filmDataBtn
            // 
            this.filmDataBtn.BackColor = System.Drawing.Color.Transparent;
            this.filmDataBtn.FlatAppearance.BorderSize = 0;
            this.filmDataBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filmDataBtn.Location = new System.Drawing.Point(927, 200);
            this.filmDataBtn.Name = "filmDataBtn";
            this.filmDataBtn.Size = new System.Drawing.Size(115, 30);
            this.filmDataBtn.TabIndex = 15;
            this.filmDataBtn.UseVisualStyleBackColor = false;
            this.filmDataBtn.Click += new System.EventHandler(this.filmDataBtn_Click);
            // 
            // insertGmail
            // 
            this.insertGmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.insertGmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertGmail.Location = new System.Drawing.Point(562, 28);
            this.insertGmail.Name = "insertGmail";
            this.insertGmail.Size = new System.Drawing.Size(156, 17);
            this.insertGmail.TabIndex = 18;
            this.insertGmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ticketBuy
            // 
            this.ticketBuy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ticketBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketBuy.Location = new System.Drawing.Point(562, 88);
            this.ticketBuy.Name = "ticketBuy";
            this.ticketBuy.ReadOnly = true;
            this.ticketBuy.Size = new System.Drawing.Size(156, 17);
            this.ticketBuy.TabIndex = 17;
            this.ticketBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalPrice
            // 
            this.totalPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.Location = new System.Drawing.Point(562, 146);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            this.totalPrice.Size = new System.Drawing.Size(156, 17);
            this.totalPrice.TabIndex = 16;
            this.totalPrice.Text = "0";
            this.totalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Task4.Properties.Resources.Task3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1189, 618);
            this.Controls.Add(this.insertGmail);
            this.Controls.Add(this.ticketBuy);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.filmDataBtn);
            this.Controls.Add(this.movieDataLB);
            this.Controls.Add(this.buyBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.findRoomBtn);
            this.Controls.Add(this.inforLB);
            this.Controls.Add(this.roomCB);
            this.Controls.Add(this.movieCB);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox movieCB;
        private System.Windows.Forms.ComboBox roomCB;
        private System.Windows.Forms.Label inforLB;
        private System.Windows.Forms.Button findRoomBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button buyBtn;
        private System.Windows.Forms.Label movieDataLB;
        private System.Windows.Forms.Button filmDataBtn;
        private System.Windows.Forms.TextBox insertGmail;
        private System.Windows.Forms.TextBox ticketBuy;
        private System.Windows.Forms.TextBox totalPrice;
    }
}