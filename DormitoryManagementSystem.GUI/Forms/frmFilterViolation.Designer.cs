namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmFilterViolation
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.ComboBox cmbBuilding;
        private System.Windows.Forms.Label lblViolationType;
        private System.Windows.Forms.TextBox txtViolationType;
        private System.Windows.Forms.Label lblReportedByUserID;
        private System.Windows.Forms.ComboBox cmbReportedByUserID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblViolationDate;
        private System.Windows.Forms.DateTimePicker dtpViolationDateFrom;
        private System.Windows.Forms.DateTimePicker dtpViolationDateTo;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Label lblPenaltyFee;
        private System.Windows.Forms.TextBox txtPenaltyFeeFrom;
        private System.Windows.Forms.Label lblPenaltyFeeTo;
        private System.Windows.Forms.TextBox txtPenaltyFeeTo;
        private System.Windows.Forms.Button btnReset;
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
            lblBuilding = new Label();
            cmbBuilding = new ComboBox();
            lblViolationType = new Label();
            txtViolationType = new TextBox();
            lblReportedByUserID = new Label();
            cmbReportedByUserID = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblViolationDate = new Label();
            dtpViolationDateFrom = new DateTimePicker();
            dtpViolationDateTo = new DateTimePicker();
            lblStudentID = new Label();
            txtStudentID = new TextBox();
            lblRoomID = new Label();
            txtRoomID = new TextBox();
            lblPenaltyFee = new Label();
            txtPenaltyFeeFrom = new TextBox();
            lblPenaltyFeeTo = new Label();
            txtPenaltyFeeTo = new TextBox();
            btnReset = new Button();
            btnApply = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(171, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lọc vi phạm";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(20, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(359, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Áp dụng bộ lọc để tìm kiếm vi phạm phù hợp";
            // 
            // lblBuilding
            // 
            lblBuilding.AutoSize = true;
            lblBuilding.Font = new Font("Segoe UI", 11F);
            lblBuilding.Location = new Point(20, 100);
            lblBuilding.Name = "lblBuilding";
            lblBuilding.Size = new Size(78, 25);
            lblBuilding.TabIndex = 2;
            lblBuilding.Text = "Tòa nhà";
            // 
            // cmbBuilding
            // 
            cmbBuilding.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBuilding.Font = new Font("Segoe UI", 10F);
            cmbBuilding.FormattingEnabled = true;
            cmbBuilding.Items.AddRange(new object[] { "Tất cả" });
            cmbBuilding.Location = new Point(20, 125);
            cmbBuilding.Name = "cmbBuilding";
            cmbBuilding.Size = new Size(200, 31);
            cmbBuilding.TabIndex = 3;
            // 
            // lblViolationType
            // 
            lblViolationType.AutoSize = true;
            lblViolationType.Font = new Font("Segoe UI", 11F);
            lblViolationType.Location = new Point(250, 100);
            lblViolationType.Name = "lblViolationType";
            lblViolationType.Size = new Size(119, 25);
            lblViolationType.TabIndex = 4;
            lblViolationType.Text = "Loại vi phạm";
            // 
            // txtViolationType
            // 
            txtViolationType.Font = new Font("Segoe UI", 10F);
            txtViolationType.Location = new Point(250, 125);
            txtViolationType.Name = "txtViolationType";
            txtViolationType.Size = new Size(200, 30);
            txtViolationType.TabIndex = 5;
            // 
            // lblReportedByUserID
            // 
            lblReportedByUserID.AutoSize = true;
            lblReportedByUserID.Font = new Font("Segoe UI", 11F);
            lblReportedByUserID.Location = new Point(20, 180);
            lblReportedByUserID.Name = "lblReportedByUserID";
            lblReportedByUserID.Size = new Size(136, 25);
            lblReportedByUserID.TabIndex = 6;
            lblReportedByUserID.Text = "Người báo cáo";
            // 
            // cmbReportedByUserID
            // 
            cmbReportedByUserID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportedByUserID.Font = new Font("Segoe UI", 10F);
            cmbReportedByUserID.FormattingEnabled = true;
            cmbReportedByUserID.Location = new Point(20, 205);
            cmbReportedByUserID.Name = "cmbReportedByUserID";
            cmbReportedByUserID.Size = new Size(200, 31);
            cmbReportedByUserID.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F);
            lblStatus.Location = new Point(250, 180);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(96, 25);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Trạng thái";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Tất cả", "Chưa xử lý", "Đã xử lý", "Đã thanh toán" });
            cmbStatus.Location = new Point(250, 205);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 31);
            cmbStatus.TabIndex = 9;
            // 
            // lblViolationDate
            // 
            lblViolationDate.AutoSize = true;
            lblViolationDate.Font = new Font("Segoe UI", 11F);
            lblViolationDate.Location = new Point(20, 260);
            lblViolationDate.Name = "lblViolationDate";
            lblViolationDate.Size = new Size(163, 25);
            lblViolationDate.TabIndex = 10;
            lblViolationDate.Text = "Thời gian vi phạm";
            // 
            // dtpViolationDateFrom
            // 
            dtpViolationDateFrom.CustomFormat = "dd/MM/yyyy";
            dtpViolationDateFrom.Font = new Font("Segoe UI", 10F);
            dtpViolationDateFrom.Format = DateTimePickerFormat.Custom;
            dtpViolationDateFrom.Location = new Point(20, 285);
            dtpViolationDateFrom.Name = "dtpViolationDateFrom";
            dtpViolationDateFrom.Size = new Size(114, 30);
            dtpViolationDateFrom.TabIndex = 11;
            dtpViolationDateFrom.Value = new DateTime(2024, 11, 27, 21, 24, 3, 884);
            // 
            // dtpViolationDateTo
            // 
            dtpViolationDateTo.CustomFormat = "dd/MM/yyyy";
            dtpViolationDateTo.Font = new Font("Segoe UI", 10F);
            dtpViolationDateTo.Format = DateTimePickerFormat.Custom;
            dtpViolationDateTo.Location = new Point(157, 285);
            dtpViolationDateTo.Name = "dtpViolationDateTo";
            dtpViolationDateTo.Size = new Size(114, 30);
            dtpViolationDateTo.TabIndex = 12;
            dtpViolationDateTo.Value = new DateTime(2026, 11, 27, 21, 24, 3, 884);
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Font = new Font("Segoe UI", 11F);
            lblStudentID.Location = new Point(480, 100);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(66, 25);
            lblStudentID.TabIndex = 15;
            lblStudentID.Text = "Mã SV";
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 10F);
            txtStudentID.Location = new Point(480, 125);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(200, 30);
            txtStudentID.TabIndex = 16;
            // 
            // lblRoomID
            // 
            lblRoomID.AutoSize = true;
            lblRoomID.Font = new Font("Segoe UI", 11F);
            lblRoomID.Location = new Point(480, 180);
            lblRoomID.Name = "lblRoomID";
            lblRoomID.Size = new Size(99, 25);
            lblRoomID.TabIndex = 17;
            lblRoomID.Text = "Mã phòng";
            // 
            // txtRoomID
            // 
            txtRoomID.Font = new Font("Segoe UI", 10F);
            txtRoomID.Location = new Point(480, 205);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.Size = new Size(200, 30);
            txtRoomID.TabIndex = 18;
            // 
            // lblPenaltyFee
            // 
            lblPenaltyFee.AutoSize = true;
            lblPenaltyFee.Font = new Font("Segoe UI", 11F);
            lblPenaltyFee.Location = new Point(289, 260);
            lblPenaltyFee.Name = "lblPenaltyFee";
            lblPenaltyFee.Size = new Size(82, 25);
            lblPenaltyFee.TabIndex = 19;
            lblPenaltyFee.Text = "Phí phạt";
            // 
            // txtPenaltyFeeFrom
            // 
            txtPenaltyFeeFrom.Font = new Font("Segoe UI", 10F);
            txtPenaltyFeeFrom.Location = new Point(289, 285);
            txtPenaltyFeeFrom.Name = "txtPenaltyFeeFrom";
            txtPenaltyFeeFrom.Size = new Size(161, 30);
            txtPenaltyFeeFrom.TabIndex = 20;
            // 
            // lblPenaltyFeeTo
            // 
            lblPenaltyFeeTo.AutoSize = true;
            lblPenaltyFeeTo.Font = new Font("Segoe UI", 10F);
            lblPenaltyFeeTo.Location = new Point(456, 288);
            lblPenaltyFeeTo.Name = "lblPenaltyFeeTo";
            lblPenaltyFeeTo.Size = new Size(17, 23);
            lblPenaltyFeeTo.TabIndex = 21;
            lblPenaltyFeeTo.Text = "-";
            // 
            // txtPenaltyFeeTo
            // 
            txtPenaltyFeeTo.Font = new Font("Segoe UI", 10F);
            txtPenaltyFeeTo.Location = new Point(480, 285);
            txtPenaltyFeeTo.Name = "txtPenaltyFeeTo";
            txtPenaltyFeeTo.Size = new Size(200, 30);
            txtPenaltyFeeTo.TabIndex = 22;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.White;
            btnReset.FlatAppearance.BorderColor = Color.FromArgb(102, 118, 239);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(102, 118, 239);
            btnReset.Location = new Point(470, 339);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 40);
            btnReset.TabIndex = 23;
            btnReset.Text = "Đặt lại";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.FromArgb(102, 118, 239);
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnApply.ForeColor = Color.White;
            btnApply.Location = new Point(580, 339);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 40);
            btnApply.TabIndex = 24;
            btnApply.Text = "Áp dụng";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(137, 288);
            label1.Name = "label1";
            label1.Size = new Size(17, 23);
            label1.TabIndex = 25;
            label1.Text = "-";
            // 
            // frmFilterViolation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 400);
            Controls.Add(label1);
            Controls.Add(btnApply);
            Controls.Add(btnReset);
            Controls.Add(txtPenaltyFeeTo);
            Controls.Add(lblPenaltyFeeTo);
            Controls.Add(txtPenaltyFeeFrom);
            Controls.Add(lblPenaltyFee);
            Controls.Add(txtRoomID);
            Controls.Add(lblRoomID);
            Controls.Add(txtStudentID);
            Controls.Add(lblStudentID);
            Controls.Add(dtpViolationDateTo);
            Controls.Add(dtpViolationDateFrom);
            Controls.Add(lblViolationDate);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(cmbReportedByUserID);
            Controls.Add(lblReportedByUserID);
            Controls.Add(txtViolationType);
            Controls.Add(lblViolationType);
            Controls.Add(cmbBuilding);
            Controls.Add(lblBuilding);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFilterViolation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lọc vi phạm";
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}
