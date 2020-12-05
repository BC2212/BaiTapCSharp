namespace ThongTinSV
{
    partial class Login
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
            this.lblTitleQLSV = new System.Windows.Forms.Label();
            this.txtLoginTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtloginMatKhau = new System.Windows.Forms.TextBox();
            this.lblLoginTaiKhoan = new System.Windows.Forms.Label();
            this.lblLoginMatKhau = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTaoTaiKhoan = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblTitleQLSV
            // 
            this.lblTitleQLSV.AutoSize = true;
            this.lblTitleQLSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleQLSV.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTitleQLSV.Location = new System.Drawing.Point(100, 20);
            this.lblTitleQLSV.Name = "lblTitleQLSV";
            this.lblTitleQLSV.Size = new System.Drawing.Size(195, 25);
            this.lblTitleQLSV.TabIndex = 0;
            this.lblTitleQLSV.Text = "Quản lý sinh viên";
            this.lblTitleQLSV.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitleQLSV.Click += new System.EventHandler(this.lblTitleQLSV_Click);
            // 
            // txtLoginTaiKhoan
            // 
            this.txtLoginTaiKhoan.BackColor = System.Drawing.SystemColors.Window;
            this.txtLoginTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginTaiKhoan.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtLoginTaiKhoan.Location = new System.Drawing.Point(150, 80);
            this.txtLoginTaiKhoan.Multiline = true;
            this.txtLoginTaiKhoan.Name = "txtLoginTaiKhoan";
            this.txtLoginTaiKhoan.Size = new System.Drawing.Size(200, 40);
            this.txtLoginTaiKhoan.TabIndex = 1;
            // 
            // txtloginMatKhau
            // 
            this.txtloginMatKhau.BackColor = System.Drawing.SystemColors.Window;
            this.txtloginMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtloginMatKhau.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtloginMatKhau.Location = new System.Drawing.Point(150, 129);
            this.txtloginMatKhau.Multiline = true;
            this.txtloginMatKhau.Name = "txtloginMatKhau";
            this.txtloginMatKhau.PasswordChar = '*';
            this.txtloginMatKhau.Size = new System.Drawing.Size(200, 40);
            this.txtloginMatKhau.TabIndex = 2;
            this.txtloginMatKhau.TextChanged += new System.EventHandler(this.tbloginMatKhau_TextChanged);
            // 
            // lblLoginTaiKhoan
            // 
            this.lblLoginTaiKhoan.AutoSize = true;
            this.lblLoginTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTaiKhoan.Location = new System.Drawing.Point(50, 83);
            this.lblLoginTaiKhoan.Name = "lblLoginTaiKhoan";
            this.lblLoginTaiKhoan.Size = new System.Drawing.Size(87, 20);
            this.lblLoginTaiKhoan.TabIndex = 3;
            this.lblLoginTaiKhoan.Text = "Tài khoản";
            // 
            // lblLoginMatKhau
            // 
            this.lblLoginMatKhau.AutoSize = true;
            this.lblLoginMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginMatKhau.Location = new System.Drawing.Point(50, 132);
            this.lblLoginMatKhau.Name = "lblLoginMatKhau";
            this.lblLoginMatKhau.Size = new System.Drawing.Size(83, 20);
            this.lblLoginMatKhau.TabIndex = 4;
            this.lblLoginMatKhau.Text = "Mật khẩu";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogin.Location = new System.Drawing.Point(50, 183);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(300, 50);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(264, 236);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkLabel1.Size = new System.Drawing.Size(86, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên mật khẩu?";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThoat.Location = new System.Drawing.Point(297, 405);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 44);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // lblTaoTaiKhoan
            // 
            this.lblTaoTaiKhoan.AutoSize = true;
            this.lblTaoTaiKhoan.Location = new System.Drawing.Point(54, 236);
            this.lblTaoTaiKhoan.Name = "lblTaoTaiKhoan";
            this.lblTaoTaiKhoan.Size = new System.Drawing.Size(73, 13);
            this.lblTaoTaiKhoan.TabIndex = 8;
            this.lblTaoTaiKhoan.TabStop = true;
            this.lblTaoTaiKhoan.Text = "Tạo tài khoản";
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.lblTaoTaiKhoan);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblLoginMatKhau);
            this.Controls.Add(this.lblLoginTaiKhoan);
            this.Controls.Add(this.txtloginMatKhau);
            this.Controls.Add(this.txtLoginTaiKhoan);
            this.Controls.Add(this.lblTitleQLSV);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.SignIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleQLSV;
        private System.Windows.Forms.TextBox txtLoginTaiKhoan;
        private System.Windows.Forms.TextBox txtloginMatKhau;
        private System.Windows.Forms.Label lblLoginTaiKhoan;
        private System.Windows.Forms.Label lblLoginMatKhau;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.LinkLabel lblTaoTaiKhoan;
    }
}