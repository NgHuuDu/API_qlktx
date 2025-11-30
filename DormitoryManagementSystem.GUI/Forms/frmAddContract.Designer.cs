namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmAddContract
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblContractID;
        private System.Windows.Forms.TextBox txtContractID;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblBuildingID;
        private System.Windows.Forms.TextBox txtBuildingID;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                roomIdTimer?.Dispose();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblContractID = new Label();
            txtContractID = new TextBox();
            lblStudentID = new Label();
            txtStudentID = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblBuildingID = new Label();
            txtBuildingID = new TextBox();
            lblRoomNumber = new Label();
            txtRoomNumber = new TextBox();
            lblRoomID = new Label();
            txtRoomID = new TextBox();
            lblStartTime = new Label();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            dtpEndTime = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblContractID
            // 
            lblContractID.AutoSize = true;
            lblContractID.Location = new Point(20, 20);
            lblContractID.Name = "lblContractID";
            lblContractID.Size = new Size(108, 20);
            lblContractID.TabIndex = 0;
            lblContractID.Text = "Mã hợp đồng:*";
            // 
            // txtContractID
            // 
            txtContractID.Location = new Point(165, 17);
            txtContractID.Name = "txtContractID";
            txtContractID.Size = new Size(200, 27);
            txtContractID.TabIndex = 1;
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Location = new Point(20, 60);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(100, 20);
            lblStudentID.TabIndex = 2;
            lblStudentID.Text = "Mã sinh viên:*";
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(165, 57);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(200, 27);
            txtStudentID.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(20, 100);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(82, 20);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên:*";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(165, 97);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(200, 27);
            txtFullName.TabIndex = 5;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(20, 140);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(74, 20);
            lblGender.TabIndex = 6;
            lblGender.Text = "Giới tính:*";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cmbGender.Location = new Point(165, 137);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(200, 28);
            cmbGender.TabIndex = 7;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(20, 180);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(106, 20);
            lblPhoneNumber.TabIndex = 8;
            lblPhoneNumber.Text = "Số điện thoại:*";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(165, 177);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(200, 27);
            txtPhoneNumber.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 220);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(57, 20);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Gmail:*";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(165, 217);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 11;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(20, 260);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(138, 20);
            lblAddress.TabIndex = 12;
            lblAddress.Text = "Địa chỉ thường trú:*";
            // 
            // txtAddress
            // 
            txtAddress.AllowDrop = true;
            txtAddress.Location = new Point(165, 257);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(299, 71);
            txtAddress.TabIndex = 13;
            // 
            // lblBuildingID
            // 
            lblBuildingID.AutoSize = true;
            lblBuildingID.Location = new Point(400, 20);
            lblBuildingID.Name = "lblBuildingID";
            lblBuildingID.Size = new Size(64, 20);
            lblBuildingID.TabIndex = 14;
            lblBuildingID.Text = "Tòa nhà:";
            // 
            // txtBuildingID
            // 
            txtBuildingID.Location = new Point(559, 17);
            txtBuildingID.Name = "txtBuildingID";
            txtBuildingID.ReadOnly = true;
            txtBuildingID.Size = new Size(200, 27);
            txtBuildingID.TabIndex = 15;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Location = new Point(400, 60);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(76, 20);
            lblRoomNumber.TabIndex = 16;
            lblRoomNumber.Text = "Số phòng:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(559, 57);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new Size(200, 27);
            txtRoomNumber.TabIndex = 17;
            // 
            // lblRoomID
            // 
            lblRoomID.AutoSize = true;
            lblRoomID.Location = new Point(400, 100);
            lblRoomID.Name = "lblRoomID";
            lblRoomID.Size = new Size(60, 20);
            lblRoomID.TabIndex = 18;
            lblRoomID.Text = "Phòng:*";
            // 
            // txtRoomID
            // 
            txtRoomID.Location = new Point(559, 97);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.Size = new Size(200, 27);
            txtRoomID.TabIndex = 19;
            txtRoomID.TextChanged += txtRoomID_TextChanged;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(400, 140);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(108, 20);
            lblStartTime.TabIndex = 20;
            lblStartTime.Text = "Ngày bắt đầu:*";
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.CustomFormat = "dd/MM/yyyy";
            dtpStartTime.Location = new Point(559, 137);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(200, 27);
            dtpStartTime.TabIndex = 21;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(400, 180);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(109, 20);
            lblEndTime.TabIndex = 22;
            lblEndTime.Text = "Ngày kết thúc:*";
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.CustomFormat = "dd/MM/yyyy";
            dtpEndTime.Location = new Point(559, 177);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(200, 27);
            dtpEndTime.TabIndex = 23;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(400, 220);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(154, 20);
            lblStatus.TabIndex = 24;
            lblStatus.Text = "Tình trạng hợp đồng:*";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(559, 217);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 28);
            cmbStatus.TabIndex = 25;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(102, 118, 239);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(530, 280);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 26;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(102, 118, 239);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(102, 118, 239);
            btnCancel.Location = new Point(640, 280);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddContract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 340);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(dtpEndTime);
            Controls.Add(lblEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(lblStartTime);
            Controls.Add(txtRoomID);
            Controls.Add(lblRoomID);
            Controls.Add(txtRoomNumber);
            Controls.Add(lblRoomNumber);
            Controls.Add(txtBuildingID);
            Controls.Add(lblBuildingID);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblPhoneNumber);
            Controls.Add(cmbGender);
            Controls.Add(lblGender);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(txtStudentID);
            Controls.Add(lblStudentID);
            Controls.Add(txtContractID);
            Controls.Add(lblContractID);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddContract";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tạo hợp đồng mới";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

