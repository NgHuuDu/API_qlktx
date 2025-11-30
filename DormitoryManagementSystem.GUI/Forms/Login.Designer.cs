namespace DormitoryManagementSystem.GUI.Forms
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
            picLogo = new PictureBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            lblNote = new Label();
            btnSSO = new Button();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.None;
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Properties.Resources.logoOU;
            picLogo.Location = new Point(382, 36);
            picLogo.Margin = new Padding(4, 5, 4, 5);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(299, 218);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(330, 323);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Size = new Size(399, 32);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(330, 415);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.Size = new Size(399, 32);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = Color.FromArgb(102, 118, 239);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(330, 474);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 85);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.None;
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(330, 286);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(141, 25);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.None;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(330, 378);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(95, 25);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Mật khẩu:";
            // 
            // lblNote
            // 
            lblNote.Anchor = AnchorStyles.None;
            lblNote.BackColor = Color.FromArgb(230, 245, 255);
            lblNote.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNote.ForeColor = Color.DimGray;
            lblNote.Location = new Point(330, 575);
            lblNote.Margin = new Padding(4, 0, 4, 0);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(400, 50);
            lblNote.TabIndex = 9;
            lblNote.Text = "Chú ý: SV đăng nhập click vào nút \"Đăng nhập tài\r\nkhoản HCMCOU-SSO\" ở bên dưới";
            lblNote.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSSO
            // 
            btnSSO.Anchor = AnchorStyles.None;
            btnSSO.BackColor = Color.FromArgb(52, 152, 219);
            btnSSO.Cursor = Cursors.Hand;
            btnSSO.FlatAppearance.BorderSize = 0;
            btnSSO.FlatStyle = FlatStyle.Flat;
            btnSSO.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSSO.ForeColor = Color.White;
            btnSSO.Location = new Point(330, 641);
            btnSSO.Margin = new Padding(4, 5, 4, 5);
            btnSSO.Name = "btnSSO";
            btnSSO.Size = new Size(400, 50);
            btnSSO.TabIndex = 4;
            btnSSO.Text = "Đăng nhập tài khoản HCMCOU-SSO";
            btnSSO.UseVisualStyleBackColor = false;
            btnSSO.Click += btnSSO_Click;
            // 
            // Login
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1067, 720);
            Controls.Add(btnSSO);
            Controls.Add(lblNote);
            Controls.Add(picLogo);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnSSO;
    }
}
