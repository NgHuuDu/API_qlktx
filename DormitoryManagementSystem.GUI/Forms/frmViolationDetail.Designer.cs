namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmViolationDetail
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblViolationID;
        private System.Windows.Forms.TextBox txtViolationID;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblViolationType;
        private System.Windows.Forms.TextBox txtViolationType;
        private System.Windows.Forms.Label lblViolationDate;
        private System.Windows.Forms.DateTimePicker dtpViolationDate;
        private System.Windows.Forms.Label lblDescriptionDetail;
        private System.Windows.Forms.TextBox txtDescriptionDetail;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblReportedByUserID;
        private System.Windows.Forms.TextBox txtReportedByUserID;
        private System.Windows.Forms.Label lblPenaltyFee;
        private System.Windows.Forms.NumericUpDown numPenaltyFee;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;

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
            lblStudentName = new Label();
            txtStudentName = new TextBox();
            lblStudentID = new Label();
            txtStudentID = new TextBox();
            lblRoom = new Label();
            txtRoom = new TextBox();
            lblViolationType = new Label();
            txtViolationType = new TextBox();
            lblViolationDate = new Label();
            dtpViolationDate = new DateTimePicker();
            lblDescriptionDetail = new Label();
            txtDescriptionDetail = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblReportedByUserID = new Label();
            txtReportedByUserID = new TextBox();
            lblPenaltyFee = new Label();
            numPenaltyFee = new NumericUpDown();
            btnClose = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            btnApply = new Button();
            ((System.ComponentModel.ISupportInitialize)numPenaltyFee).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chi tiết vi phạm";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(20, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(229, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Thông tin chi tiết về vi phạm";
            // 
            // lblViolationID
            // 
            lblViolationID.AutoSize = true;
            lblViolationID.Font = new Font("Segoe UI", 11F);
            lblViolationID.Location = new Point(20, 98);
            lblViolationID.Name = "lblViolationID";
            lblViolationID.Size = new Size(115, 25);
            lblViolationID.TabIndex = 2;
            lblViolationID.Text = "Mã vi phạm:";
            // 
            // txtViolationID
            // 
            txtViolationID.Font = new Font("Segoe UI", 10F);
            txtViolationID.Location = new Point(150, 97);
            txtViolationID.Name = "txtViolationID";
            txtViolationID.ReadOnly = true;
            txtViolationID.Size = new Size(400, 30);
            txtViolationID.TabIndex = 3;
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Font = new Font("Segoe UI", 11F);
            lblStudentName.Location = new Point(20, 138);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(125, 25);
            lblStudentName.TabIndex = 4;
            lblStudentName.Text = "Tên sinh viên:";
            // 
            // txtStudentName
            // 
            txtStudentName.Font = new Font("Segoe UI", 10F);
            txtStudentName.Location = new Point(150, 137);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.ReadOnly = true;
            txtStudentName.Size = new Size(400, 30);
            txtStudentName.TabIndex = 5;
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Font = new Font("Segoe UI", 11F);
            lblStudentID.Location = new Point(20, 180);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(123, 25);
            lblStudentID.TabIndex = 6;
            lblStudentID.Text = "Mã sinh viên:";
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 10F);
            txtStudentID.Location = new Point(150, 179);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.ReadOnly = true;
            txtStudentID.Size = new Size(200, 30);
            txtStudentID.TabIndex = 7;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 11F);
            lblRoom.Location = new Point(380, 180);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(71, 25);
            lblRoom.TabIndex = 8;
            lblRoom.Text = "Phòng:";
            // 
            // txtRoom
            // 
            txtRoom.Font = new Font("Segoe UI", 10F);
            txtRoom.Location = new Point(450, 177);
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            txtRoom.Size = new Size(100, 30);
            txtRoom.TabIndex = 9;
            // 
            // lblViolationType
            // 
            lblViolationType.AutoSize = true;
            lblViolationType.Font = new Font("Segoe UI", 11F);
            lblViolationType.Location = new Point(20, 220);
            lblViolationType.Name = "lblViolationType";
            lblViolationType.Size = new Size(123, 25);
            lblViolationType.TabIndex = 10;
            lblViolationType.Text = "Loại vi phạm:";
            // 
            // txtViolationType
            // 
            txtViolationType.Font = new Font("Segoe UI", 10F);
            txtViolationType.Location = new Point(150, 217);
            txtViolationType.Name = "txtViolationType";
            txtViolationType.ReadOnly = true;
            txtViolationType.Size = new Size(400, 30);
            txtViolationType.TabIndex = 11;
            // 
            // lblViolationDate
            // 
            lblViolationDate.AutoSize = true;
            lblViolationDate.Font = new Font("Segoe UI", 11F);
            lblViolationDate.Location = new Point(20, 259);
            lblViolationDate.Name = "lblViolationDate";
            lblViolationDate.Size = new Size(132, 25);
            lblViolationDate.TabIndex = 14;
            lblViolationDate.Text = "Ngày vi phạm:";
            // 
            // dtpViolationDate
            // 
            dtpViolationDate.CustomFormat = "dd/MM/yyyy";
            dtpViolationDate.Enabled = false;
            dtpViolationDate.Font = new Font("Segoe UI", 10F);
            dtpViolationDate.Format = DateTimePickerFormat.Custom;
            dtpViolationDate.Location = new Point(150, 258);
            dtpViolationDate.Name = "dtpViolationDate";
            dtpViolationDate.Size = new Size(114, 30);
            dtpViolationDate.TabIndex = 15;
            // 
            // lblDescriptionDetail
            // 
            lblDescriptionDetail.AutoSize = true;
            lblDescriptionDetail.Font = new Font("Segoe UI", 11F);
            lblDescriptionDetail.Location = new Point(20, 300);
            lblDescriptionDetail.Name = "lblDescriptionDetail";
            lblDescriptionDetail.Size = new Size(127, 25);
            lblDescriptionDetail.TabIndex = 16;
            lblDescriptionDetail.Text = "Mô tả chi tiết:";
            // 
            // txtDescriptionDetail
            // 
            txtDescriptionDetail.Font = new Font("Segoe UI", 10F);
            txtDescriptionDetail.Location = new Point(150, 297);
            txtDescriptionDetail.Multiline = true;
            txtDescriptionDetail.Name = "txtDescriptionDetail";
            txtDescriptionDetail.ReadOnly = true;
            txtDescriptionDetail.Size = new Size(400, 100);
            txtDescriptionDetail.TabIndex = 17;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F);
            lblStatus.Location = new Point(20, 454);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 25);
            lblStatus.TabIndex = 22;
            lblStatus.Text = "Trạng thái:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Enabled = false;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(150, 453);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 31);
            cmbStatus.TabIndex = 23;
            // 
            // lblReportedByUserID
            // 
            lblReportedByUserID.AutoSize = true;
            lblReportedByUserID.Font = new Font("Segoe UI", 11F);
            lblReportedByUserID.Location = new Point(16, 521);
            lblReportedByUserID.Name = "lblReportedByUserID";
            lblReportedByUserID.Size = new Size(140, 25);
            lblReportedByUserID.TabIndex = 18;
            lblReportedByUserID.Text = "Người báo cáo:";
            // 
            // txtReportedByUserID
            // 
            txtReportedByUserID.Font = new Font("Segoe UI", 10F);
            txtReportedByUserID.Location = new Point(166, 518);
            txtReportedByUserID.Name = "txtReportedByUserID";
            txtReportedByUserID.ReadOnly = true;
            txtReportedByUserID.Size = new Size(120, 30);
            txtReportedByUserID.TabIndex = 19;
            // 
            // lblPenaltyFee
            // 
            lblPenaltyFee.AutoSize = true;
            lblPenaltyFee.Font = new Font("Segoe UI", 11F);
            lblPenaltyFee.Location = new Point(20, 420);
            lblPenaltyFee.Name = "lblPenaltyFee";
            lblPenaltyFee.Size = new Size(86, 25);
            lblPenaltyFee.TabIndex = 20;
            lblPenaltyFee.Text = "Phí phạt:";
            // 
            // numPenaltyFee
            // 
            numPenaltyFee.Enabled = false;
            numPenaltyFee.Font = new Font("Segoe UI", 10F);
            numPenaltyFee.Location = new Point(150, 417);
            numPenaltyFee.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numPenaltyFee.Name = "numPenaltyFee";
            numPenaltyFee.Size = new Size(200, 30);
            numPenaltyFee.TabIndex = 21;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(323, 513);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 24;
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
            btnEdit.Location = new Point(433, 513);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(115, 40);
            btnEdit.TabIndex = 25;
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
            btnCancel.Location = new Point(323, 513);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 26;
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
            btnApply.Location = new Point(433, 513);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 40);
            btnApply.TabIndex = 27;
            btnApply.Text = "Áp dụng";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Visible = false;
            btnApply.Click += btnApply_Click;
            // 
            // frmViolationDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 580);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(btnClose);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(numPenaltyFee);
            Controls.Add(lblPenaltyFee);
            Controls.Add(txtReportedByUserID);
            Controls.Add(lblReportedByUserID);
            Controls.Add(txtDescriptionDetail);
            Controls.Add(lblDescriptionDetail);
            Controls.Add(dtpViolationDate);
            Controls.Add(lblViolationDate);
            Controls.Add(txtViolationType);
            Controls.Add(lblViolationType);
            Controls.Add(txtRoom);
            Controls.Add(lblRoom);
            Controls.Add(txtStudentID);
            Controls.Add(lblStudentID);
            Controls.Add(txtStudentName);
            Controls.Add(lblStudentName);
            Controls.Add(txtViolationID);
            Controls.Add(lblViolationID);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmViolationDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết vi phạm";
            ((System.ComponentModel.ISupportInitialize)numPenaltyFee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
