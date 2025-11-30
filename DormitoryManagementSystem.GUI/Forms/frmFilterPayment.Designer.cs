namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmFilterPayment
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.TextBox txtPaymentID;
        private System.Windows.Forms.Label lblContractID;
        private System.Windows.Forms.TextBox txtContractID;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
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
            lblPaymentID = new Label();
            txtPaymentID = new TextBox();
            lblContractID = new Label();
            txtContractID = new TextBox();
            lblMonth = new Label();
            numMonth = new NumericUpDown();
            lblPaymentDate = new Label();
            dtpPaymentDate = new DateTimePicker();
            lblPaymentMethod = new Label();
            cmbPaymentMethod = new ComboBox();
            lblPaymentStatus = new Label();
            cmbPaymentStatus = new ComboBox();
            btnReset = new Button();
            btnApply = new Button();
            ((System.ComponentModel.ISupportInitialize)numMonth).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(208, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lọc thanh toán";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(20, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(383, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Áp dụng bộ lọc để tìm kiếm thanh toán phù hợp";
            // 
            // lblPaymentID
            // 
            lblPaymentID.AutoSize = true;
            lblPaymentID.Font = new Font("Segoe UI", 11F);
            lblPaymentID.Location = new Point(20, 100);
            lblPaymentID.Name = "lblPaymentID";
            lblPaymentID.Size = new Size(120, 25);
            lblPaymentID.TabIndex = 2;
            lblPaymentID.Text = "Mã thanh toán";
            // 
            // txtPaymentID
            // 
            txtPaymentID.Font = new Font("Segoe UI", 10F);
            txtPaymentID.Location = new Point(20, 125);
            txtPaymentID.Name = "txtPaymentID";
            txtPaymentID.Size = new Size(200, 30);
            txtPaymentID.TabIndex = 3;
            // 
            // lblContractID
            // 
            lblContractID.AutoSize = true;
            lblContractID.Font = new Font("Segoe UI", 11F);
            lblContractID.Location = new Point(250, 100);
            lblContractID.Name = "lblContractID";
            lblContractID.Size = new Size(113, 25);
            lblContractID.TabIndex = 4;
            lblContractID.Text = "Mã hợp đồng";
            // 
            // txtContractID
            // 
            txtContractID.Font = new Font("Segoe UI", 10F);
            txtContractID.Location = new Point(250, 125);
            txtContractID.Name = "txtContractID";
            txtContractID.Size = new Size(200, 30);
            txtContractID.TabIndex = 5;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("Segoe UI", 11F);
            lblMonth.Location = new Point(480, 100);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(54, 25);
            lblMonth.TabIndex = 6;
            lblMonth.Text = "Tháng";
            // 
            // numMonth
            // 
            numMonth.Font = new Font("Segoe UI", 10F);
            numMonth.Location = new Point(480, 125);
            numMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMonth.Name = "numMonth";
            numMonth.Size = new Size(100, 30);
            numMonth.TabIndex = 7;
            numMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Font = new Font("Segoe UI", 11F);
            lblPaymentDate.Location = new Point(20, 180);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(130, 25);
            lblPaymentDate.TabIndex = 8;
            lblPaymentDate.Text = "Ngày thanh toán";
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            dtpPaymentDate.Font = new Font("Segoe UI", 10F);
            dtpPaymentDate.Format = DateTimePickerFormat.Custom;
            dtpPaymentDate.Location = new Point(20, 205);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(200, 30);
            dtpPaymentDate.TabIndex = 9;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 11F);
            lblPaymentMethod.Location = new Point(250, 180);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(170, 25);
            lblPaymentMethod.TabIndex = 10;
            lblPaymentMethod.Text = "Phương thức thanh toán";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Tất cả", "Cash", "Bank Transfer", "Online" });
            cmbPaymentMethod.Location = new Point(250, 205);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(200, 31);
            cmbPaymentMethod.TabIndex = 11;
            // 
            // lblPaymentStatus
            // 
            lblPaymentStatus.AutoSize = true;
            lblPaymentStatus.Font = new Font("Segoe UI", 11F);
            lblPaymentStatus.Location = new Point(480, 180);
            lblPaymentStatus.Name = "lblPaymentStatus";
            lblPaymentStatus.Size = new Size(96, 25);
            lblPaymentStatus.TabIndex = 12;
            lblPaymentStatus.Text = "Trạng thái";
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentStatus.Font = new Font("Segoe UI", 10F);
            cmbPaymentStatus.FormattingEnabled = true;
            cmbPaymentStatus.Items.AddRange(new object[] { "Tất cả", "Đã thanh toán", "Chờ thanh toán", "Quá hạn", "Đã hoàn tiền" });
            cmbPaymentStatus.Location = new Point(480, 205);
            cmbPaymentStatus.Name = "cmbPaymentStatus";
            cmbPaymentStatus.Size = new Size(200, 31);
            cmbPaymentStatus.TabIndex = 13;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.White;
            btnReset.FlatAppearance.BorderColor = Color.FromArgb(102, 118, 239);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(102, 118, 239);
            btnReset.Location = new Point(480, 256);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 40);
            btnReset.TabIndex = 14;
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
            btnApply.Location = new Point(590, 256);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 40);
            btnApply.TabIndex = 15;
            btnApply.Text = "Áp dụng";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // frmFilterPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 320);
            Controls.Add(btnApply);
            Controls.Add(btnReset);
            Controls.Add(cmbPaymentStatus);
            Controls.Add(lblPaymentStatus);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPaymentMethod);
            Controls.Add(dtpPaymentDate);
            Controls.Add(lblPaymentDate);
            Controls.Add(numMonth);
            Controls.Add(lblMonth);
            Controls.Add(txtContractID);
            Controls.Add(lblContractID);
            Controls.Add(txtPaymentID);
            Controls.Add(lblPaymentID);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFilterPayment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lọc thanh toán";
            ((System.ComponentModel.ISupportInitialize)numMonth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
