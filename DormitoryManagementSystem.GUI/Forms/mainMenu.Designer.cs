namespace DormitoryManagementSystem.GUI.Forms
{
    partial class mainMenu
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
            pnlSidebar = new Panel();
            btnLogout = new Button();
            btnStatistics = new Button();
            btnViolation = new Button();
            btnPayment = new Button();
            btnContract = new Button();
            btnRoom = new Button();
            btnDashboard = new Button();
            pnlUserInfo = new Panel();
            lblUsername = new Label();
            picAvatar = new PictureBox();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(102, 118, 239);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnStatistics);
            pnlSidebar.Controls.Add(btnViolation);
            pnlSidebar.Controls.Add(btnPayment);
            pnlSidebar.Controls.Add(btnContract);
            pnlSidebar.Controls.Add(btnRoom);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(pnlUserInfo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(4, 5, 4, 5);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(333, 1108);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 1031);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(33, 0, 0, 0);
            btnLogout.Size = new Size(333, 77);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.BackColor = Color.Transparent;
            btnStatistics.Cursor = Cursors.Hand;
            btnStatistics.Dock = DockStyle.Top;
            btnStatistics.FlatAppearance.BorderSize = 0;
            btnStatistics.FlatStyle = FlatStyle.Flat;
            btnStatistics.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStatistics.ForeColor = Color.White;
            btnStatistics.Location = new Point(0, 647);
            btnStatistics.Margin = new Padding(4, 5, 4, 5);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Padding = new Padding(33, 0, 0, 0);
            btnStatistics.Size = new Size(333, 77);
            btnStatistics.TabIndex = 6;
            btnStatistics.Text = "Thống kê";
            btnStatistics.TextAlign = ContentAlignment.MiddleLeft;
            btnStatistics.UseVisualStyleBackColor = false;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnViolation
            // 
            btnViolation.BackColor = Color.Transparent;
            btnViolation.Cursor = Cursors.Hand;
            btnViolation.Dock = DockStyle.Top;
            btnViolation.FlatAppearance.BorderSize = 0;
            btnViolation.FlatStyle = FlatStyle.Flat;
            btnViolation.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViolation.ForeColor = Color.White;
            btnViolation.Location = new Point(0, 570);
            btnViolation.Margin = new Padding(4, 5, 4, 5);
            btnViolation.Name = "btnViolation";
            btnViolation.Padding = new Padding(33, 0, 0, 0);
            btnViolation.Size = new Size(333, 77);
            btnViolation.TabIndex = 5;
            btnViolation.Text = "Quản lý Vi phạm";
            btnViolation.TextAlign = ContentAlignment.MiddleLeft;
            btnViolation.UseVisualStyleBackColor = false;
            btnViolation.Click += btnViolation_Click;
            // 
            // btnPayment
            // 
            btnPayment.BackColor = Color.Transparent;
            btnPayment.Cursor = Cursors.Hand;
            btnPayment.Dock = DockStyle.Top;
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPayment.ForeColor = Color.White;
            btnPayment.Location = new Point(0, 493);
            btnPayment.Margin = new Padding(4, 5, 4, 5);
            btnPayment.Name = "btnPayment";
            btnPayment.Padding = new Padding(33, 0, 0, 0);
            btnPayment.Size = new Size(333, 77);
            btnPayment.TabIndex = 4;
            btnPayment.Text = "Quản lý Hóa đơn";
            btnPayment.TextAlign = ContentAlignment.MiddleLeft;
            btnPayment.UseVisualStyleBackColor = false;
            btnPayment.Click += btnPayment_Click;
            // 
            // btnContract
            // 
            btnContract.BackColor = Color.Transparent;
            btnContract.Cursor = Cursors.Hand;
            btnContract.Dock = DockStyle.Top;
            btnContract.FlatAppearance.BorderSize = 0;
            btnContract.FlatStyle = FlatStyle.Flat;
            btnContract.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContract.ForeColor = Color.White;
            btnContract.Location = new Point(0, 416);
            btnContract.Margin = new Padding(4, 5, 4, 5);
            btnContract.Name = "btnContract";
            btnContract.Padding = new Padding(33, 0, 0, 0);
            btnContract.Size = new Size(333, 77);
            btnContract.TabIndex = 3;
            btnContract.Text = "Quản lý Hợp đồng";
            btnContract.TextAlign = ContentAlignment.MiddleLeft;
            btnContract.UseVisualStyleBackColor = false;
            btnContract.Click += btnContract_Click;
            // 
            // btnRoom
            // 
            btnRoom.BackColor = Color.Transparent;
            btnRoom.Cursor = Cursors.Hand;
            btnRoom.Dock = DockStyle.Top;
            btnRoom.FlatAppearance.BorderSize = 0;
            btnRoom.FlatStyle = FlatStyle.Flat;
            btnRoom.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRoom.ForeColor = Color.White;
            btnRoom.Location = new Point(0, 339);
            btnRoom.Margin = new Padding(4, 5, 4, 5);
            btnRoom.Name = "btnRoom";
            btnRoom.Padding = new Padding(33, 0, 0, 0);
            btnRoom.Size = new Size(333, 77);
            btnRoom.TabIndex = 2;
            btnRoom.Text = "Quản lý Phòng";
            btnRoom.TextAlign = ContentAlignment.MiddleLeft;
            btnRoom.UseVisualStyleBackColor = false;
            btnRoom.Click += btnRoom_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(82, 94, 191);
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 262);
            btnDashboard.Margin = new Padding(4, 5, 4, 5);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(33, 0, 0, 0);
            btnDashboard.Size = new Size(333, 77);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.BackColor = Color.FromArgb(102, 118, 239);
            pnlUserInfo.Controls.Add(lblUsername);
            pnlUserInfo.Controls.Add(picAvatar);
            pnlUserInfo.Dock = DockStyle.Top;
            pnlUserInfo.Location = new Point(0, 0);
            pnlUserInfo.Margin = new Padding(4, 5, 4, 5);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(333, 262);
            pnlUserInfo.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(4, 162);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(325, 38);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Admin";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAvatar
            // 
            picAvatar.Image = Properties.Resources.logo;
            picAvatar.Location = new Point(49, 14);
            picAvatar.Margin = new Padding(4, 5, 4, 5);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(227, 143);
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(248, 249, 253);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(333, 0);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(27, 31, 27, 31);
            pnlContent.Size = new Size(1374, 1108);
            pnlContent.TabIndex = 1;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 1200);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1200, 800);
            Name = "mainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Ký túc xá";
            WindowState = FormWindowState.Normal;
            FormClosing += mainMenu_FormClosing;
            Load += mainMenu_Load;
            pnlSidebar.ResumeLayout(false);
            pnlUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnViolation;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox picAvatar;
    }
}