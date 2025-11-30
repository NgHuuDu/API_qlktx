namespace DormitoryManagementSystem.GUI.Forms
{
    partial class frmRoomDetail
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.ComboBox cmbBuilding;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.ComboBox cmbCapacity;
        private System.Windows.Forms.Label lblCurrentOccupancy;
        private System.Windows.Forms.TextBox txtCurrentOccupancy;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.CheckBox chkAllowCooking;
        private System.Windows.Forms.CheckBox chkAirConditioner;
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
            lblRoomID = new Label();
            txtRoomID = new TextBox();
            lblRoomNumber = new Label();
            txtRoomNumber = new TextBox();
            lblBuilding = new Label();
            cmbBuilding = new ComboBox();
            lblFloor = new Label();
            txtFloor = new TextBox();
            lblCapacity = new Label();
            cmbCapacity = new ComboBox();
            lblCurrentOccupancy = new Label();
            txtCurrentOccupancy = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            chkAllowCooking = new CheckBox();
            chkAirConditioner = new CheckBox();
            btnClose = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            btnApply = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblRoomID
            // 
            lblRoomID.AutoSize = true;
            lblRoomID.Font = new Font("Segoe UI", 11F);
            lblRoomID.Location = new Point(20, 20);
            lblRoomID.Name = "lblRoomID";
            lblRoomID.Size = new Size(103, 25);
            lblRoomID.TabIndex = 0;
            lblRoomID.Text = "Mã phòng:";
            // 
            // txtRoomID
            // 
            txtRoomID.Font = new Font("Segoe UI", 11F);
            txtRoomID.Location = new Point(150, 17);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.ReadOnly = true;
            txtRoomID.Size = new Size(265, 32);
            txtRoomID.TabIndex = 1;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 11F);
            lblRoomNumber.Location = new Point(20, 60);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(97, 25);
            lblRoomNumber.TabIndex = 2;
            lblRoomNumber.Text = "Số phòng:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 11F);
            txtRoomNumber.Location = new Point(150, 57);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new Size(265, 32);
            txtRoomNumber.TabIndex = 3;
            // 
            // lblBuilding
            // 
            lblBuilding.AutoSize = true;
            lblBuilding.Font = new Font("Segoe UI", 11F);
            lblBuilding.Location = new Point(20, 100);
            lblBuilding.Name = "lblBuilding";
            lblBuilding.Size = new Size(45, 25);
            lblBuilding.TabIndex = 4;
            lblBuilding.Text = "Tòa:";
            // 
            // cmbBuilding
            // 
            cmbBuilding.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBuilding.Enabled = false;
            cmbBuilding.Font = new Font("Segoe UI", 11F);
            cmbBuilding.FormattingEnabled = true;
            cmbBuilding.Location = new Point(150, 97);
            cmbBuilding.Name = "cmbBuilding";
            cmbBuilding.Size = new Size(265, 33);
            cmbBuilding.TabIndex = 5;
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Font = new Font("Segoe UI", 11F);
            lblFloor.Location = new Point(20, 140);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(58, 25);
            lblFloor.TabIndex = 6;
            lblFloor.Text = "Tầng:";
            // 
            // txtFloor
            // 
            txtFloor.Font = new Font("Segoe UI", 11F);
            txtFloor.Location = new Point(150, 137);
            txtFloor.Name = "txtFloor";
            txtFloor.ReadOnly = true;
            txtFloor.Size = new Size(265, 32);
            txtFloor.TabIndex = 7;
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI", 11F);
            lblCapacity.Location = new Point(20, 180);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(92, 25);
            lblCapacity.TabIndex = 8;
            lblCapacity.Text = "Sức chứa:";
            // 
            // cmbCapacity
            // 
            cmbCapacity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCapacity.Enabled = false;
            cmbCapacity.Font = new Font("Segoe UI", 11F);
            cmbCapacity.FormattingEnabled = true;
            cmbCapacity.Items.AddRange(new object[] { "2", "4", "6", "8" });
            cmbCapacity.Location = new Point(150, 177);
            cmbCapacity.Name = "cmbCapacity";
            cmbCapacity.Size = new Size(265, 33);
            cmbCapacity.TabIndex = 9;
            // 
            // lblCurrentOccupancy
            // 
            lblCurrentOccupancy.AutoSize = true;
            lblCurrentOccupancy.Font = new Font("Segoe UI", 11F);
            lblCurrentOccupancy.Location = new Point(20, 220);
            lblCurrentOccupancy.Name = "lblCurrentOccupancy";
            lblCurrentOccupancy.Size = new Size(77, 25);
            lblCurrentOccupancy.TabIndex = 10;
            lblCurrentOccupancy.Text = "Đang ở:";
            // 
            // txtCurrentOccupancy
            // 
            txtCurrentOccupancy.Font = new Font("Segoe UI", 11F);
            txtCurrentOccupancy.Location = new Point(150, 217);
            txtCurrentOccupancy.Name = "txtCurrentOccupancy";
            txtCurrentOccupancy.ReadOnly = true;
            txtCurrentOccupancy.Size = new Size(265, 32);
            txtCurrentOccupancy.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F);
            lblStatus.Location = new Point(20, 260);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 25);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Trạng thái:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Enabled = false;
            cmbStatus.Font = new Font("Segoe UI", 11F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Active", "Maintenance", "Inactive" });
            cmbStatus.Location = new Point(150, 257);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(265, 33);
            cmbStatus.TabIndex = 13;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 11F);
            lblPrice.Location = new Point(20, 300);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(104, 25);
            lblPrice.TabIndex = 14;
            lblPrice.Text = "Giá phòng:";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 11F);
            txtPrice.Location = new Point(150, 297);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(265, 32);
            txtPrice.TabIndex = 15;
            // 
            // chkAllowCooking
            // 
            chkAllowCooking.AutoSize = true;
            chkAllowCooking.Enabled = false;
            chkAllowCooking.Font = new Font("Segoe UI", 11F);
            chkAllowCooking.Location = new Point(150, 340);
            chkAllowCooking.Name = "chkAllowCooking";
            chkAllowCooking.Size = new Size(179, 29);
            chkAllowCooking.TabIndex = 16;
            chkAllowCooking.Text = "Cho phép nấu ăn";
            chkAllowCooking.UseVisualStyleBackColor = true;
            // 
            // chkAirConditioner
            // 
            chkAirConditioner.AutoSize = true;
            chkAirConditioner.Enabled = false;
            chkAirConditioner.Font = new Font("Segoe UI", 11F);
            chkAirConditioner.Location = new Point(150, 370);
            chkAirConditioner.Name = "chkAirConditioner";
            chkAirConditioner.Size = new Size(136, 29);
            chkAirConditioner.TabIndex = 17;
            chkAirConditioner.Text = "Có điều hòa";
            chkAirConditioner.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(190, 410);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 18;
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
            btnEdit.Location = new Point(300, 410);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(115, 40);
            btnEdit.TabIndex = 19;
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
            btnCancel.Location = new Point(190, 410);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 20;
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
            btnApply.Location = new Point(295, 410);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 40);
            btnApply.TabIndex = 21;
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
            btnDelete.Location = new Point(20, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 40);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // frmRoomDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 470);
            Controls.Add(btnDelete);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(btnClose);
            Controls.Add(chkAirConditioner);
            Controls.Add(chkAllowCooking);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtCurrentOccupancy);
            Controls.Add(lblCurrentOccupancy);
            Controls.Add(cmbCapacity);
            Controls.Add(lblCapacity);
            Controls.Add(txtFloor);
            Controls.Add(lblFloor);
            Controls.Add(cmbBuilding);
            Controls.Add(lblBuilding);
            Controls.Add(txtRoomNumber);
            Controls.Add(lblRoomNumber);
            Controls.Add(txtRoomID);
            Controls.Add(lblRoomID);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRoomDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết phòng";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

