namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmAddRoom
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.ComboBox cmbBuilding;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.ComboBox cmbCapacity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.CheckBox chkAllowCooking;
        private System.Windows.Forms.CheckBox chkAirConditioner;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            lblRoomID = new Label();
            txtRoomID = new TextBox();
            lblRoomNumber = new Label();
            txtRoomNumber = new TextBox();
            lblBuilding = new Label();
            cmbBuilding = new ComboBox();
            lblCapacity = new Label();
            cmbCapacity = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            chkAllowCooking = new CheckBox();
            chkAirConditioner = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblRoomID
            // 
            lblRoomID.AutoSize = true;
            lblRoomID.Font = new Font("Segoe UI", 11F);
            lblRoomID.Location = new Point(20, 20);
            lblRoomID.Name = "lblRoomID";
            lblRoomID.Size = new Size(111, 25);
            lblRoomID.TabIndex = 0;
            lblRoomID.Text = "Mã phòng:*";
            // 
            // txtRoomID
            // 
            txtRoomID.Font = new Font("Segoe UI", 11F);
            txtRoomID.Location = new Point(130, 17);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.Size = new Size(200, 32);
            txtRoomID.TabIndex = 1;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 11F);
            lblRoomNumber.Location = new Point(20, 60);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(105, 25);
            lblRoomNumber.TabIndex = 2;
            lblRoomNumber.Text = "Số phòng:*";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 11F);
            txtRoomNumber.Location = new Point(130, 57);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(200, 32);
            txtRoomNumber.TabIndex = 3;
            // 
            // lblBuilding
            // 
            lblBuilding.AutoSize = true;
            lblBuilding.Font = new Font("Segoe UI", 11F);
            lblBuilding.Location = new Point(20, 100);
            lblBuilding.Name = "lblBuilding";
            lblBuilding.Size = new Size(53, 25);
            lblBuilding.TabIndex = 4;
            lblBuilding.Text = "Tòa:*";
            // 
            // cmbBuilding
            // 
            cmbBuilding.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBuilding.Font = new Font("Segoe UI", 11F);
            cmbBuilding.FormattingEnabled = true;
            cmbBuilding.Location = new Point(130, 97);
            cmbBuilding.Name = "cmbBuilding";
            cmbBuilding.Size = new Size(200, 33);
            cmbBuilding.TabIndex = 5;
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI", 11F);
            lblCapacity.Location = new Point(20, 140);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(100, 25);
            lblCapacity.TabIndex = 6;
            lblCapacity.Text = "Sức chứa:*";
            // 
            // cmbCapacity
            // 
            cmbCapacity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCapacity.Font = new Font("Segoe UI", 11F);
            cmbCapacity.FormattingEnabled = true;
            cmbCapacity.Items.AddRange(new object[] { "2", "4", "6", "8" });
            cmbCapacity.Location = new Point(130, 137);
            cmbCapacity.Name = "cmbCapacity";
            cmbCapacity.Size = new Size(200, 33);
            cmbCapacity.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 11F);
            lblPrice.Location = new Point(20, 180);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(104, 25);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Giá phòng:";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 11F);
            txtPrice.Location = new Point(130, 177);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 32);
            txtPrice.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F);
            lblStatus.Location = new Point(20, 220);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 25);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Trạng thái:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 11F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Active", "Maintenance" });
            cmbStatus.Location = new Point(130, 217);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 33);
            cmbStatus.TabIndex = 11;
            // 
            // chkAllowCooking
            // 
            chkAllowCooking.AutoSize = true;
            chkAllowCooking.Font = new Font("Segoe UI", 11F);
            chkAllowCooking.Location = new Point(130, 265);
            chkAllowCooking.Name = "chkAllowCooking";
            chkAllowCooking.Size = new Size(179, 29);
            chkAllowCooking.TabIndex = 12;
            chkAllowCooking.Text = "Cho phép nấu ăn";
            chkAllowCooking.UseVisualStyleBackColor = true;
            // 
            // chkAirConditioner
            // 
            chkAirConditioner.AutoSize = true;
            chkAirConditioner.Font = new Font("Segoe UI", 11F);
            chkAirConditioner.Location = new Point(130, 295);
            chkAirConditioner.Name = "chkAirConditioner";
            chkAirConditioner.Size = new Size(136, 29);
            chkAirConditioner.TabIndex = 13;
            chkAirConditioner.Text = "Có điều hòa";
            chkAirConditioner.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(102, 118, 239);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(120, 330);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 14;
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
            btnCancel.Location = new Point(230, 330);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 390);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkAirConditioner);
            Controls.Add(chkAllowCooking);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(cmbCapacity);
            Controls.Add(lblCapacity);
            Controls.Add(cmbBuilding);
            Controls.Add(lblBuilding);
            Controls.Add(txtRoomNumber);
            Controls.Add(lblRoomNumber);
            Controls.Add(txtRoomID);
            Controls.Add(lblRoomID);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddRoom";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm phòng mới";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

