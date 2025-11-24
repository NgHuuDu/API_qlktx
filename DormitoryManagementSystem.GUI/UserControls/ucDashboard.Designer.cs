namespace DormitoryManagementSystem.GUI.UserControls
{
    partial class ucDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pnlHeader = new Panel();
            btnRefresh = new Button();
            cmbTimeRange = new ComboBox();
            cmbBuilding = new ComboBox();
            lblLogo = new Label();
            pnlKPICards = new Panel();
            cardViolations = new Panel();
            lblViolationsValue = new Label();
            lblViolationsTitle = new Label();
            cardRevenue = new Panel();
            lblRevenueValue = new Label();
            lblRevenueTitle = new Label();
            cardPending = new Panel();
            btnReviewNow = new Button();
            lblPendingValue = new Label();
            lblPendingTitle = new Label();
            cardOccupied = new Panel();
            lblOccupiedValue = new Label();
            lblOccupiedTitle = new Label();
            cardAvailable = new Panel();
            lblAvailableValue = new Label();
            lblAvailableTitle = new Label();
            cardTotalRooms = new Panel();
            lblTotalRoomsValue = new Label();
            lblTotalRoomsTitle = new Label();
            pnlCharts = new Panel();
            chartTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartOccupancyByBuilding = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartOccupancyPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pnlPendingContracts = new Panel();
            dgvPendingContracts = new DataGridView();
            pnlSearchContracts = new Panel();
            btnSearchContracts = new Button();
            lblPendingContractsTitle = new Label();
            txtSearchContracts = new TextBox();
            pnlBottom = new Panel();
            pnlRecentActivity = new Panel();
            lstRecentActivity = new ListBox();
            lblRecentActivityTitle = new Label();
            pnlAlerts = new Panel();
            lstAlerts = new ListBox();
            lblAlertsTitle = new Label();
            pnlQuickActions = new Panel();
            btnViewStats = new Button();
            btnAddViolation = new Button();
            btnAddPayment = new Button();
            btnAddRoom = new Button();
            lblQuickActionsTitle = new Label();
            scrollPanel = new Panel();
            pnlHeader.SuspendLayout();
            pnlKPICards.SuspendLayout();
            cardViolations.SuspendLayout();
            cardRevenue.SuspendLayout();
            cardPending.SuspendLayout();
            cardOccupied.SuspendLayout();
            cardAvailable.SuspendLayout();
            cardTotalRooms.SuspendLayout();
            pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartOccupancyByBuilding).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartOccupancyPie).BeginInit();
            pnlPendingContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingContracts).BeginInit();
            pnlSearchContracts.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlRecentActivity.SuspendLayout();
            pnlAlerts.SuspendLayout();
            pnlQuickActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(cmbTimeRange);
            pnlHeader.Controls.Add(cmbBuilding);
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 5, 4, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(27, 23, 27, 23);
            pnlHeader.Size = new Size(1467, 92);
            pnlHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnRefresh.Location = new Point(1276, 24);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(143, 46);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "↻ Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cmbTimeRange
            // 
            cmbTimeRange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbTimeRange.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeRange.Font = new Font("Microsoft Sans Serif", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTimeRange.FormattingEnabled = true;
            cmbTimeRange.Items.AddRange(new object[] { "Hôm nay", "Tuần này", "Tháng này", "3 tháng", "6 tháng", "Năm nay" });
            cmbTimeRange.Location = new Point(1051, 28);
            cmbTimeRange.Margin = new Padding(4, 5, 4, 5);
            cmbTimeRange.Name = "cmbTimeRange";
            cmbTimeRange.Size = new Size(185, 38);
            cmbTimeRange.TabIndex = 2;
            cmbTimeRange.SelectedIndexChanged += cmbTimeRange_SelectedIndexChanged;
            // 
            // cmbBuilding
            // 
            cmbBuilding.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbBuilding.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBuilding.Font = new Font("Microsoft Sans Serif", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBuilding.FormattingEnabled = true;
            cmbBuilding.Items.AddRange(new object[] { "Tất cả tòa", "Tòa A1", "Tòa A2", "Tòa B1", "Tòa B2" });
            cmbBuilding.Location = new Point(858, 27);
            cmbBuilding.Margin = new Padding(4, 5, 4, 5);
            cmbBuilding.Name = "cmbBuilding";
            cmbBuilding.Size = new Size(185, 38);
            cmbBuilding.TabIndex = 1;
            cmbBuilding.SelectedIndexChanged += cmbBuilding_SelectedIndexChanged;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.Location = new Point(27, 23);
            lblLogo.Margin = new Padding(4, 0, 4, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(184, 45);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Dashboard";
            // 
            // pnlKPICards
            // 
            pnlKPICards.BackColor = Color.Transparent;
            pnlKPICards.Controls.Add(cardViolations);
            pnlKPICards.Controls.Add(cardRevenue);
            pnlKPICards.Controls.Add(cardPending);
            pnlKPICards.Controls.Add(cardOccupied);
            pnlKPICards.Controls.Add(cardAvailable);
            pnlKPICards.Controls.Add(cardTotalRooms);
            pnlKPICards.Dock = DockStyle.Top;
            pnlKPICards.Location = new Point(0, 92);
            pnlKPICards.Margin = new Padding(4, 5, 4, 5);
            pnlKPICards.Name = "pnlKPICards";
            pnlKPICards.Padding = new Padding(20, 20, 20, 15);
            pnlKPICards.Size = new Size(1467, 235);
            pnlKPICards.TabIndex = 1;
            // 
            // cardViolations
            // 
            cardViolations.Anchor = AnchorStyles.None;
            cardViolations.BackColor = Color.White;
            cardViolations.BorderStyle = BorderStyle.FixedSingle;
            cardViolations.Controls.Add(lblViolationsValue);
            cardViolations.Controls.Add(lblViolationsTitle);
            cardViolations.Location = new Point(1146, 58);
            cardViolations.Margin = new Padding(5);
            cardViolations.Name = "cardViolations";
            cardViolations.Padding = new Padding(15);
            cardViolations.Size = new Size(200, 125);
            cardViolations.TabIndex = 5;
            // 
            // lblViolationsValue
            // 
            lblViolationsValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblViolationsValue.AutoSize = true;
            lblViolationsValue.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lblViolationsValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblViolationsValue.Location = new Point(15, 50);
            lblViolationsValue.Margin = new Padding(0);
            lblViolationsValue.Name = "lblViolationsValue";
            lblViolationsValue.Size = new Size(38, 40);
            lblViolationsValue.TabIndex = 1;
            lblViolationsValue.Text = "0";
            // 
            // lblViolationsTitle
            // 
            lblViolationsTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblViolationsTitle.AutoSize = true;
            lblViolationsTitle.Font = new Font("Microsoft Sans Serif", 9F);
            lblViolationsTitle.ForeColor = Color.Gray;
            lblViolationsTitle.Location = new Point(15, 15);
            lblViolationsTitle.Margin = new Padding(0);
            lblViolationsTitle.Name = "lblViolationsTitle";
            lblViolationsTitle.Size = new Size(108, 22);
            lblViolationsTitle.TabIndex = 0;
            lblViolationsTitle.Text = "Vi phạm mới";
            // 
            // cardRevenue
            // 
            cardRevenue.Anchor = AnchorStyles.None;
            cardRevenue.BackColor = Color.White;
            cardRevenue.BorderStyle = BorderStyle.FixedSingle;
            cardRevenue.Controls.Add(lblRevenueValue);
            cardRevenue.Controls.Add(lblRevenueTitle);
            cardRevenue.Location = new Point(936, 58);
            cardRevenue.Margin = new Padding(5);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Padding = new Padding(15);
            cardRevenue.Size = new Size(200, 125);
            cardRevenue.TabIndex = 4;
            // 
            // lblRevenueValue
            // 
            lblRevenueValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRevenueValue.AutoSize = true;
            lblRevenueValue.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblRevenueValue.ForeColor = Color.FromArgb(26, 188, 156);
            lblRevenueValue.Location = new Point(15, 50);
            lblRevenueValue.Margin = new Padding(0);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Size = new Size(56, 37);
            lblRevenueValue.TabIndex = 1;
            lblRevenueValue.Text = "0đ";
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Microsoft Sans Serif", 9F);
            lblRevenueTitle.ForeColor = Color.Gray;
            lblRevenueTitle.Location = new Point(15, 15);
            lblRevenueTitle.Margin = new Padding(0);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(126, 22);
            lblRevenueTitle.TabIndex = 0;
            lblRevenueTitle.Text = "Thu tháng này";
            // 
            // cardPending
            // 
            cardPending.Anchor = AnchorStyles.None;
            cardPending.BackColor = Color.White;
            cardPending.BorderStyle = BorderStyle.FixedSingle;
            cardPending.Controls.Add(btnReviewNow);
            cardPending.Controls.Add(lblPendingValue);
            cardPending.Controls.Add(lblPendingTitle);
            cardPending.Location = new Point(726, 58);
            cardPending.Margin = new Padding(5);
            cardPending.Name = "cardPending";
            cardPending.Padding = new Padding(15);
            cardPending.Size = new Size(200, 125);
            cardPending.TabIndex = 3;
            // 
            // btnReviewNow
            // 
            btnReviewNow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnReviewNow.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnReviewNow.Location = new Point(66, 79);
            btnReviewNow.Margin = new Padding(0);
            btnReviewNow.Name = "btnReviewNow";
            btnReviewNow.Size = new Size(117, 38);
            btnReviewNow.TabIndex = 2;
            btnReviewNow.Text = "Xem ngay";
            btnReviewNow.UseVisualStyleBackColor = true;
            btnReviewNow.Click += btnReviewNow_Click;
            // 
            // lblPendingValue
            // 
            lblPendingValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPendingValue.AutoSize = true;
            lblPendingValue.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lblPendingValue.ForeColor = Color.FromArgb(241, 196, 15);
            lblPendingValue.Location = new Point(15, 50);
            lblPendingValue.Margin = new Padding(0);
            lblPendingValue.Name = "lblPendingValue";
            lblPendingValue.Size = new Size(38, 40);
            lblPendingValue.TabIndex = 1;
            lblPendingValue.Text = "0";
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPendingTitle.AutoSize = true;
            lblPendingTitle.Font = new Font("Microsoft Sans Serif", 9F);
            lblPendingTitle.ForeColor = Color.Gray;
            lblPendingTitle.Location = new Point(15, 15);
            lblPendingTitle.Margin = new Padding(0);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(92, 22);
            lblPendingTitle.TabIndex = 0;
            lblPendingTitle.Text = "Chờ duyệt";
            // 
            // cardOccupied
            // 
            cardOccupied.Anchor = AnchorStyles.None;
            cardOccupied.BackColor = Color.White;
            cardOccupied.BorderStyle = BorderStyle.FixedSingle;
            cardOccupied.Controls.Add(lblOccupiedValue);
            cardOccupied.Controls.Add(lblOccupiedTitle);
            cardOccupied.Location = new Point(516, 58);
            cardOccupied.Margin = new Padding(5);
            cardOccupied.Name = "cardOccupied";
            cardOccupied.Padding = new Padding(15);
            cardOccupied.Size = new Size(200, 125);
            cardOccupied.TabIndex = 2;
            // 
            // lblOccupiedValue
            // 
            lblOccupiedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOccupiedValue.AutoSize = true;
            lblOccupiedValue.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lblOccupiedValue.ForeColor = Color.FromArgb(52, 152, 219);
            lblOccupiedValue.Location = new Point(15, 50);
            lblOccupiedValue.Margin = new Padding(0);
            lblOccupiedValue.Name = "lblOccupiedValue";
            lblOccupiedValue.Size = new Size(38, 40);
            lblOccupiedValue.TabIndex = 1;
            lblOccupiedValue.Text = "0";
            // 
            // lblOccupiedTitle
            // 
            lblOccupiedTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOccupiedTitle.AutoSize = true;
            lblOccupiedTitle.Font = new Font("Microsoft Sans Serif", 9F);
            lblOccupiedTitle.ForeColor = Color.Gray;
            lblOccupiedTitle.Location = new Point(15, 15);
            lblOccupiedTitle.Margin = new Padding(0);
            lblOccupiedTitle.Name = "lblOccupiedTitle";
            lblOccupiedTitle.Size = new Size(68, 22);
            lblOccupiedTitle.TabIndex = 0;
            lblOccupiedTitle.Text = "Đang ở";
            // 
            // cardAvailable
            // 
            cardAvailable.Anchor = AnchorStyles.None;
            cardAvailable.BackColor = Color.White;
            cardAvailable.BorderStyle = BorderStyle.FixedSingle;
            cardAvailable.Controls.Add(lblAvailableValue);
            cardAvailable.Controls.Add(lblAvailableTitle);
            cardAvailable.Location = new Point(306, 58);
            cardAvailable.Margin = new Padding(5);
            cardAvailable.Name = "cardAvailable";
            cardAvailable.Padding = new Padding(15);
            cardAvailable.Size = new Size(200, 125);
            cardAvailable.TabIndex = 1;
            // 
            // lblAvailableValue
            // 
            lblAvailableValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAvailableValue.AutoSize = true;
            lblAvailableValue.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lblAvailableValue.ForeColor = Color.FromArgb(26, 188, 156);
            lblAvailableValue.Location = new Point(15, 50);
            lblAvailableValue.Margin = new Padding(0);
            lblAvailableValue.Name = "lblAvailableValue";
            lblAvailableValue.Size = new Size(38, 40);
            lblAvailableValue.TabIndex = 1;
            lblAvailableValue.Text = "0";
            // 
            // lblAvailableTitle
            // 
            lblAvailableTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAvailableTitle.AutoSize = true;
            lblAvailableTitle.Font = new Font("Microsoft Sans Serif", 9F);
            lblAvailableTitle.ForeColor = Color.Gray;
            lblAvailableTitle.Location = new Point(15, 15);
            lblAvailableTitle.Margin = new Padding(0);
            lblAvailableTitle.Name = "lblAvailableTitle";
            lblAvailableTitle.Size = new Size(99, 22);
            lblAvailableTitle.TabIndex = 0;
            lblAvailableTitle.Text = "Đang trống";
            // 
            // cardTotalRooms
            // 
            cardTotalRooms.Anchor = AnchorStyles.None;
            cardTotalRooms.BackColor = Color.White;
            cardTotalRooms.BorderStyle = BorderStyle.FixedSingle;
            cardTotalRooms.Controls.Add(lblTotalRoomsValue);
            cardTotalRooms.Controls.Add(lblTotalRoomsTitle);
            cardTotalRooms.Location = new Point(96, 58);
            cardTotalRooms.Margin = new Padding(5);
            cardTotalRooms.Name = "cardTotalRooms";
            cardTotalRooms.Padding = new Padding(15);
            cardTotalRooms.Size = new Size(200, 125);
            cardTotalRooms.TabIndex = 0;
            // 
            // lblTotalRoomsValue
            // 
            lblTotalRoomsValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalRoomsValue.AutoSize = true;
            lblTotalRoomsValue.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lblTotalRoomsValue.Location = new Point(15, 50);
            lblTotalRoomsValue.Margin = new Padding(0);
            lblTotalRoomsValue.Name = "lblTotalRoomsValue";
            lblTotalRoomsValue.Size = new Size(38, 40);
            lblTotalRoomsValue.TabIndex = 1;
            lblTotalRoomsValue.Text = "0";
            // 
            // lblTotalRoomsTitle
            // 
            lblTotalRoomsTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalRoomsTitle.AutoSize = true;
            lblTotalRoomsTitle.Font = new Font("Microsoft Sans Serif", 9F);
            lblTotalRoomsTitle.ForeColor = Color.Gray;
            lblTotalRoomsTitle.Location = new Point(15, 15);
            lblTotalRoomsTitle.Margin = new Padding(0);
            lblTotalRoomsTitle.Name = "lblTotalRoomsTitle";
            lblTotalRoomsTitle.Size = new Size(131, 22);
            lblTotalRoomsTitle.TabIndex = 0;
            lblTotalRoomsTitle.Text = "Tổng số phòng";
            // 
            // pnlCharts
            // 
            pnlCharts.BackColor = Color.Transparent;
            pnlCharts.Controls.Add(chartTrend);
            pnlCharts.Controls.Add(chartOccupancyByBuilding);
            pnlCharts.Controls.Add(chartOccupancyPie);
            pnlCharts.Dock = DockStyle.Top;
            pnlCharts.Location = new Point(0, 327);
            pnlCharts.Margin = new Padding(4, 5, 4, 5);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Padding = new Padding(27, 15, 27, 15);
            pnlCharts.Size = new Size(1467, 507);
            pnlCharts.TabIndex = 2;
            // 
            // chartTrend
            // 
            chartTrend.Anchor = AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            chartTrend.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartTrend.Legends.Add(legend1);
            chartTrend.Location = new Point(1045, 76);
            chartTrend.Margin = new Padding(5);
            chartTrend.Name = "chartTrend";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Trend";
            chartTrend.Series.Add(series1);
            chartTrend.Size = new Size(449, 354);
            chartTrend.TabIndex = 2;
            chartTrend.Text = "Trend";
            // 
            // chartOccupancyByBuilding
            // 
            chartOccupancyByBuilding.Anchor = AnchorStyles.None;
            chartArea2.Name = "ChartArea1";
            chartOccupancyByBuilding.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartOccupancyByBuilding.Legends.Add(legend2);
            chartOccupancyByBuilding.Location = new Point(499, 76);
            chartOccupancyByBuilding.Margin = new Padding(5);
            chartOccupancyByBuilding.Name = "chartOccupancyByBuilding";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "Legend1";
            series2.Name = "ByBuilding";
            chartOccupancyByBuilding.Series.Add(series2);
            chartOccupancyByBuilding.Size = new Size(512, 354);
            chartOccupancyByBuilding.TabIndex = 1;
            chartOccupancyByBuilding.Text = "ByBuilding";
            // 
            // chartOccupancyPie
            // 
            chartOccupancyPie.Anchor = AnchorStyles.None;
            chartArea3.Name = "ChartArea1";
            chartOccupancyPie.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartOccupancyPie.Legends.Add(legend3);
            chartOccupancyPie.Location = new Point(44, 76);
            chartOccupancyPie.Margin = new Padding(5);
            chartOccupancyPie.Name = "chartOccupancyPie";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Occupancy";
            chartOccupancyPie.Series.Add(series3);
            chartOccupancyPie.Size = new Size(418, 354);
            chartOccupancyPie.TabIndex = 0;
            chartOccupancyPie.Text = "Occupancy";
            // 
            // pnlPendingContracts
            // 
            pnlPendingContracts.BackColor = Color.White;
            pnlPendingContracts.BorderStyle = BorderStyle.FixedSingle;
            pnlPendingContracts.Controls.Add(dgvPendingContracts);
            pnlPendingContracts.Controls.Add(pnlSearchContracts);
            pnlPendingContracts.Dock = DockStyle.Top;
            pnlPendingContracts.Location = new Point(0, 834);
            pnlPendingContracts.Margin = new Padding(4, 5, 4, 5);
            pnlPendingContracts.Name = "pnlPendingContracts";
            pnlPendingContracts.Padding = new Padding(20, 23, 20, 23);
            pnlPendingContracts.Size = new Size(1467, 460);
            pnlPendingContracts.TabIndex = 3;
            // 
            // dgvPendingContracts
            // 
            dgvPendingContracts.AllowUserToAddRows = false;
            dgvPendingContracts.AllowUserToDeleteRows = false;
            dgvPendingContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendingContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendingContracts.Dock = DockStyle.Fill;
            dgvPendingContracts.Location = new Point(20, 77);
            dgvPendingContracts.Margin = new Padding(4, 5, 4, 5);
            dgvPendingContracts.MultiSelect = false;
            dgvPendingContracts.Name = "dgvPendingContracts";
            dgvPendingContracts.ReadOnly = true;
            dgvPendingContracts.RowHeadersWidth = 51;
            dgvPendingContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendingContracts.Size = new Size(1425, 358);
            dgvPendingContracts.TabIndex = 0;
            dgvPendingContracts.CellContentClick += dgvPendingContracts_CellContentClick;
            // 
            // pnlSearchContracts
            // 
            pnlSearchContracts.Controls.Add(btnSearchContracts);
            pnlSearchContracts.Controls.Add(lblPendingContractsTitle);
            pnlSearchContracts.Controls.Add(txtSearchContracts);
            pnlSearchContracts.Dock = DockStyle.Top;
            pnlSearchContracts.Location = new Point(20, 23);
            pnlSearchContracts.Margin = new Padding(4, 5, 4, 5);
            pnlSearchContracts.Name = "pnlSearchContracts";
            pnlSearchContracts.Size = new Size(1425, 54);
            pnlSearchContracts.TabIndex = 2;
            // 
            // btnSearchContracts
            // 
            btnSearchContracts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchContracts.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnSearchContracts.Location = new Point(1344, 7);
            btnSearchContracts.Margin = new Padding(4, 5, 4, 5);
            btnSearchContracts.Name = "btnSearchContracts";
            btnSearchContracts.Size = new Size(77, 42);
            btnSearchContracts.TabIndex = 1;
            btnSearchContracts.Text = "Tìm";
            btnSearchContracts.UseVisualStyleBackColor = true;
            btnSearchContracts.Click += btnSearchContracts_Click;
            // 
            // lblPendingContractsTitle
            // 
            lblPendingContractsTitle.AutoSize = true;
            lblPendingContractsTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblPendingContractsTitle.Location = new Point(6, 12);
            lblPendingContractsTitle.Margin = new Padding(4, 0, 4, 0);
            lblPendingContractsTitle.Name = "lblPendingContractsTitle";
            lblPendingContractsTitle.Size = new Size(246, 29);
            lblPendingContractsTitle.TabIndex = 1;
            lblPendingContractsTitle.Text = "Hợp đồng chờ duyệt";
            // 
            // txtSearchContracts
            // 
            txtSearchContracts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchContracts.Font = new Font("Microsoft Sans Serif", 10F);
            txtSearchContracts.Location = new Point(1106, 15);
            txtSearchContracts.Margin = new Padding(4, 5, 4, 5);
            txtSearchContracts.Name = "txtSearchContracts";
            txtSearchContracts.PlaceholderText = "Tìm kiếm theo mã SV hoặc số phòng...";
            txtSearchContracts.Size = new Size(228, 30);
            txtSearchContracts.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.Transparent;
            pnlBottom.Controls.Add(pnlRecentActivity);
            pnlBottom.Controls.Add(pnlAlerts);
            pnlBottom.Controls.Add(pnlQuickActions);
            pnlBottom.Dock = DockStyle.Top;
            pnlBottom.Location = new Point(0, 1294);
            pnlBottom.Margin = new Padding(4, 5, 4, 5);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(27, 15, 27, 31);
            pnlBottom.Size = new Size(1467, 385);
            pnlBottom.TabIndex = 4;
            // 
            // pnlRecentActivity
            // 
            pnlRecentActivity.BackColor = Color.White;
            pnlRecentActivity.BorderStyle = BorderStyle.FixedSingle;
            pnlRecentActivity.Controls.Add(lstRecentActivity);
            pnlRecentActivity.Controls.Add(lblRecentActivityTitle);
            pnlRecentActivity.Dock = DockStyle.Fill;
            pnlRecentActivity.Location = new Point(759, 15);
            pnlRecentActivity.Margin = new Padding(4, 5, 4, 5);
            pnlRecentActivity.Name = "pnlRecentActivity";
            pnlRecentActivity.Padding = new Padding(20, 23, 20, 23);
            pnlRecentActivity.Size = new Size(681, 339);
            pnlRecentActivity.TabIndex = 2;
            // 
            // lstRecentActivity
            // 
            lstRecentActivity.BorderStyle = BorderStyle.None;
            lstRecentActivity.Dock = DockStyle.Fill;
            lstRecentActivity.Font = new Font("Microsoft Sans Serif", 10F);
            lstRecentActivity.FormattingEnabled = true;
            lstRecentActivity.ItemHeight = 25;
            lstRecentActivity.Location = new Point(20, 23);
            lstRecentActivity.Margin = new Padding(4, 5, 4, 5);
            lstRecentActivity.Name = "lstRecentActivity";
            lstRecentActivity.Size = new Size(639, 291);
            lstRecentActivity.TabIndex = 1;
            // 
            // lblRecentActivityTitle
            // 
            lblRecentActivityTitle.AutoSize = true;
            lblRecentActivityTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblRecentActivityTitle.Location = new Point(20, 23);
            lblRecentActivityTitle.Margin = new Padding(4, 0, 4, 0);
            lblRecentActivityTitle.Name = "lblRecentActivityTitle";
            lblRecentActivityTitle.Size = new Size(231, 29);
            lblRecentActivityTitle.TabIndex = 0;
            lblRecentActivityTitle.Text = "Hoạt động gần đây";
            // 
            // pnlAlerts
            // 
            pnlAlerts.BackColor = Color.White;
            pnlAlerts.BorderStyle = BorderStyle.FixedSingle;
            pnlAlerts.Controls.Add(lstAlerts);
            pnlAlerts.Controls.Add(lblAlertsTitle);
            pnlAlerts.Dock = DockStyle.Left;
            pnlAlerts.Location = new Point(293, 15);
            pnlAlerts.Margin = new Padding(4, 5, 4, 5);
            pnlAlerts.Name = "pnlAlerts";
            pnlAlerts.Padding = new Padding(20, 23, 20, 23);
            pnlAlerts.Size = new Size(466, 339);
            pnlAlerts.TabIndex = 1;
            // 
            // lstAlerts
            // 
            lstAlerts.BorderStyle = BorderStyle.None;
            lstAlerts.Dock = DockStyle.Fill;
            lstAlerts.Font = new Font("Microsoft Sans Serif", 10F);
            lstAlerts.FormattingEnabled = true;
            lstAlerts.ItemHeight = 25;
            lstAlerts.Location = new Point(20, 23);
            lstAlerts.Margin = new Padding(4, 5, 4, 5);
            lstAlerts.Name = "lstAlerts";
            lstAlerts.Size = new Size(424, 291);
            lstAlerts.TabIndex = 1;
            // 
            // lblAlertsTitle
            // 
            lblAlertsTitle.AutoSize = true;
            lblAlertsTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblAlertsTitle.Location = new Point(20, 23);
            lblAlertsTitle.Margin = new Padding(4, 0, 4, 0);
            lblAlertsTitle.Name = "lblAlertsTitle";
            lblAlertsTitle.Size = new Size(124, 29);
            lblAlertsTitle.TabIndex = 0;
            lblAlertsTitle.Text = "Cảnh báo";
            // 
            // pnlQuickActions
            // 
            pnlQuickActions.BackColor = Color.White;
            pnlQuickActions.BorderStyle = BorderStyle.FixedSingle;
            pnlQuickActions.Controls.Add(btnViewStats);
            pnlQuickActions.Controls.Add(btnAddViolation);
            pnlQuickActions.Controls.Add(btnAddPayment);
            pnlQuickActions.Controls.Add(btnAddRoom);
            pnlQuickActions.Controls.Add(lblQuickActionsTitle);
            pnlQuickActions.Dock = DockStyle.Left;
            pnlQuickActions.Location = new Point(27, 15);
            pnlQuickActions.Margin = new Padding(4, 5, 4, 5);
            pnlQuickActions.Name = "pnlQuickActions";
            pnlQuickActions.Padding = new Padding(20, 23, 20, 23);
            pnlQuickActions.Size = new Size(266, 339);
            pnlQuickActions.TabIndex = 0;
            // 
            // btnViewStats
            // 
            btnViewStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnViewStats.Font = new Font("Segoe UI", 11F);
            btnViewStats.Location = new Point(20, 243);
            btnViewStats.Margin = new Padding(4, 5, 4, 5);
            btnViewStats.Name = "btnViewStats";
            btnViewStats.Size = new Size(204, 54);
            btnViewStats.TabIndex = 4;
            btnViewStats.Text = "Xem thống kê chi tiết";
            btnViewStats.UseVisualStyleBackColor = true;
            btnViewStats.Click += btnViewStats_Click;
            // 
            // btnAddViolation
            // 
            btnAddViolation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAddViolation.Font = new Font("Segoe UI", 11F);
            btnAddViolation.Location = new Point(20, 179);
            btnAddViolation.Margin = new Padding(4, 5, 4, 5);
            btnAddViolation.Name = "btnAddViolation";
            btnAddViolation.Size = new Size(204, 54);
            btnAddViolation.TabIndex = 3;
            btnAddViolation.Text = "Tạo vi phạm";
            btnAddViolation.UseVisualStyleBackColor = true;
            btnAddViolation.Click += btnAddViolation_Click;
            // 
            // btnAddPayment
            // 
            btnAddPayment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAddPayment.Font = new Font("Segoe UI", 11F);
            btnAddPayment.Location = new Point(20, 115);
            btnAddPayment.Margin = new Padding(4, 5, 4, 5);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(204, 54);
            btnAddPayment.TabIndex = 2;
            btnAddPayment.Text = "Ghi nhận thanh toán";
            btnAddPayment.UseVisualStyleBackColor = true;
            btnAddPayment.Click += btnAddPayment_Click;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAddRoom.Font = new Font("Segoe UI", 11F);
            btnAddRoom.Location = new Point(20, 51);
            btnAddRoom.Margin = new Padding(4, 5, 4, 5);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(204, 54);
            btnAddRoom.TabIndex = 1;
            btnAddRoom.Text = "+ Thêm phòng";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // lblQuickActionsTitle
            // 
            lblQuickActionsTitle.AutoSize = true;
            lblQuickActionsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQuickActionsTitle.Location = new Point(13, 9);
            lblQuickActionsTitle.Margin = new Padding(4, 0, 4, 0);
            lblQuickActionsTitle.Name = "lblQuickActionsTitle";
            lblQuickActionsTitle.Size = new Size(189, 32);
            lblQuickActionsTitle.TabIndex = 0;
            lblQuickActionsTitle.Text = "Thao tác nhanh";
            // 
            // scrollPanel
            // 
            scrollPanel.AutoScroll = true;
            scrollPanel.Dock = DockStyle.Fill;
            scrollPanel.Location = new Point(0, 0);
            scrollPanel.Name = "scrollPanel";
            scrollPanel.Size = new Size(1000, 700);
            scrollPanel.TabIndex = 5;
            // 
            // ucDashboard
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            BackColor = Color.FromArgb(248, 249, 253);
            Controls.Add(pnlBottom);
            Controls.Add(pnlPendingContracts);
            Controls.Add(pnlCharts);
            Controls.Add(pnlKPICards);
            Controls.Add(pnlHeader);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ucDashboard";
            Size = new Size(1467, 1072);
            Load += ucDashboard_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlKPICards.ResumeLayout(false);
            cardViolations.ResumeLayout(false);
            cardViolations.PerformLayout();
            cardRevenue.ResumeLayout(false);
            cardRevenue.PerformLayout();
            cardPending.ResumeLayout(false);
            cardPending.PerformLayout();
            cardOccupied.ResumeLayout(false);
            cardOccupied.PerformLayout();
            cardAvailable.ResumeLayout(false);
            cardAvailable.PerformLayout();
            cardTotalRooms.ResumeLayout(false);
            cardTotalRooms.PerformLayout();
            pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartOccupancyByBuilding).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartOccupancyPie).EndInit();
            pnlPendingContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPendingContracts).EndInit();
            pnlSearchContracts.ResumeLayout(false);
            pnlSearchContracts.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlRecentActivity.ResumeLayout(false);
            pnlRecentActivity.PerformLayout();
            pnlAlerts.ResumeLayout(false);
            pnlAlerts.PerformLayout();
            pnlQuickActions.ResumeLayout(false);
            pnlQuickActions.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.ComboBox cmbBuilding;
        private System.Windows.Forms.ComboBox cmbTimeRange;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlKPICards;
        private System.Windows.Forms.Panel cardTotalRooms;
        private System.Windows.Forms.Label lblTotalRoomsTitle;
        private System.Windows.Forms.Label lblTotalRoomsValue;
        private System.Windows.Forms.Panel cardAvailable;
        private System.Windows.Forms.Label lblAvailableTitle;
        private System.Windows.Forms.Label lblAvailableValue;
        private System.Windows.Forms.Panel cardOccupied;
        private System.Windows.Forms.Label lblOccupiedTitle;
        private System.Windows.Forms.Label lblOccupiedValue;
        private System.Windows.Forms.Panel cardPending;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Label lblPendingValue;
        private System.Windows.Forms.Button btnReviewNow;
        private System.Windows.Forms.Panel cardRevenue;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Panel cardViolations;
        private System.Windows.Forms.Label lblViolationsTitle;
        private System.Windows.Forms.Label lblViolationsValue;
        private System.Windows.Forms.Panel pnlCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOccupancyPie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOccupancyByBuilding;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrend;
        private System.Windows.Forms.Panel pnlPendingContracts;
        private System.Windows.Forms.DataGridView dgvPendingContracts;
        private System.Windows.Forms.Label lblPendingContractsTitle;
        private System.Windows.Forms.Panel pnlSearchContracts;
        private System.Windows.Forms.Button btnSearchContracts;
        private System.Windows.Forms.TextBox txtSearchContracts;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlQuickActions;
        private System.Windows.Forms.Label lblQuickActionsTitle;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnAddViolation;
        private System.Windows.Forms.Button btnViewStats;
        private System.Windows.Forms.Panel pnlAlerts;
        private System.Windows.Forms.Label lblAlertsTitle;
        private System.Windows.Forms.ListBox lstAlerts;
        private System.Windows.Forms.Panel pnlRecentActivity;
        private System.Windows.Forms.Label lblRecentActivityTitle;
        private System.Windows.Forms.ListBox lstRecentActivity;
        private System.Windows.Forms.Panel scrollPanel;
    }
}
