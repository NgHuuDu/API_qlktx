namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmContractDetail
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblContractID;
        private System.Windows.Forms.TextBox txtContractID;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.ComboBox cmbRoomID;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblStaffUserID;
        private System.Windows.Forms.TextBox txtStaffUserID;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.TextBox txtCreatedDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblContractID = new Label();
            txtContractID = new TextBox();
            lblStudentID = new Label();
            txtStudentID = new TextBox();
            lblStudentName = new Label();
            txtStudentName = new TextBox();
            lblRoomID = new Label();
            cmbRoomID = new ComboBox();
            lblRoomNumber = new Label();
            txtRoomNumber = new TextBox();
            lblStaffUserID = new Label();
            txtStaffUserID = new TextBox();
            lblStartTime = new Label();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            dtpEndTime = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblCreatedDate = new Label();
            txtCreatedDate = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            btnClose = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            btnApply = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblContractID
            // 
            lblContractID.AutoSize = true;
            lblContractID.Font = new Font("Segoe UI", 11F);
            lblContractID.Location = new Point(20, 20);
            lblContractID.Name = "lblContractID";
            lblContractID.Size = new Size(130, 25);
            lblContractID.TabIndex = 0;
            lblContractID.Text = "Mã hợp đồng:";
            // 
            // txtContractID
            // 
            txtContractID.Font = new Font("Segoe UI", 11F);
            txtContractID.Location = new Point(150, 17);
            txtContractID.Name = "txtContractID";
            txtContractID.ReadOnly = true;
            txtContractID.Size = new Size(222, 32);
            txtContractID.TabIndex = 1;
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Font = new Font("Segoe UI", 11F);
            lblStudentID.Location = new Point(20, 60);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(123, 25);
            lblStudentID.TabIndex = 2;
            lblStudentID.Text = "Mã sinh viên:";
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 11F);
            txtStudentID.Location = new Point(150, 57);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.ReadOnly = true;
            txtStudentID.Size = new Size(222, 32);
            txtStudentID.TabIndex = 3;
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Font = new Font("Segoe UI", 11F);
            lblStudentName.Location = new Point(20, 100);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(96, 25);
            lblStudentName.TabIndex = 4;
            lblStudentName.Text = "Họ và tên:";
            // 
            // txtStudentName
            // 
            txtStudentName.Font = new Font("Segoe UI", 11F);
            txtStudentName.Location = new Point(150, 97);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.ReadOnly = true;
            txtStudentName.Size = new Size(222, 32);
            txtStudentName.TabIndex = 5;
            // 
            // lblRoomID
            // 
            lblRoomID.AutoSize = true;
            lblRoomID.Font = new Font("Segoe UI", 11F);
            lblRoomID.Location = new Point(20, 140);
            lblRoomID.Name = "lblRoomID";
            lblRoomID.Size = new Size(71, 25);
            lblRoomID.TabIndex = 6;
            lblRoomID.Text = "Phòng:";
            // 
            // cmbRoomID
            // 
            cmbRoomID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomID.Enabled = false;
            cmbRoomID.Font = new Font("Segoe UI", 11F);
            cmbRoomID.FormattingEnabled = true;
            cmbRoomID.Location = new Point(150, 137);
            cmbRoomID.Name = "cmbRoomID";
            cmbRoomID.Size = new Size(222, 33);
            cmbRoomID.TabIndex = 7;
            cmbRoomID.SelectedIndexChanged += cmbRoomID_SelectedIndexChanged;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 11F);
            lblRoomNumber.Location = new Point(20, 180);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(97, 25);
            lblRoomNumber.TabIndex = 8;
            lblRoomNumber.Text = "Số phòng:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 11F);
            txtRoomNumber.Location = new Point(150, 177);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new Size(222, 32);
            txtRoomNumber.TabIndex = 9;
            // 
            // lblStaffUserID
            // 
            lblStaffUserID.AutoSize = true;
            lblStaffUserID.Font = new Font("Segoe UI", 11F);
            lblStaffUserID.Location = new Point(20, 220);
            lblStaffUserID.Name = "lblStaffUserID";
            lblStaffUserID.Size = new Size(131, 25);
            lblStaffUserID.TabIndex = 10;
            lblStaffUserID.Text = "Mã nhân viên:";
            // 
            // txtStaffUserID
            // 
            txtStaffUserID.Font = new Font("Segoe UI", 11F);
            txtStaffUserID.Location = new Point(150, 217);
            txtStaffUserID.Name = "txtStaffUserID";
            txtStaffUserID.ReadOnly = true;
            txtStaffUserID.Size = new Size(222, 32);
            txtStaffUserID.TabIndex = 11;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Segoe UI", 11F);
            lblStartTime.Location = new Point(20, 260);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(129, 25);
            lblStartTime.TabIndex = 12;
            lblStartTime.Text = "Ngày bắt đầu:";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy";
            dtpStartTime.Enabled = false;
            dtpStartTime.Font = new Font("Segoe UI", 11F);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(150, 257);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(140, 32);
            dtpStartTime.TabIndex = 13;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Segoe UI", 11F);
            lblEndTime.Location = new Point(20, 300);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(132, 25);
            lblEndTime.TabIndex = 14;
            lblEndTime.Text = "Ngày kết thúc:";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy";
            dtpEndTime.Enabled = false;
            dtpEndTime.Font = new Font("Segoe UI", 11F);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(150, 297);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(140, 32);
            dtpEndTime.TabIndex = 15;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F);
            lblStatus.Location = new Point(20, 340);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 25);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "Trạng thái:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Enabled = false;
            cmbStatus.Font = new Font("Segoe UI", 11F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Active", "Expired", "Terminated" });
            cmbStatus.Location = new Point(150, 337);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(222, 33);
            cmbStatus.TabIndex = 17;
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Font = new Font("Segoe UI", 11F);
            lblCreatedDate.Location = new Point(20, 380);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(92, 25);
            lblCreatedDate.TabIndex = 18;
            lblCreatedDate.Text = "Ngày tạo:";
            // 
            // txtCreatedDate
            // 
            txtCreatedDate.Font = new Font("Segoe UI", 11F);
            txtCreatedDate.Location = new Point(150, 377);
            txtCreatedDate.Name = "txtCreatedDate";
            txtCreatedDate.ReadOnly = true;
            txtCreatedDate.Size = new Size(222, 32);
            txtCreatedDate.TabIndex = 19;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 11F);
            lblPrice.Location = new Point(20, 420);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(86, 25);
            lblPrice.TabIndex = 20;
            lblPrice.Text = "Phí thuê:";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 11F);
            txtPrice.Location = new Point(150, 417);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(222, 32);
            txtPrice.TabIndex = 21;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(147, 460);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 22;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(102, 118, 239);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(257, 460);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(115, 40);
            btnEdit.TabIndex = 23;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(147, 460);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.FromArgb(102, 118, 239);
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnApply.ForeColor = Color.White;
            btnApply.Location = new Point(252, 460);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 40);
            btnApply.TabIndex = 25;
            btnApply.Text = "Áp dụng";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Visible = false;
            btnApply.Click += btnApply_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(20, 460);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 40);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // frmContractDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 520);
            Controls.Add(btnDelete);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(btnClose);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(txtCreatedDate);
            Controls.Add(lblCreatedDate);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(dtpEndTime);
            Controls.Add(lblEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(lblStartTime);
            Controls.Add(txtStaffUserID);
            Controls.Add(lblStaffUserID);
            Controls.Add(txtRoomNumber);
            Controls.Add(lblRoomNumber);
            Controls.Add(cmbRoomID);
            Controls.Add(lblRoomID);
            Controls.Add(txtStudentName);
            Controls.Add(lblStudentName);
            Controls.Add(txtStudentID);
            Controls.Add(lblStudentID);
            Controls.Add(txtContractID);
            Controls.Add(lblContractID);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmContractDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết hợp đồng";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

