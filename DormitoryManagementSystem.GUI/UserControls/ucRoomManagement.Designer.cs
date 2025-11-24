
namespace DormitoryManagementSystem.GUI.UserControls
{
    partial class ucRoomManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlFilters = new Panel();
            btnAddRoom = new Button();
            btnFilter = new Button();
            cmbFilterStatus = new ComboBox();
            cmbFilterBuilding = new ComboBox();
            txtSearch = new TextBox();
            pnlKPICards = new Panel();
            cardA1 = new Panel();
            prgA1 = new ProgressBar();
            lblA1Occupancy = new Label();
            lblA1Floors = new Label();
            lblA1Gender = new Label();
            lblA1Building = new Label();
            cardA2 = new Panel();
            prgA2 = new ProgressBar();
            lblA2Occupancy = new Label();
            lblA2Floors = new Label();
            lblA2Gender = new Label();
            lblA2Building = new Label();
            cardB1 = new Panel();
            lblB1Gender = new Label();
            prgB1 = new ProgressBar();
            lblB1Occupancy = new Label();
            lblB1Floors = new Label();
            lblB1Building = new Label();
            cardB2 = new Panel();
            prgB2 = new ProgressBar();
            lblB2Occupancy = new Label();
            lblB2Floors = new Label();
            lblB2Gender = new Label();
            lblB2Building = new Label();
            dgvRooms = new DataGridView();
            pnlFilters.SuspendLayout();
            pnlKPICards.SuspendLayout();
            cardA1.SuspendLayout();
            cardA2.SuspendLayout();
            cardB1.SuspendLayout();
            cardB2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(btnAddRoom);
            pnlFilters.Controls.Add(btnFilter);
            pnlFilters.Controls.Add(cmbFilterStatus);
            pnlFilters.Controls.Add(cmbFilterBuilding);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(13, 15);
            pnlFilters.Margin = new Padding(4, 5, 4, 5);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(13, 15, 13, 15);
            pnlFilters.Size = new Size(1718, 107);
            pnlFilters.TabIndex = 0;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddRoom.BackColor = Color.FromArgb(26, 188, 156);
            btnAddRoom.FlatAppearance.BorderSize = 0;
            btnAddRoom.FlatStyle = FlatStyle.Flat;
            btnAddRoom.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnAddRoom.ForeColor = Color.White;
            btnAddRoom.Location = new Point(1398, 18);
            btnAddRoom.Margin = new Padding(4, 5, 4, 5);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(234, 62);
            btnAddRoom.TabIndex = 4;
            btnAddRoom.Text = "+ Thêm phòng";
            btnAddRoom.UseVisualStyleBackColor = false;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.BackColor = Color.FromArgb(102, 118, 239);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(1240, 18);
            btnFilter.Margin = new Padding(4, 5, 4, 5);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(123, 62);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Font = new Font("Segoe UI", 13F);
            cmbFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Trống", "Đang ở", "Bảo trì" });
            cmbFilterStatus.Location = new Point(994, 28);
            cmbFilterStatus.Margin = new Padding(4, 5, 4, 5);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(199, 44);
            cmbFilterStatus.TabIndex = 1;
            // 
            // cmbFilterBuilding
            // 
            cmbFilterBuilding.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilterBuilding.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterBuilding.Font = new Font("Segoe UI", 13F);
            cmbFilterBuilding.Items.AddRange(new object[] { "Tất cả tòa", "Tòa A", "Tòa B", "Tòa C" });
            cmbFilterBuilding.Location = new Point(764, 28);
            cmbFilterBuilding.Margin = new Padding(4, 5, 4, 5);
            cmbFilterBuilding.Name = "cmbFilterBuilding";
            cmbFilterBuilding.Size = new Size(199, 44);
            cmbFilterBuilding.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 13F);
            txtSearch.Location = new Point(17, 28);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo mã phòng...";
            txtSearch.Size = new Size(664, 42);
            txtSearch.TabIndex = 0;
            // 
            // pnlKPICards
            // 
            pnlKPICards.BackColor = Color.Transparent;
            pnlKPICards.Controls.Add(cardA1);
            pnlKPICards.Controls.Add(cardA2);
            pnlKPICards.Controls.Add(cardB1);
            pnlKPICards.Controls.Add(cardB2);
            pnlKPICards.Dock = DockStyle.Top;
            pnlKPICards.Location = new Point(13, 122);
            pnlKPICards.Margin = new Padding(4, 5, 4, 5);
            pnlKPICards.Name = "pnlKPICards";
            pnlKPICards.Padding = new Padding(20, 20, 20, 15);
            pnlKPICards.Size = new Size(1718, 270);
            pnlKPICards.TabIndex = 2;
            // 
            // cardA1
            // 
            cardA1.Anchor = AnchorStyles.None;
            cardA1.BackColor = Color.White;
            cardA1.BorderStyle = BorderStyle.FixedSingle;
            cardA1.Controls.Add(prgA1);
            cardA1.Controls.Add(lblA1Occupancy);
            cardA1.Controls.Add(lblA1Floors);
            cardA1.Controls.Add(lblA1Gender);
            cardA1.Controls.Add(lblA1Building);
            cardA1.Location = new Point(20, 55);
            cardA1.Margin = new Padding(5);
            cardA1.Name = "cardA1";
            cardA1.Padding = new Padding(15);
            cardA1.Size = new Size(400, 165);
            cardA1.TabIndex = 0;
            // 
            // prgA1
            // 
            prgA1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            prgA1.Location = new Point(15, 133);
            prgA1.Margin = new Padding(0);
            prgA1.Name = "prgA1";
            prgA1.Size = new Size(370, 20);
            prgA1.Style = ProgressBarStyle.Continuous;
            prgA1.TabIndex = 4;
            // 
            // lblA1Occupancy
            // 
            lblA1Occupancy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblA1Occupancy.AutoSize = true;
            lblA1Occupancy.Font = new Font("Segoe UI", 10F);
            lblA1Occupancy.ForeColor = Color.Black;
            lblA1Occupancy.Location = new Point(15, 99);
            lblA1Occupancy.Margin = new Padding(0);
            lblA1Occupancy.Name = "lblA1Occupancy";
            lblA1Occupancy.Size = new Size(121, 28);
            lblA1Occupancy.TabIndex = 3;
            lblA1Occupancy.Text = "Tỷ lệ lấp đầy";
            // 
            // lblA1Floors
            // 
            lblA1Floors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblA1Floors.AutoSize = true;
            lblA1Floors.Font = new Font("Segoe UI", 10F);
            lblA1Floors.ForeColor = Color.Gray;
            lblA1Floors.Location = new Point(15, 47);
            lblA1Floors.Margin = new Padding(0);
            lblA1Floors.Name = "lblA1Floors";
            lblA1Floors.Size = new Size(68, 28);
            lblA1Floors.TabIndex = 2;
            lblA1Floors.Text = "5 tầng";
            // 
            // lblA1Gender
            // 
            lblA1Gender.AutoSize = true;
            lblA1Gender.BackColor = Color.FromArgb(102, 118, 239);
            lblA1Gender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblA1Gender.ForeColor = Color.White;
            lblA1Gender.Location = new Point(324, 19);
            lblA1Gender.Margin = new Padding(0);
            lblA1Gender.Name = "lblA1Gender";
            lblA1Gender.Padding = new Padding(8, 4, 8, 4);
            lblA1Gender.Size = new Size(68, 33);
            lblA1Gender.TabIndex = 1;
            lblA1Gender.Text = "Nam";
            // 
            // lblA1Building
            // 
            lblA1Building.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblA1Building.AutoSize = true;
            lblA1Building.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblA1Building.ForeColor = Color.Black;
            lblA1Building.Location = new Point(15, 15);
            lblA1Building.Margin = new Padding(0);
            lblA1Building.Name = "lblA1Building";
            lblA1Building.Size = new Size(106, 38);
            lblA1Building.TabIndex = 0;
            lblA1Building.Text = "Tòa A1";
            // 
            // cardA2
            // 
            cardA2.Anchor = AnchorStyles.None;
            cardA2.BackColor = Color.White;
            cardA2.BorderStyle = BorderStyle.FixedSingle;
            cardA2.Controls.Add(prgA2);
            cardA2.Controls.Add(lblA2Occupancy);
            cardA2.Controls.Add(lblA2Floors);
            cardA2.Controls.Add(lblA2Gender);
            cardA2.Controls.Add(lblA2Building);
            cardA2.Location = new Point(440, 55);
            cardA2.Margin = new Padding(5);
            cardA2.Name = "cardA2";
            cardA2.Padding = new Padding(15);
            cardA2.Size = new Size(400, 165);
            cardA2.TabIndex = 1;
            // 
            // prgA2
            // 
            prgA2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            prgA2.Location = new Point(15, 133);
            prgA2.Margin = new Padding(0);
            prgA2.Name = "prgA2";
            prgA2.Size = new Size(370, 20);
            prgA2.Style = ProgressBarStyle.Continuous;
            prgA2.TabIndex = 4;
            // 
            // lblA2Occupancy
            // 
            lblA2Occupancy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblA2Occupancy.AutoSize = true;
            lblA2Occupancy.Font = new Font("Segoe UI", 10F);
            lblA2Occupancy.ForeColor = Color.Black;
            lblA2Occupancy.Location = new Point(15, 99);
            lblA2Occupancy.Margin = new Padding(0);
            lblA2Occupancy.Name = "lblA2Occupancy";
            lblA2Occupancy.Size = new Size(121, 28);
            lblA2Occupancy.TabIndex = 3;
            lblA2Occupancy.Text = "Tỷ lệ lấp đầy";
            // 
            // lblA2Floors
            // 
            lblA2Floors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblA2Floors.AutoSize = true;
            lblA2Floors.Font = new Font("Segoe UI", 10F);
            lblA2Floors.ForeColor = Color.Gray;
            lblA2Floors.Location = new Point(15, 47);
            lblA2Floors.Margin = new Padding(0);
            lblA2Floors.Name = "lblA2Floors";
            lblA2Floors.Size = new Size(68, 28);
            lblA2Floors.TabIndex = 2;
            lblA2Floors.Text = "5 tầng";
            // 
            // lblA2Gender
            // 
            lblA2Gender.AutoSize = true;
            lblA2Gender.BackColor = Color.FromArgb(102, 118, 239);
            lblA2Gender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblA2Gender.ForeColor = Color.White;
            lblA2Gender.Location = new Point(324, 19);
            lblA2Gender.Margin = new Padding(0);
            lblA2Gender.Name = "lblA2Gender";
            lblA2Gender.Padding = new Padding(8, 4, 8, 4);
            lblA2Gender.Size = new Size(68, 33);
            lblA2Gender.TabIndex = 1;
            lblA2Gender.Text = "Nam";
            // 
            // lblA2Building
            // 
            lblA2Building.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblA2Building.AutoSize = true;
            lblA2Building.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblA2Building.ForeColor = Color.Black;
            lblA2Building.Location = new Point(15, 15);
            lblA2Building.Margin = new Padding(0);
            lblA2Building.Name = "lblA2Building";
            lblA2Building.Size = new Size(106, 38);
            lblA2Building.TabIndex = 0;
            lblA2Building.Text = "Tòa A2";
            // 
            // cardB1
            // 
            cardB1.Anchor = AnchorStyles.None;
            cardB1.BackColor = Color.White;
            cardB1.BorderStyle = BorderStyle.FixedSingle;
            cardB1.Controls.Add(lblB1Gender);
            cardB1.Controls.Add(prgB1);
            cardB1.Controls.Add(lblB1Occupancy);
            cardB1.Controls.Add(lblB1Floors);
            cardB1.Controls.Add(lblB1Building);
            cardB1.Location = new Point(860, 55);
            cardB1.Margin = new Padding(5);
            cardB1.Name = "cardB1";
            cardB1.Padding = new Padding(15);
            cardB1.Size = new Size(400, 165);
            cardB1.TabIndex = 2;
            // 
            // lblB1Gender
            // 
            lblB1Gender.AutoSize = true;
            lblB1Gender.BackColor = Color.FromArgb(102, 118, 239);
            lblB1Gender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblB1Gender.ForeColor = Color.White;
            lblB1Gender.Location = new Point(336, 19);
            lblB1Gender.Margin = new Padding(0);
            lblB1Gender.Name = "lblB1Gender";
            lblB1Gender.Padding = new Padding(8, 4, 8, 4);
            lblB1Gender.Size = new Size(54, 33);
            lblB1Gender.TabIndex = 1;
            lblB1Gender.Text = "Nữ";
            // 
            // prgB1
            // 
            prgB1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            prgB1.Location = new Point(15, 133);
            prgB1.Margin = new Padding(0);
            prgB1.Name = "prgB1";
            prgB1.Size = new Size(370, 20);
            prgB1.Style = ProgressBarStyle.Continuous;
            prgB1.TabIndex = 4;
            // 
            // lblB1Occupancy
            // 
            lblB1Occupancy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblB1Occupancy.AutoSize = true;
            lblB1Occupancy.Font = new Font("Segoe UI", 10F);
            lblB1Occupancy.ForeColor = Color.Black;
            lblB1Occupancy.Location = new Point(15, 99);
            lblB1Occupancy.Margin = new Padding(0);
            lblB1Occupancy.Name = "lblB1Occupancy";
            lblB1Occupancy.Size = new Size(121, 28);
            lblB1Occupancy.TabIndex = 3;
            lblB1Occupancy.Text = "Tỷ lệ lấp đầy";
            // 
            // lblB1Floors
            // 
            lblB1Floors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblB1Floors.AutoSize = true;
            lblB1Floors.Font = new Font("Segoe UI", 10F);
            lblB1Floors.ForeColor = Color.Gray;
            lblB1Floors.Location = new Point(15, 47);
            lblB1Floors.Margin = new Padding(0);
            lblB1Floors.Name = "lblB1Floors";
            lblB1Floors.Size = new Size(68, 28);
            lblB1Floors.TabIndex = 2;
            lblB1Floors.Text = "5 tầng";
            // 
            // lblB1Building
            // 
            lblB1Building.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblB1Building.AutoSize = true;
            lblB1Building.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblB1Building.ForeColor = Color.Black;
            lblB1Building.Location = new Point(15, 15);
            lblB1Building.Margin = new Padding(0);
            lblB1Building.Name = "lblB1Building";
            lblB1Building.Size = new Size(104, 38);
            lblB1Building.TabIndex = 0;
            lblB1Building.Text = "Tòa B1";
            // 
            // cardB2
            // 
            cardB2.Anchor = AnchorStyles.None;
            cardB2.BackColor = Color.White;
            cardB2.BorderStyle = BorderStyle.FixedSingle;
            cardB2.Controls.Add(prgB2);
            cardB2.Controls.Add(lblB2Occupancy);
            cardB2.Controls.Add(lblB2Floors);
            cardB2.Controls.Add(lblB2Gender);
            cardB2.Controls.Add(lblB2Building);
            cardB2.Location = new Point(1280, 55);
            cardB2.Margin = new Padding(5);
            cardB2.Name = "cardB2";
            cardB2.Padding = new Padding(15);
            cardB2.Size = new Size(400, 165);
            cardB2.TabIndex = 3;
            // 
            // prgB2
            // 
            prgB2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            prgB2.Location = new Point(15, 133);
            prgB2.Margin = new Padding(0);
            prgB2.Name = "prgB2";
            prgB2.Size = new Size(370, 20);
            prgB2.Style = ProgressBarStyle.Continuous;
            prgB2.TabIndex = 4;
            // 
            // lblB2Occupancy
            // 
            lblB2Occupancy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblB2Occupancy.AutoSize = true;
            lblB2Occupancy.Font = new Font("Segoe UI", 10F);
            lblB2Occupancy.ForeColor = Color.Black;
            lblB2Occupancy.Location = new Point(15, 99);
            lblB2Occupancy.Margin = new Padding(0);
            lblB2Occupancy.Name = "lblB2Occupancy";
            lblB2Occupancy.Size = new Size(121, 28);
            lblB2Occupancy.TabIndex = 3;
            lblB2Occupancy.Text = "Tỷ lệ lấp đầy";
            // 
            // lblB2Floors
            // 
            lblB2Floors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblB2Floors.AutoSize = true;
            lblB2Floors.Font = new Font("Segoe UI", 10F);
            lblB2Floors.ForeColor = Color.Gray;
            lblB2Floors.Location = new Point(15, 47);
            lblB2Floors.Margin = new Padding(0);
            lblB2Floors.Name = "lblB2Floors";
            lblB2Floors.Size = new Size(68, 28);
            lblB2Floors.TabIndex = 2;
            lblB2Floors.Text = "5 tầng";
            // 
            // lblB2Gender
            // 
            lblB2Gender.AutoSize = true;
            lblB2Gender.BackColor = Color.FromArgb(102, 118, 239);
            lblB2Gender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblB2Gender.ForeColor = Color.White;
            lblB2Gender.Location = new Point(338, 19);
            lblB2Gender.Margin = new Padding(0);
            lblB2Gender.Name = "lblB2Gender";
            lblB2Gender.Padding = new Padding(8, 4, 8, 4);
            lblB2Gender.Size = new Size(54, 33);
            lblB2Gender.TabIndex = 1;
            lblB2Gender.Text = "Nữ";
            // 
            // lblB2Building
            // 
            lblB2Building.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblB2Building.AutoSize = true;
            lblB2Building.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblB2Building.ForeColor = Color.Black;
            lblB2Building.Location = new Point(15, 15);
            lblB2Building.Margin = new Padding(0);
            lblB2Building.Name = "lblB2Building";
            lblB2Building.Size = new Size(104, 38);
            lblB2Building.TabIndex = 0;
            lblB2Building.Text = "Tòa B2";
            // 
            // dgvRooms
            // 
            dgvRooms.ColumnHeadersHeight = 45;
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.Location = new Point(13, 392);
            dgvRooms.Margin = new Padding(4, 5, 4, 5);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.RowTemplate.Height = 40;
            dgvRooms.Size = new Size(1718, 499);
            dgvRooms.TabIndex = 1;
            // 
            // ucRoomManagement
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(dgvRooms);
            Controls.Add(pnlKPICards);
            Controls.Add(pnlFilters);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ucRoomManagement";
            Padding = new Padding(13, 15, 13, 15);
            Size = new Size(1744, 906);
            Load += ucRoomManagement_Load;
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlKPICards.ResumeLayout(false);
            cardA1.ResumeLayout(false);
            cardA1.PerformLayout();
            cardA2.ResumeLayout(false);
            cardA2.PerformLayout();
            cardB1.ResumeLayout(false);
            cardB1.PerformLayout();
            cardB2.ResumeLayout(false);
            cardB2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilterBuilding;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Panel pnlKPICards;
        private System.Windows.Forms.Panel cardA1;
        private System.Windows.Forms.Label lblA1Building;
        private System.Windows.Forms.Label lblA1Gender;
        private System.Windows.Forms.Label lblA1Floors;
        private System.Windows.Forms.Label lblA1Occupancy;
        private System.Windows.Forms.ProgressBar prgA1;
        private System.Windows.Forms.Panel cardA2;
        private System.Windows.Forms.Label lblA2Building;
        private System.Windows.Forms.Label lblA2Gender;
        private System.Windows.Forms.Label lblA2Floors;
        private System.Windows.Forms.Label lblA2Occupancy;
        private System.Windows.Forms.ProgressBar prgA2;
        private System.Windows.Forms.Panel cardB1;
        private System.Windows.Forms.Label lblB1Building;
        private System.Windows.Forms.Label lblB1Gender;
        private System.Windows.Forms.Label lblB1Floors;
        private System.Windows.Forms.Label lblB1Occupancy;
        private System.Windows.Forms.ProgressBar prgB1;
        private System.Windows.Forms.Panel cardB2;
        private System.Windows.Forms.Label lblB2Building;
        private System.Windows.Forms.Label lblB2Gender;
        private System.Windows.Forms.Label lblB2Floors;
        private System.Windows.Forms.Label lblB2Occupancy;
        private System.Windows.Forms.ProgressBar prgB2;
        private System.Windows.Forms.DataGridView dgvRooms;
    }
}