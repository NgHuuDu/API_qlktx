using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucDashboard : UserControl
    {
        private Form? mainForm;
        private bool isLoading = false;
        private CancellationTokenSource? cancellationTokenSource;
        private System.Threading.Timer? refreshTimer;
        private System.Threading.Timer? buildingChangeTimer;
        private System.Threading.Timer? timeRangeChangeTimer;
        private System.Threading.Timer? searchTimer;

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
            // Tăng max width để phù hợp với fullscreen
            int maxCardWidth = Math.Max(200, (pnlKPICards.ClientSize.Width - (padding * 2) - (cardSpacing * (cardCount - 1))) / cardCount);

            var (cardWidth, startX) = CalculateCardLayout(pnlKPICards.ClientSize.Width, padding, cardSpacing, cardCount, minCardWidth, maxCardWidth);
            int y = padding;
            const int cardPadding = 15;

            // Sắp xếp tất cả các thẻ
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
            // Tăng chart height khi fullscreen
            int panelHeight = pnlCharts.ClientSize.Height;
            int chartHeight = Math.Max(354, panelHeight - 30); 
            int chartSpacing = 10;
            int panelWidth = pnlCharts.ClientSize.Width - (padding * 2);
            
            // Tính toán kích thước chart để vừa với panel (2 charts)
            int availableWidth = panelWidth - chartSpacing; // 1 space between 2 charts
            int minChartWidth = 300;
            // Bỏ max width limit, để charts scale theo available space
            int calculatedChartWidth = Math.Max(minChartWidth, availableWidth / 2);

            // Đảm bảo không vượt quá available width
            int totalWidth = (calculatedChartWidth * 2) + chartSpacing;
            if (totalWidth > panelWidth)
            {
                calculatedChartWidth = (panelWidth - chartSpacing) / 2;
            }

            // Căn giữa các charts nếu còn dư không gian
            int startX = padding;
            if (totalWidth < panelWidth)
            {
                int extraSpace = panelWidth - totalWidth;
                startX = padding + (extraSpace / 2);
            }

            int y = 15; 

            // Sắp xếp tất cả các biểu đồ
            chartOccupancyPie.Location = new Point(startX, y);
            chartOccupancyPie.Size = new Size(calculatedChartWidth, chartHeight);
            startX += calculatedChartWidth + chartSpacing;

            chartOccupancyByBuilding.Location = new Point(startX, y);
            chartOccupancyByBuilding.Size = new Size(calculatedChartWidth, chartHeight);
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
            if (chartOccupancyPie != null)
            {
                chartOccupancyPie.Series.Clear();
                
                if (chartOccupancyPie.ChartAreas.Count == 0)
                    chartOccupancyPie.ChartAreas.Add(new ChartArea());
                if (chartOccupancyPie.Legends.Count == 0)
                    chartOccupancyPie.Legends.Add(new Legend());
                
                var pieSeries = chartOccupancyPie.Series.Add("Occupancy");
                pieSeries.ChartType = SeriesChartType.Doughnut;
                pieSeries["PieLabelStyle"] = "Outside";
                pieSeries["PieLineColor"] = "Black";
                if (chartOccupancyPie.ChartAreas.Count > 0)
                    chartOccupancyPie.ChartAreas[0].Area3DStyle.Enable3D = true;
                if (chartOccupancyPie.Legends.Count > 0)
                    chartOccupancyPie.Legends[0].Docking = Docking.Bottom;
            }

            // Bar chart - By Building
            if (chartOccupancyByBuilding != null)
            {
                chartOccupancyByBuilding.Series.Clear();
                
                if (chartOccupancyByBuilding.ChartAreas.Count == 0)
                    chartOccupancyByBuilding.ChartAreas.Add(new ChartArea());
                if (chartOccupancyByBuilding.Legends.Count == 0)
                    chartOccupancyByBuilding.Legends.Add(new Legend());
                
                var barSeries = chartOccupancyByBuilding.Series.Add("Đang ở");
                barSeries.ChartType = SeriesChartType.Bar;
                barSeries.Color = Theme.Primary;
                var barSeries2 = chartOccupancyByBuilding.Series.Add("Sức chứa");
                barSeries2.ChartType = SeriesChartType.Bar;
                barSeries2.Color = Theme.Success;
                if (chartOccupancyByBuilding.ChartAreas.Count > 0)
                {
                    chartOccupancyByBuilding.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chartOccupancyByBuilding.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                }
            }

        }

        private async Task LoadDashboardData()
        {
            // Ngăn chặn nhiều lần tải đồng thời
            if (isLoading) return;
            
            isLoading = true;
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            
            try
            {
                // Kiểm tra xem có bị hủy không
                if (token.IsCancellationRequested) return;
                
                var kpiData = await ApiService.GetDashboardKPIsAsync(
                    cmbBuilding.SelectedIndex > 0 ? cmbBuilding.SelectedItem?.ToString() : null,
                    GetDateRange()
                );

                if (token.IsCancellationRequested) return;

                if (kpiData != null)
                {
                    UpdateKPICards(kpiData);
                }

                await LoadPendingContracts();

                if (token.IsCancellationRequested) return;

                await LoadChartsData();

                if (token.IsCancellationRequested) return;

                await LoadAlerts();

                if (token.IsCancellationRequested) return;

                await LoadRecentActivity();
            }
            catch (OperationCanceledException)
            {
                // Bỏ qua hủy bỏ
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu dashboard: {ex.Message}");
                }
            }
            finally
            {
                isLoading = false;
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

                // Setup columns - Thêm cột ContractId  để lấy ID khi approve/reject
                var contractIdCol = new DataGridViewTextBoxColumn
                {
                    Name = "ContractId",
                    HeaderText = "ContractId",
                    Visible = true
                };
                dgvPendingContracts.Columns.Add(contractIdCol);
                
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
                            contract.ContractId,  
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
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải hợp đồng chờ duyệt: {ex.Message}");
                }
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

                // Kiểm tra null và ChartAreas trước khi truy cập Series
                if (chartOccupancyPie == null || chartOccupancyPie.Series["Occupancy"] == null || chartOccupancyPie.ChartAreas.Count == 0) return;
                if (chartOccupancyByBuilding == null || chartOccupancyByBuilding.Series["Đang ở"] == null || chartOccupancyByBuilding.Series["Sức chứa"] == null || chartOccupancyByBuilding.ChartAreas.Count == 0) return;

                // Xóa tất cả các biểu đồ
                chartOccupancyPie.Series["Occupancy"].Points.Clear();
                chartOccupancyByBuilding.Series["Đang ở"].Points.Clear();
                chartOccupancyByBuilding.Series["Sức chứa"].Points.Clear();

                if (chartData != null)
                {
                    // Cập nhật biểu đồ tròn - hiển thị ngay cả khi một trong hai giá trị = 0
                    if (chartData.OccupiedCount >= 0 && chartData.AvailableCount >= 0)
                {
                    chartOccupancyPie.Series["Occupancy"].Points.AddXY("Đang ở", chartData.OccupiedCount);
                    chartOccupancyPie.Series["Occupancy"].Points.AddXY("Trống", chartData.AvailableCount);
                        if (chartOccupancyPie.Series["Occupancy"].Points.Count > 0)
                        {
                    chartOccupancyPie.Series["Occupancy"].Points[0].Color = Theme.Primary;
                            if (chartOccupancyPie.Series["Occupancy"].Points.Count > 1)
                            {
                    chartOccupancyPie.Series["Occupancy"].Points[1].Color = Theme.Success;
                            }
                        }
                    }

                    // Cập nhật biểu đồ cột - không phụ thuộc vào biểu đồ tròn
                    if (chartData.OccupancyByBuilding != null && chartData.OccupancyByBuilding.Count > 0)
                    {
                        foreach (var item in chartData.OccupancyByBuilding)
                        {
                            chartOccupancyByBuilding.Series["Đang ở"].Points.AddXY(item.Building, item.Occupied);
                            chartOccupancyByBuilding.Series["Sức chứa"].Points.AddXY(item.Building, item.Capacity);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu biểu đồ: {ex.Message}");
                }
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
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải cảnh báo: {ex.Message}");
                }
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
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải hoạt động gần đây: {ex.Message}");
                }
            }
        }

        private DateTime[] GetDateRange()
        {
            var now = DateTime.Now;
            var to = now;

            var from = cmbTimeRange.SelectedIndex switch
            {
                0 => now.Date, // Hôm nay
                1 => now.AddDays(-(int)now.DayOfWeek), // Tuần này
                2 => new DateTime(now.Year, now.Month, 1), // Tháng này
                3 => now.AddMonths(-3), // 3 tháng
                4 => now.AddMonths(-6), // 6 tháng
                5 => new DateTime(now.Year, 1, 1), // Năm nay
                _ => new DateTime(now.Year, now.Month, 1) // Default: Tháng này
            };

            return new[] { from, to };
        }

        private static string FormatCurrency(decimal amount)
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
            if (btnRefresh != null)
            {
                btnRefresh.Enabled = false;
            }
            
            refreshTimer?.Dispose();
            refreshTimer = new System.Threading.Timer(_ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => 
        {
            await LoadDashboardData();
                        if (btnRefresh != null) btnRefresh.Enabled = true;
                    }));
                }
                else
                {
                    _ = LoadDashboardData().ContinueWith(_ =>
                    {
                        if (btnRefresh != null) btnRefresh.Enabled = true;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }, null, 300, Timeout.Infinite);
        }

        private void cmbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildingChangeTimer?.Dispose();
            buildingChangeTimer = new System.Threading.Timer(_ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => await LoadDashboardData()));
                }
                else
                {
                    _ = LoadDashboardData();
                }
            }, null, 500, Timeout.Infinite);
        }

        private void cmbTimeRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeRangeChangeTimer?.Dispose();
            timeRangeChangeTimer = new System.Threading.Timer(_ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => await LoadDashboardData()));
                }
                else
                {
                    _ = LoadDashboardData();
                }
            }, null, 500, Timeout.Infinite);
        }

        private void btnSearchContracts_Click(object sender, EventArgs e)
        {
            searchTimer?.Dispose();
            searchTimer = new System.Threading.Timer(_ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => await LoadPendingContracts()));
                }
                else
                {
                    _ = LoadPendingContracts();
                }
            }, null, 300, Timeout.Infinite);
        }

        private async void dgvPendingContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Columns[e.ColumnIndex].Name == "Approve")
            {
                var contractId = dgv.Rows[e.RowIndex].Cells["ContractId"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(contractId))
                {
                    if (this.mainForm != null)
                    {
                        UiHelper.ShowError(this.mainForm, "Không tìm thấy ID hợp đồng!");
                    }
                    return;
                }
                
                if (await ApiService.ApproveContractAsync(contractId))
                {
                    if (this.mainForm != null)
                    {
                        UiHelper.ShowSuccess(this.mainForm, "Duyệt hợp đồng thành công!");
                    }
                    await LoadPendingContracts();
                    await LoadDashboardData();
                }
                else
                {
                    if (this.mainForm != null)
                    {
                        UiHelper.ShowError(this.mainForm, "Duyệt hợp đồng thất bại!");
                    }
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "Reject")
            {
                var contractId = dgv.Rows[e.RowIndex].Cells["ContractId"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(contractId))
                {
                    if (this.mainForm != null)
                    {
                        UiHelper.ShowError(this.mainForm, "Không tìm thấy ID hợp đồng!");
                    }
                    return;
                }
                
                if (await ApiService.RejectContractAsync(contractId))
                {
                    if (this.mainForm != null)
                    {
                        UiHelper.ShowSuccess(this.mainForm, "Từ chối hợp đồng thành công!");
                    }
                    await LoadPendingContracts();
                    await LoadDashboardData();
                }
                else
                {
                    if (this.mainForm != null)
                    {
                        UiHelper.ShowError(this.mainForm, "Từ chối hợp đồng thất bại!");
                    }
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
