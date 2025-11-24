using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucDashboard : UserControl
    {
        private Form? mainForm;

        public ucDashboard()
        {
            InitializeComponent();
            SetupCharts();
            this.Resize += UcDashboard_Resize;
            this.Layout += UcDashboard_Layout;
        }

        private void UcDashboard_Layout(object? sender, LayoutEventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                ArrangeKPICards();
                ArrangeCharts();
                ArrangeSearchControls();
            }
        }

        private void UcDashboard_Resize(object? sender, EventArgs e)
        {
            ArrangeKPICards();
            ArrangeCharts();
            ArrangeSearchControls();
        }

        private void ArrangeKPICards()
        {
            if (pnlKPICards == null) return;

            const int padding = 20;
            const int cardHeight = 125;
            const int cardSpacing = 10;
            const int cardCount = 6;
            const int minCardWidth = 150;
            const int maxCardWidth = 200;

            var (cardWidth, startX) = CalculateCardLayout(pnlKPICards.ClientSize.Width, padding, cardSpacing, cardCount, minCardWidth, maxCardWidth);
            int y = padding;
            const int cardPadding = 15;

            // Arrange all cards
            ArrangeCard(cardTotalRooms, lblTotalRoomsTitle, lblTotalRoomsValue, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardAvailable, lblAvailableTitle, lblAvailableValue, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardOccupied, lblOccupiedTitle, lblOccupiedValue, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardPending, lblPendingTitle, lblPendingValue, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardRevenue, lblRevenueTitle, lblRevenueValue, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardViolations, lblViolationsTitle, lblViolationsValue, startX, y, cardWidth, cardHeight, cardPadding);
        }

        private static (int cardWidth, int startX) CalculateCardLayout(int panelWidth, int padding, int cardSpacing, int cardCount, int minWidth, int maxWidth)
        {
            int availableWidth = panelWidth - (padding * 2);
            int spaces = cardCount - 1;
            int calculatedCardWidth = Math.Max(minWidth, Math.Min(maxWidth, (availableWidth - (cardSpacing * spaces)) / cardCount));

            int totalWidth = (calculatedCardWidth * cardCount) + (cardSpacing * spaces);
            if (totalWidth > availableWidth)
            {
                calculatedCardWidth = (availableWidth - (cardSpacing * spaces)) / cardCount;
                totalWidth = (calculatedCardWidth * cardCount) + (cardSpacing * spaces);
            }

            int startX = padding;
            if (totalWidth < availableWidth)
            {
                startX = padding + ((availableWidth - totalWidth) / 2);
            }

            return (calculatedCardWidth, startX);
        }

        private static void ArrangeCard(Panel card, Label lblTitle, Label lblValue, int x, int y, int width, int height, int padding)
        {
            card.Location = new Point(x, y);
            card.Size = new Size(width, height);
            lblTitle.Location = new Point(padding, padding);
            lblValue.Location = new Point(padding, padding + 35);
        }

        private void ArrangeCharts()
        {
            if (pnlCharts == null) return;

            int padding = 27;
            int chartHeight = 354;
            int chartSpacing = 10;
            int panelWidth = pnlCharts.ClientSize.Width - (padding * 2);
            
            // Tính toán kích thước chart để vừa với panel (3 charts)
            int availableWidth = panelWidth - (chartSpacing * 2); // 2 spaces between 3 charts
            int calculatedChartWidth = Math.Max(300, Math.Min(400, availableWidth / 3)); // Min 300px, Max 400px per chart

            // Nếu tổng chiều rộng vượt quá, điều chỉnh lại
            int totalWidth = (calculatedChartWidth * 3) + (chartSpacing * 2);
            if (totalWidth > panelWidth)
            {
                calculatedChartWidth = (panelWidth - (chartSpacing * 2)) / 3;
            }

            // Căn giữa các charts nếu còn dư không gian
            int startX = padding;
            if (totalWidth < panelWidth)
            {
                int extraSpace = panelWidth - totalWidth;
                startX = padding + (extraSpace / 2);
            }

            int y = 15; // Top padding

            // Arrange all charts
            chartOccupancyPie.Location = new Point(startX, y);
            chartOccupancyPie.Size = new Size(calculatedChartWidth, chartHeight);
            startX += calculatedChartWidth + chartSpacing;

            chartOccupancyByBuilding.Location = new Point(startX, y);
            chartOccupancyByBuilding.Size = new Size(calculatedChartWidth, chartHeight);
            startX += calculatedChartWidth + chartSpacing;

            chartTrend.Location = new Point(startX, y);
            chartTrend.Size = new Size(calculatedChartWidth, chartHeight);
        }

        private void ArrangeSearchControls()
        {
            if (pnlSearchContracts == null || txtSearchContracts == null || btnSearchContracts == null || lblPendingContractsTitle == null) return;

            int padding = 6;
            int spacing = 10;
            int buttonWidth = 77;
            int buttonMargin = 4;
            int labelWidth = lblPendingContractsTitle.Width;
            
            // Tính toán vị trí và kích thước cho txtSearchContracts
            int labelRight = padding + labelWidth + spacing;
            int buttonLeft = pnlSearchContracts.ClientSize.Width - buttonWidth - buttonMargin;
            int availableWidth = buttonLeft - labelRight - spacing;
            
            // Đảm bảo txtSearchContracts có kích thước tối thiểu
            if (availableWidth > 200)
            {
                txtSearchContracts.Location = new Point(labelRight, txtSearchContracts.Location.Y);
                txtSearchContracts.Size = new Size(availableWidth, txtSearchContracts.Height);
            }
        }

        private async void ucDashboard_Load(object sender, EventArgs e)
        {
            this.mainForm = this.FindForm();
            cmbTimeRange.SelectedIndex = 2; // "Tháng này"
            cmbBuilding.SelectedIndex = 0; // "Tất cả tòa"
            
            await LoadDashboardData();
        }

        private void SetupCharts()
        {
            // Pie chart - Occupancy
            chartOccupancyPie.Series.Clear();
            var pieSeries = chartOccupancyPie.Series.Add("Occupancy");
            pieSeries.ChartType = SeriesChartType.Doughnut;
            pieSeries["PieLabelStyle"] = "Outside";
            pieSeries["PieLineColor"] = "Black";
            chartOccupancyPie.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartOccupancyPie.Legends[0].Docking = Docking.Bottom;

            // Bar chart - By Building
            chartOccupancyByBuilding.Series.Clear();
            var barSeries = chartOccupancyByBuilding.Series.Add("Occupied");
            barSeries.ChartType = SeriesChartType.Bar;
            barSeries.Color = Theme.Primary;
            var barSeries2 = chartOccupancyByBuilding.Series.Add("Capacity");
            barSeries2.ChartType = SeriesChartType.Bar;
            barSeries2.Color = Theme.Success;
            chartOccupancyByBuilding.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartOccupancyByBuilding.ChartAreas[0].AxisY.MajorGrid.Enabled = true;

            // Line chart - Trend
            chartTrend.Series.Clear();
            var lineSeries = chartTrend.Series.Add("New Contracts");
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.Color = Theme.Primary;
            lineSeries.BorderWidth = 3;
            lineSeries.MarkerStyle = MarkerStyle.Circle;
            lineSeries.MarkerSize = 8;
            chartTrend.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartTrend.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
        }

        private async Task LoadDashboardData()
        {
            UiHelper.ShowLoading(this);
            try
            {
                // Load KPI data
                var kpiData = await ApiService.GetDashboardKPIsAsync(
                    cmbBuilding.SelectedIndex > 0 ? cmbBuilding.SelectedItem?.ToString() : null,
                    GetDateRange()
                );

                if (kpiData != null)
                {
                    UpdateKPICards(kpiData);
                }

                // Load pending contracts
                await LoadPendingContracts();

                // Load charts data
                await LoadChartsData();

                // Load alerts
                await LoadAlerts();

                // Load recent activity
                await LoadRecentActivity();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu dashboard: {ex.Message}");
            }
            finally
            {
                UiHelper.HideLoading(this);
            }
        }

        private void UpdateKPICards(DashboardKpiResponse kpi)
        {
            lblTotalRoomsValue.Text = kpi.RoomsTotal.ToString();
            lblAvailableValue.Text = kpi.RoomsAvailable.ToString();
            lblOccupiedValue.Text = kpi.RoomsOccupied.ToString();
            lblPendingValue.Text = kpi.ContractsPending.ToString();
            lblRevenueValue.Text = FormatCurrency(kpi.PaymentsThisMonth);
            lblViolationsValue.Text = kpi.ViolationsOpen.ToString();
        }

        private async Task LoadPendingContracts()
        {
            try
            {
                var contracts = await ApiService.GetPendingContractsAsync(txtSearchContracts.Text);
                
                dgvPendingContracts.Rows.Clear();
                dgvPendingContracts.Columns.Clear();

                // Setup columns
                dgvPendingContracts.Columns.Add("Student", "Sinh viên");
                dgvPendingContracts.Columns.Add("Room", "Phòng");
                dgvPendingContracts.Columns.Add("Start", "Bắt đầu");
                dgvPendingContracts.Columns.Add("End", "Kết thúc");
                dgvPendingContracts.Columns.Add("MonthlyFee", "Phí/tháng");
                dgvPendingContracts.Columns.Add("SubmittedAt", "Ngày nộp");
                
                // Add action buttons column
                var approveCol = new DataGridViewButtonColumn
                {
                    Name = "Approve",
                    Text = "Duyệt",
                    UseColumnTextForButtonValue = true,
                    Width = 70
                };
                var rejectCol = new DataGridViewButtonColumn
                {
                    Name = "Reject",
                    Text = "Từ chối",
                    UseColumnTextForButtonValue = true,
                    Width = 70
                };
                dgvPendingContracts.Columns.Add(approveCol);
                dgvPendingContracts.Columns.Add(rejectCol);

                if (contracts != null)
                {
                    foreach (var contract in contracts)
                    {
                        dgvPendingContracts.Rows.Add(
                            contract.StudentCode,
                            contract.RoomNumber,
                            contract.StartDate.ToString("dd/MM/yyyy"),
                            contract.EndDate.ToString("dd/MM/yyyy"),
                            FormatCurrency(contract.MonthlyFee),
                            contract.SubmittedAt.ToString("dd/MM/yyyy HH:mm"),
                            "Duyệt",
                            "Từ chối"
                        );
                    }
                }

                dgvPendingContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải hợp đồng chờ duyệt: {ex.Message}");
            }
        }

        private async Task LoadChartsData()
        {
            try
            {
                var chartData = await ApiService.GetDashboardChartsDataAsync(
                    cmbBuilding.SelectedIndex > 0 ? cmbBuilding.SelectedItem?.ToString() : null,
                    GetDateRange()
                );

                // Clear all charts
                chartOccupancyPie.Series["Occupancy"].Points.Clear();
                chartOccupancyByBuilding.Series["Occupied"].Points.Clear();
                chartOccupancyByBuilding.Series["Capacity"].Points.Clear();
                chartTrend.Series["New Contracts"].Points.Clear();

                if (chartData != null && chartData.OccupiedCount > 0 && chartData.AvailableCount > 0)
                {
                    // Update Pie chart
                    chartOccupancyPie.Series["Occupancy"].Points.AddXY("Đang ở", chartData.OccupiedCount);
                    chartOccupancyPie.Series["Occupancy"].Points.AddXY("Trống", chartData.AvailableCount);
                    chartOccupancyPie.Series["Occupancy"].Points[0].Color = Theme.Primary;
                    chartOccupancyPie.Series["Occupancy"].Points[1].Color = Theme.Success;

                    // Update Bar chart
                    if (chartData.OccupancyByBuilding != null && chartData.OccupancyByBuilding.Count > 0)
                    {
                        foreach (var item in chartData.OccupancyByBuilding)
                        {
                            chartOccupancyByBuilding.Series["Occupied"].Points.AddXY(item.Building, item.Occupied);
                            chartOccupancyByBuilding.Series["Capacity"].Points.AddXY(item.Building, item.Capacity);
                        }
                    }

                    // Update Trend chart
                    if (chartData.ContractsByWeek != null && chartData.ContractsByWeek.Count > 0)
                    {
                        foreach (var item in chartData.ContractsByWeek)
                        {
                            chartTrend.Series["New Contracts"].Points.AddXY(item.Week, item.Count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu biểu đồ: {ex.Message}");
            }
        }

        private async Task LoadAlerts()
        {
            try
            {
                var alerts = await ApiService.GetDashboardAlertsAsync();
                lstAlerts.Items.Clear();

                if (alerts != null && alerts.Count > 0)
                {
                    foreach (var alert in alerts)
                    {
                        lstAlerts.Items.Add($"[{alert.Type}] {alert.Message} - {alert.Date:dd/MM/yyyy}");
                    }
                }
                else
                {
                    lstAlerts.Items.Add("Không có cảnh báo nào");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải cảnh báo: {ex.Message}");
            }
        }

        private async Task LoadRecentActivity()
        {
            try
            {
                var activities = await ApiService.GetRecentActivityAsync(20);
                lstRecentActivity.Items.Clear();

                if (activities != null && activities.Count > 0)
                {
                    foreach (var activity in activities)
                    {
                        lstRecentActivity.Items.Add($"[{activity.Time:HH:mm}] {activity.Description}");
                    }
                }
                else
                {
                    lstRecentActivity.Items.Add("Chưa có hoạt động nào");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải hoạt động gần đây: {ex.Message}");
            }
        }

        private DateTime[] GetDateRange()
        {
            var now = DateTime.Now;
            DateTime from, to = now;

            switch (cmbTimeRange.SelectedIndex)
            {
                case 0: // Hôm nay
                    from = now.Date;
                    break;
                case 1: // Tuần này
                    from = now.AddDays(-(int)now.DayOfWeek);
                    break;
                case 2: // Tháng này
                    from = new DateTime(now.Year, now.Month, 1);
                    break;
                case 3: // 3 tháng
                    from = now.AddMonths(-3);
                    break;
                case 4: // 6 tháng
                    from = now.AddMonths(-6);
                    break;
                case 5: // Năm nay
                    from = new DateTime(now.Year, 1, 1);
                    break;
                default:
                    from = new DateTime(now.Year, now.Month, 1);
                    break;
            }

            return new[] { from, to };
        }

        private string FormatCurrency(decimal amount)
        {
            if (amount == 0)
                return "0đ";
            if (amount >= 1000000)
                return $"{amount / 1000000:F1}M";
            else if (amount >= 1000)
                return $"{amount / 1000:F0}K";
            else
                return $"{amount:F0}đ";
        }

        // Event handlers
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDashboardData();
        }

        private async void cmbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDashboardData();
        }

        private async void cmbTimeRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDashboardData();
        }

        private async void btnSearchContracts_Click(object sender, EventArgs e)
        {
            await LoadPendingContracts();
        }

        private async void dgvPendingContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Columns[e.ColumnIndex].Name == "Approve")
            {
                var contractId = dgv.Rows[e.RowIndex].Cells["Student"].Value?.ToString();
                if (await ApiService.ApproveContractAsync(contractId ?? ""))
                {
                    UiHelper.ShowSuccess(this.mainForm, "Duyệt hợp đồng thành công!");
                    await LoadPendingContracts();
                    await LoadDashboardData();
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "Reject")
            {
                var contractId = dgv.Rows[e.RowIndex].Cells["Student"].Value?.ToString();
                if (await ApiService.RejectContractAsync(contractId ?? ""))
                {
                    UiHelper.ShowSuccess(this.mainForm, "Từ chối hợp đồng thành công!");
                    await LoadPendingContracts();
                    await LoadDashboardData();
                }
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            // Navigate to Room Management - trigger button click programmatically
            var mainMenu = this.mainForm as Forms.mainMenu;
            if (mainMenu != null)
            {
                var btnRoom = mainMenu.Controls.Find("btnRoom", true).FirstOrDefault() as Button;
                btnRoom?.PerformClick();
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            // Navigate to Payment Management
            var mainMenu = this.mainForm as Forms.mainMenu;
            if (mainMenu != null)
            {
                var btnPayment = mainMenu.Controls.Find("btnPayment", true).FirstOrDefault() as Button;
                btnPayment?.PerformClick();
            }
        }

        private void btnAddViolation_Click(object sender, EventArgs e)
        {
            // Navigate to Violation Management
            var mainMenu = this.mainForm as Forms.mainMenu;
            if (mainMenu != null)
            {
                var btnViolation = mainMenu.Controls.Find("btnViolation", true).FirstOrDefault() as Button;
                btnViolation?.PerformClick();
            }
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            // Navigate to Statistics
            var mainMenu = this.mainForm as Forms.mainMenu;
            if (mainMenu != null)
            {
                var btnStatistics = mainMenu.Controls.Find("btnStatistics", true).FirstOrDefault() as Button;
                btnStatistics?.PerformClick();
            }
        }

        private void btnReviewNow_Click(object sender, EventArgs e)
        {
            // Navigate to Contracts Management
            var mainMenu = this.mainForm as Forms.mainMenu;
            if (mainMenu != null)
            {
                var btnContract = mainMenu.Controls.Find("btnContract", true).FirstOrDefault() as Button;
                btnContract?.PerformClick();
            }
        }
    }
}
