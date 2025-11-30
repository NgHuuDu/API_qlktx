namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmAddViolation
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblViolationID;
        private System.Windows.Forms.TextBox txtViolationID;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.ComboBox cmbRoomID;
        private System.Windows.Forms.Label lblViolationType;
        private System.Windows.Forms.TextBox txtViolationType;
        private System.Windows.Forms.Label lblViolationDate;
        private System.Windows.Forms.DateTimePicker dtpViolationDate;
        private System.Windows.Forms.Label lblReportedByUserID;
        private System.Windows.Forms.ComboBox cmbReportedByUserID;
        private System.Windows.Forms.Label lblDescriptionDetail;
        private System.Windows.Forms.TextBox txtDescriptionDetail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;

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
            lblTitle = new Label();
            lblDescription = new Label();
            lblViolationID = new Label();
            txtViolationID = new TextBox();
            lblStudent = new Label();
            txtStudentID = new TextBox();
            lblRoomID = new Label();
            cmbRoomID = new ComboBox();
            lblViolationType = new Label();
            txtViolationType = new TextBox();
            lblViolationDate = new Label();
            dtpViolationDate = new DateTimePicker();
            lblReportedByUserID = new Label();
            cmbReportedByUserID = new ComboBox();
            lblDescriptionDetail = new Label();
            txtDescriptionDetail = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(232, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tạo vi phạm mới";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(20, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(280, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Ghi nhận vi phạm nội quy ký túc xá";
            // 
            // lblViolationID
            // 
            lblViolationID.AutoSize = true;
            lblViolationID.Font = new Font("Segoe UI", 11F);
            lblViolationID.Location = new Point(20, 100);
            lblViolationID.Name = "lblViolationID";
            lblViolationID.Size = new Size(123, 25);
            lblViolationID.TabIndex = 2;
            lblViolationID.Text = "Mã vi phạm:*";
            // 
            // txtViolationID
            // 
            txtViolationID.Font = new Font("Segoe UI", 10F);
            txtViolationID.Location = new Point(20, 125);
            txtViolationID.Name = "txtViolationID";
            txtViolationID.Size = new Size(400, 30);
            txtViolationID.TabIndex = 3;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Font = new Font("Segoe UI", 11F);
            lblStudent.Location = new Point(20, 170);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(131, 25);
            lblStudent.TabIndex = 4;
            lblStudent.Text = "Mã sinh viên:*";
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 10F);
            txtStudentID.Location = new Point(20, 195);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(400, 30);
            txtStudentID.TabIndex = 5;
            // 
            // lblRoomID
            // 
            lblRoomID.AutoSize = true;
            lblRoomID.Font = new Font("Segoe UI", 11F);
            lblRoomID.Location = new Point(20, 240);
            lblRoomID.Name = "lblRoomID";
            lblRoomID.Size = new Size(100, 25);
            lblRoomID.TabIndex = 6;
            lblRoomID.Text = "Mã phòng:*";
            // 
            // cmbRoomID
            // 
            cmbRoomID.DropDownStyle = ComboBoxStyle.DropDown;
            cmbRoomID.Font = new Font("Segoe UI", 10F);
            cmbRoomID.FormattingEnabled = true;
            cmbRoomID.Location = new Point(20, 265);
            cmbRoomID.Name = "cmbRoomID";
            cmbRoomID.Size = new Size(400, 31);
            cmbRoomID.TabIndex = 7;
            // 
            // lblViolationType
            // 
            lblViolationType.AutoSize = true;
            lblViolationType.Font = new Font("Segoe UI", 11F);
            lblViolationType.Location = new Point(20, 310);
            lblViolationType.Name = "lblViolationType";
            lblViolationType.Size = new Size(131, 25);
            lblViolationType.TabIndex = 6;
            lblViolationType.Text = "Loại vi phạm:*";
            // 
            // txtViolationType
            // 
            txtViolationType.Font = new Font("Segoe UI", 10F);
            txtViolationType.Location = new Point(20, 335);
            txtViolationType.Name = "txtViolationType";
            txtViolationType.Size = new Size(400, 30);
            txtViolationType.TabIndex = 8;
            // 
            // lblViolationDate
            // 
            lblViolationDate.AutoSize = true;
            lblViolationDate.Font = new Font("Segoe UI", 11F);
            lblViolationDate.Location = new Point(20, 380);
            lblViolationDate.Name = "lblViolationDate";
            lblViolationDate.Size = new Size(140, 25);
            lblViolationDate.TabIndex = 10;
            lblViolationDate.Text = "Ngày vi phạm:*";
            // 
            // dtpViolationDate
            // 
            dtpViolationDate.CustomFormat = "dd/MM/yyyy";
            dtpViolationDate.Font = new Font("Segoe UI", 10F);
            dtpViolationDate.Format = DateTimePickerFormat.Custom;
            dtpViolationDate.Location = new Point(20, 405);
            dtpViolationDate.Name = "dtpViolationDate";
            dtpViolationDate.Size = new Size(400, 30);
            dtpViolationDate.TabIndex = 12;
            // 
            // lblReportedByUserID
            // 
            lblReportedByUserID.AutoSize = true;
            lblReportedByUserID.Font = new Font("Segoe UI", 11F);
            lblReportedByUserID.Location = new Point(20, 450);
            lblReportedByUserID.Name = "lblReportedByUserID";
            lblReportedByUserID.Size = new Size(148, 25);
            lblReportedByUserID.TabIndex = 12;
            lblReportedByUserID.Text = "Người báo cáo:*";
            // 
            // cmbReportedByUserID
            // 
            cmbReportedByUserID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportedByUserID.Font = new Font("Segoe UI", 10F);
            cmbReportedByUserID.FormattingEnabled = true;
            cmbReportedByUserID.Location = new Point(20, 475);
            cmbReportedByUserID.Name = "cmbReportedByUserID";
            cmbReportedByUserID.Size = new Size(400, 31);
            cmbReportedByUserID.TabIndex = 14;
            // 
            // lblDescriptionDetail
            // 
            lblDescriptionDetail.AutoSize = true;
            lblDescriptionDetail.Font = new Font("Segoe UI", 11F);
            lblDescriptionDetail.Location = new Point(20, 520);
            lblDescriptionDetail.Name = "lblDescriptionDetail";
            lblDescriptionDetail.Size = new Size(135, 25);
            lblDescriptionDetail.TabIndex = 14;
            lblDescriptionDetail.Text = "Mô tả chi tiết:*";
            // 
            // txtDescriptionDetail
            // 
            txtDescriptionDetail.Font = new Font("Segoe UI", 10F);
            txtDescriptionDetail.Location = new Point(20, 545);
            txtDescriptionDetail.Multiline = true;
            txtDescriptionDetail.Name = "txtDescriptionDetail";
            txtDescriptionDetail.PlaceholderText = "Mô tả chi tiết về vi phạm...";
            txtDescriptionDetail.Size = new Size(400, 100);
            txtDescriptionDetail.TabIndex = 16;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(158, 689);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(102, 118, 239);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(270, 689);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 17;
            btnSave.Text = "Tạo vi phạm";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // frmAddViolation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 744);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtDescriptionDetail);
            Controls.Add(lblDescriptionDetail);
            Controls.Add(cmbReportedByUserID);
            Controls.Add(lblReportedByUserID);
            Controls.Add(dtpViolationDate);
            Controls.Add(lblViolationDate);
            Controls.Add(txtViolationType);
            Controls.Add(lblViolationType);
            Controls.Add(cmbRoomID);
            Controls.Add(lblRoomID);
            Controls.Add(txtStudentID);
            Controls.Add(lblStudent);
            Controls.Add(txtViolationID);
            Controls.Add(lblViolationID);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddViolation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tạo vi phạm mới";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
