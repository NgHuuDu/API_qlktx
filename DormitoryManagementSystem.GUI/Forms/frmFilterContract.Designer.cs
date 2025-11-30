namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmFilterContract
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.ComboBox cmbBuilding;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
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
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            btnReset = new Button();
            btnApply = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(192, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lọc hợp đồng";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(20, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(373, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Áp dụng bộ lọc để tìm kiếm hợp đồng phù hợp";
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
            cmbBuilding.Location = new Point(20, 125);
            cmbBuilding.Name = "cmbBuilding";
            cmbBuilding.Size = new Size(200, 31);
            cmbBuilding.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F);
            lblStatus.Location = new Point(250, 100);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(96, 25);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Trạng thái";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Tất cả", "Còn hạn", "Đã hết hạn", "Đã hủy" });
            cmbStatus.Location = new Point(250, 125);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 31);
            cmbStatus.TabIndex = 5;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 11F);
            lblStartDate.Location = new Point(20, 170);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(125, 25);
            lblStartDate.TabIndex = 6;
            lblStartDate.Text = "Ngày bắt đầu";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(20, 195);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 30);
            dtpStartDate.TabIndex = 7;
            dtpStartDate.Value = new DateTime(2024, 11, 26, 3, 26, 16, 160);
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 11F);
            lblEndDate.Location = new Point(250, 170);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(128, 25);
            lblEndDate.TabIndex = 8;
            lblEndDate.Text = "Ngày kết thúc";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(250, 195);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 30);
            dtpEndDate.TabIndex = 9;
            dtpEndDate.Value = new DateTime(2026, 11, 26, 3, 26, 16, 162);
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.White;
            btnReset.FlatAppearance.BorderColor = Color.FromArgb(102, 118, 239);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(102, 118, 239);
            btnReset.Location = new Point(240, 249);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 40);
            btnReset.TabIndex = 10;
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
            btnApply.Location = new Point(350, 249);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 40);
            btnApply.TabIndex = 11;
            btnApply.Text = "Áp dụng";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // frmFilterContract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 310);
            Controls.Add(btnApply);
            Controls.Add(btnReset);
            Controls.Add(dtpEndDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblStartDate);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(cmbBuilding);
            Controls.Add(lblBuilding);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFilterContract";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lọc hợp đồng";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
