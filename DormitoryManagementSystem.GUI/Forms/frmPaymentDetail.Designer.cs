namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmPaymentDetail
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.TextBox txtPaymentID;
        private System.Windows.Forms.Label lblContractID;
        private System.Windows.Forms.TextBox txtContractID;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblBillMonth;
        private System.Windows.Forms.NumericUpDown numBillMonth;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.NumericUpDown numPaymentAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.NumericUpDown numPaidAmount;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.Label lblDescriptionField;
        private System.Windows.Forms.TextBox txtDescription;
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
            lblPaymentID = new Label();
            txtPaymentID = new TextBox();
            lblContractID = new Label();
            txtContractID = new TextBox();
            lblStudentID = new Label();
            txtStudentID = new TextBox();
            lblStudentName = new Label();
            txtStudentName = new TextBox();
            lblRoom = new Label();
            txtRoom = new TextBox();
            lblBillMonth = new Label();
            numBillMonth = new NumericUpDown();
            lblPaymentAmount = new Label();
            numPaymentAmount = new NumericUpDown();
            lblPaidAmount = new Label();
            numPaidAmount = new NumericUpDown();
            lblPaymentDate = new Label();
            dtpPaymentDate = new DateTimePicker();
            lblPaymentMethod = new Label();
            cmbPaymentMethod = new ComboBox();
            lblPaymentStatus = new Label();
            cmbPaymentStatus = new ComboBox();
            lblDescriptionField = new Label();
            txtDescription = new TextBox();
            btnClose = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            btnApply = new Button();
            ((System.ComponentModel.ISupportInitialize)numBillMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPaidAmount).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(257, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chi tiết thanh toán";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(20, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(305, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Thông tin chi tiết về khoản thanh toán";
            // 
            // lblPaymentID
            // 
            lblPaymentID.AutoSize = true;
            lblPaymentID.Font = new Font("Segoe UI", 11F);
            lblPaymentID.Location = new Point(20, 100);
            lblPaymentID.Name = "lblPaymentID";
            lblPaymentID.Size = new Size(140, 25);
            lblPaymentID.TabIndex = 2;
            lblPaymentID.Text = "Mã thanh toán:";
            // 
            // txtPaymentID
            // 
            txtPaymentID.Font = new Font("Segoe UI", 10F);
            txtPaymentID.Location = new Point(150, 97);
            txtPaymentID.Name = "txtPaymentID";
            txtPaymentID.ReadOnly = true;
            txtPaymentID.Size = new Size(200, 30);
            txtPaymentID.TabIndex = 3;
            // 
            // lblContractID
            // 
            lblContractID.AutoSize = true;
            lblContractID.Font = new Font("Segoe UI", 11F);
            lblContractID.Location = new Point(380, 100);
            lblContractID.Name = "lblContractID";
            lblContractID.Size = new Size(130, 25);
            lblContractID.TabIndex = 4;
            lblContractID.Text = "Mã hợp đồng:";
            // 
            // txtContractID
            // 
            txtContractID.Font = new Font("Segoe UI", 10F);
            txtContractID.Location = new Point(607, 100);
            txtContractID.Name = "txtContractID";
            txtContractID.ReadOnly = true;
            txtContractID.Size = new Size(200, 30);
            txtContractID.TabIndex = 5;
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Font = new Font("Segoe UI", 11F);
            lblStudentID.Location = new Point(20, 140);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(123, 25);
            lblStudentID.TabIndex = 6;
            lblStudentID.Text = "Mã sinh viên:";
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 10F);
            txtStudentID.Location = new Point(150, 137);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.ReadOnly = true;
            txtStudentID.Size = new Size(200, 30);
            txtStudentID.TabIndex = 7;
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Font = new Font("Segoe UI", 11F);
            lblStudentName.Location = new Point(380, 140);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(125, 25);
            lblStudentName.TabIndex = 8;
            lblStudentName.Text = "Tên sinh viên:";
            // 
            // txtStudentName
            // 
            txtStudentName.Font = new Font("Segoe UI", 10F);
            txtStudentName.Location = new Point(607, 140);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.ReadOnly = true;
            txtStudentName.Size = new Size(200, 30);
            txtStudentName.TabIndex = 9;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 11F);
            lblRoom.Location = new Point(20, 180);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(71, 25);
            lblRoom.TabIndex = 10;
            lblRoom.Text = "Phòng:";
            // 
            // txtRoom
            // 
            txtRoom.Font = new Font("Segoe UI", 10F);
            txtRoom.Location = new Point(150, 177);
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            txtRoom.Size = new Size(200, 30);
            txtRoom.TabIndex = 11;
            // 
            // lblBillMonth
            // 
            lblBillMonth.AutoSize = true;
            lblBillMonth.Font = new Font("Segoe UI", 11F);
            lblBillMonth.Location = new Point(380, 180);
            lblBillMonth.Name = "lblBillMonth";
            lblBillMonth.Size = new Size(69, 25);
            lblBillMonth.TabIndex = 12;
            lblBillMonth.Text = "Tháng:";
            // 
            // numBillMonth
            // 
            numBillMonth.Enabled = false;
            numBillMonth.Font = new Font("Segoe UI", 10F);
            numBillMonth.Location = new Point(607, 180);
            numBillMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numBillMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBillMonth.Name = "numBillMonth";
            numBillMonth.Size = new Size(200, 30);
            numBillMonth.TabIndex = 13;
            numBillMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPaymentAmount
            // 
            lblPaymentAmount.AutoSize = true;
            lblPaymentAmount.Font = new Font("Segoe UI", 11F);
            lblPaymentAmount.Location = new Point(20, 220);
            lblPaymentAmount.Name = "lblPaymentAmount";
            lblPaymentAmount.Size = new Size(158, 25);
            lblPaymentAmount.TabIndex = 14;
            lblPaymentAmount.Text = "Số tiền cần đóng:";
            // 
            // numPaymentAmount
            // 
            numPaymentAmount.Enabled = false;
            numPaymentAmount.Font = new Font("Segoe UI", 10F);
            numPaymentAmount.Location = new Point(183, 220);
            numPaymentAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numPaymentAmount.Name = "numPaymentAmount";
            numPaymentAmount.Size = new Size(167, 30);
            numPaymentAmount.TabIndex = 15;
            // 
            // lblPaidAmount
            // 
            lblPaidAmount.AutoSize = true;
            lblPaidAmount.Font = new Font("Segoe UI", 11F);
            lblPaidAmount.Location = new Point(380, 220);
            lblPaidAmount.Name = "lblPaidAmount";
            lblPaidAmount.Size = new Size(149, 25);
            lblPaidAmount.TabIndex = 16;
            lblPaidAmount.Text = "Số tiền đã đóng:";
            // 
            // numPaidAmount
            // 
            numPaidAmount.Enabled = false;
            numPaidAmount.Font = new Font("Segoe UI", 10F);
            numPaidAmount.Location = new Point(607, 220);
            numPaidAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numPaidAmount.Name = "numPaidAmount";
            numPaidAmount.Size = new Size(200, 30);
            numPaidAmount.TabIndex = 17;
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Font = new Font("Segoe UI", 11F);
            lblPaymentDate.Location = new Point(20, 260);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(157, 25);
            lblPaymentDate.TabIndex = 18;
            lblPaymentDate.Text = "Ngày thanh toán:";
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            dtpPaymentDate.Enabled = false;
            dtpPaymentDate.Font = new Font("Segoe UI", 10F);
            dtpPaymentDate.Format = DateTimePickerFormat.Custom;
            dtpPaymentDate.Location = new Point(183, 257);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(167, 30);
            dtpPaymentDate.TabIndex = 19;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 11F);
            lblPaymentMethod.Location = new Point(380, 260);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(221, 25);
            lblPaymentMethod.TabIndex = 20;
            lblPaymentMethod.Text = "Phương thức thanh toán:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Enabled = false;
            cmbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(607, 260);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(200, 31);
            cmbPaymentMethod.TabIndex = 21;
            // 
            // lblPaymentStatus
            // 
            lblPaymentStatus.AutoSize = true;
            lblPaymentStatus.Font = new Font("Segoe UI", 11F);
            lblPaymentStatus.Location = new Point(20, 300);
            lblPaymentStatus.Name = "lblPaymentStatus";
            lblPaymentStatus.Size = new Size(100, 25);
            lblPaymentStatus.TabIndex = 22;
            lblPaymentStatus.Text = "Trạng thái:";
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentStatus.Enabled = false;
            cmbPaymentStatus.Font = new Font("Segoe UI", 10F);
            cmbPaymentStatus.FormattingEnabled = true;
            cmbPaymentStatus.Location = new Point(150, 297);
            cmbPaymentStatus.Name = "cmbPaymentStatus";
            cmbPaymentStatus.Size = new Size(200, 31);
            cmbPaymentStatus.TabIndex = 23;
            // 
            // lblDescriptionField
            // 
            lblDescriptionField.AutoSize = true;
            lblDescriptionField.Font = new Font("Segoe UI", 11F);
            lblDescriptionField.Location = new Point(20, 340);
            lblDescriptionField.Name = "lblDescriptionField";
            lblDescriptionField.Size = new Size(81, 25);
            lblDescriptionField.TabIndex = 24;
            lblDescriptionField.Text = "Ghi chú:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(150, 337);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(657, 100);
            txtDescription.TabIndex = 25;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(102, 118, 239);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(102, 118, 239);
            btnClose.Location = new Point(584, 460);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 26;
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
            btnEdit.Location = new Point(694, 460);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(111, 40);
            btnEdit.TabIndex = 27;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(102, 118, 239);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(102, 118, 239);
            btnCancel.Location = new Point(584, 460);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 28;
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
            btnApply.Location = new Point(694, 460);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 40);
            btnApply.TabIndex = 29;
            btnApply.Text = "Áp dụng";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Visible = false;
            btnApply.Click += btnApply_Click;
            // 
            // frmPaymentDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 512);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(btnClose);
            Controls.Add(txtDescription);
            Controls.Add(lblDescriptionField);
            Controls.Add(cmbPaymentStatus);
            Controls.Add(lblPaymentStatus);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPaymentMethod);
            Controls.Add(dtpPaymentDate);
            Controls.Add(lblPaymentDate);
            Controls.Add(numPaidAmount);
            Controls.Add(lblPaidAmount);
            Controls.Add(numPaymentAmount);
            Controls.Add(lblPaymentAmount);
            Controls.Add(numBillMonth);
            Controls.Add(lblBillMonth);
            Controls.Add(txtRoom);
            Controls.Add(lblRoom);
            Controls.Add(txtStudentName);
            Controls.Add(lblStudentName);
            Controls.Add(txtStudentID);
            Controls.Add(lblStudentID);
            Controls.Add(txtContractID);
            Controls.Add(lblContractID);
            Controls.Add(txtPaymentID);
            Controls.Add(lblPaymentID);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPaymentDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết thanh toán";
            ((System.ComponentModel.ISupportInitialize)numBillMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPaidAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
