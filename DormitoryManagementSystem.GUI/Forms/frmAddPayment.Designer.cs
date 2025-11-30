namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmAddPayment
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.TextBox txtPaymentID;
        private System.Windows.Forms.Label lblContractID;
        private System.Windows.Forms.ComboBox cmbContractID;
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
        private System.Windows.Forms.TextBox txtDescription;
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
            lblPaymentID = new Label();
            txtPaymentID = new TextBox();
            lblContractID = new Label();
            cmbContractID = new ComboBox();
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
            txtDescription = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            txtGhiChu = new Label();
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
            lblTitle.Size = new Size(277, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Ghi nhận thanh toán";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(20, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(317, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Ghi nhận thanh toán mới cho hợp đồng";
            // 
            // lblPaymentID
            // 
            lblPaymentID.AutoSize = true;
            lblPaymentID.Font = new Font("Segoe UI", 11F);
            lblPaymentID.Location = new Point(20, 100);
            lblPaymentID.Name = "lblPaymentID";
            lblPaymentID.Size = new Size(148, 25);
            lblPaymentID.TabIndex = 2;
            lblPaymentID.Text = "Mã thanh toán:*";
            // 
            // txtPaymentID
            // 
            txtPaymentID.Font = new Font("Segoe UI", 10F);
            txtPaymentID.Location = new Point(20, 125);
            txtPaymentID.Name = "txtPaymentID";
            txtPaymentID.Size = new Size(400, 30);
            txtPaymentID.TabIndex = 3;
            // 
            // lblContractID
            // 
            lblContractID.AutoSize = true;
            lblContractID.Font = new Font("Segoe UI", 11F);
            lblContractID.Location = new Point(20, 170);
            lblContractID.Name = "lblContractID";
            lblContractID.Size = new Size(138, 25);
            lblContractID.TabIndex = 4;
            lblContractID.Text = "Mã hợp đồng:*";
            // 
            // cmbContractID
            // 
            cmbContractID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContractID.Font = new Font("Segoe UI", 10F);
            cmbContractID.FormattingEnabled = true;
            cmbContractID.Location = new Point(20, 195);
            cmbContractID.Name = "cmbContractID";
            cmbContractID.Size = new Size(400, 31);
            cmbContractID.TabIndex = 5;
            // 
            // lblBillMonth
            // 
            lblBillMonth.AutoSize = true;
            lblBillMonth.Font = new Font("Segoe UI", 11F);
            lblBillMonth.Location = new Point(20, 240);
            lblBillMonth.Name = "lblBillMonth";
            lblBillMonth.Size = new Size(77, 25);
            lblBillMonth.TabIndex = 6;
            lblBillMonth.Text = "Tháng:*";
            // 
            // numBillMonth
            // 
            numBillMonth.Font = new Font("Segoe UI", 10F);
            numBillMonth.Location = new Point(20, 265);
            numBillMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numBillMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBillMonth.Name = "numBillMonth";
            numBillMonth.Size = new Size(400, 30);
            numBillMonth.TabIndex = 7;
            numBillMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPaymentAmount
            // 
            lblPaymentAmount.AutoSize = true;
            lblPaymentAmount.Font = new Font("Segoe UI", 11F);
            lblPaymentAmount.Location = new Point(20, 310);
            lblPaymentAmount.Name = "lblPaymentAmount";
            lblPaymentAmount.Size = new Size(166, 25);
            lblPaymentAmount.TabIndex = 8;
            lblPaymentAmount.Text = "Số tiền cần đóng:*";
            // 
            // numPaymentAmount
            // 
            numPaymentAmount.Font = new Font("Segoe UI", 10F);
            numPaymentAmount.Location = new Point(20, 335);
            numPaymentAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numPaymentAmount.Name = "numPaymentAmount";
            numPaymentAmount.Size = new Size(400, 30);
            numPaymentAmount.TabIndex = 9;
            // 
            // lblPaidAmount
            // 
            lblPaidAmount.AutoSize = true;
            lblPaidAmount.Font = new Font("Segoe UI", 11F);
            lblPaidAmount.Location = new Point(20, 380);
            lblPaidAmount.Name = "lblPaidAmount";
            lblPaidAmount.Size = new Size(149, 25);
            lblPaidAmount.TabIndex = 10;
            lblPaidAmount.Text = "Số tiền đã đóng:";
            // 
            // numPaidAmount
            // 
            numPaidAmount.Font = new Font("Segoe UI", 10F);
            numPaidAmount.Location = new Point(20, 405);
            numPaidAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numPaidAmount.Name = "numPaidAmount";
            numPaidAmount.Size = new Size(400, 30);
            numPaidAmount.TabIndex = 11;
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Font = new Font("Segoe UI", 11F);
            lblPaymentDate.Location = new Point(20, 450);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(165, 25);
            lblPaymentDate.TabIndex = 12;
            lblPaymentDate.Text = "Ngày thanh toán:*";
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            dtpPaymentDate.Font = new Font("Segoe UI", 10F);
            dtpPaymentDate.Format = DateTimePickerFormat.Custom;
            dtpPaymentDate.Location = new Point(20, 475);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(400, 30);
            dtpPaymentDate.TabIndex = 13;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 11F);
            lblPaymentMethod.Location = new Point(20, 520);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(221, 25);
            lblPaymentMethod.TabIndex = 14;
            lblPaymentMethod.Text = "Phương thức thanh toán:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(20, 545);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(400, 31);
            cmbPaymentMethod.TabIndex = 15;
            // 
            // lblPaymentStatus
            // 
            lblPaymentStatus.AutoSize = true;
            lblPaymentStatus.Font = new Font("Segoe UI", 11F);
            lblPaymentStatus.Location = new Point(20, 590);
            lblPaymentStatus.Name = "lblPaymentStatus";
            lblPaymentStatus.Size = new Size(108, 25);
            lblPaymentStatus.TabIndex = 16;
            lblPaymentStatus.Text = "Trạng thái:*";
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentStatus.Font = new Font("Segoe UI", 10F);
            cmbPaymentStatus.FormattingEnabled = true;
            cmbPaymentStatus.Location = new Point(20, 615);
            cmbPaymentStatus.Name = "cmbPaymentStatus";
            cmbPaymentStatus.Size = new Size(400, 31);
            cmbPaymentStatus.TabIndex = 17;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(20, 685);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Nhập ghi chú (nếu có)";
            txtDescription.Size = new Size(400, 80);
            txtDescription.TabIndex = 19;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(102, 118, 239);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(102, 118, 239);
            btnCancel.Location = new Point(160, 790);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 20;
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
            btnSave.Location = new Point(270, 790);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 21;
            btnSave.Text = "Ghi nhận thanh toán";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtGhiChu
            // 
            txtGhiChu.AutoSize = true;
            txtGhiChu.Font = new Font("Segoe UI", 11F);
            txtGhiChu.Location = new Point(20, 657);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(77, 25);
            txtGhiChu.TabIndex = 22;
            txtGhiChu.Text = "Ghi chú";
            // 
            // frmAddPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 860);
            Controls.Add(txtGhiChu);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtDescription);
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
            Controls.Add(cmbContractID);
            Controls.Add(lblContractID);
            Controls.Add(txtPaymentID);
            Controls.Add(lblPaymentID);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddPayment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ghi nhận thanh toán";
            ((System.ComponentModel.ISupportInitialize)numBillMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPaidAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label txtGhiChu;
    }
}
