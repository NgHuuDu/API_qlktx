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
    public partial class ucStatistics : UserControl
    {
        private Form? mainForm;
        private bool isLoading = false;
        private CancellationTokenSource? cancellationTokenSource;
        private System.Threading.Timer? applyTimer;

        public ucStatistics()
        {
            InitializeComponent();
            SetupCharts();
        }

        private async void ucStatistics_Load(object sender, EventArgs e)
        {
            this.mainForm = this.FindForm();
            // Thiết lập ngày mặc định (tháng này)
            dtpDateFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDateTo.Value = DateTime.Now;
            // Load dữ liệu ban đầu
            await LoadStatisticsData();
        }

        private void SetupCharts()
        {
            // Chart Doanh thu
            if (chartRevenue != null)
            {
                if (chartRevenue.ChartAreas.Count == 0)
                    chartRevenue.ChartAreas.Add(new ChartArea());
                chartRevenue.Series.Clear();
                var seriesRevenue = chartRevenue.Series.Add("Doanh thu");
                seriesRevenue.ChartType = SeriesChartType.Line;
                seriesRevenue.XValueType = ChartValueType.String;
                seriesRevenue.BorderWidth = 3;
                seriesRevenue.Color = Theme.Primary;
            }

            // Chart Xu hướng lấp đầy
            if (chartOccupancyTrend != null)
            {
                if (chartOccupancyTrend.ChartAreas.Count == 0)
                    chartOccupancyTrend.ChartAreas.Add(new ChartArea());
                chartOccupancyTrend.Series.Clear();
                var seriesOccupancyTrend = chartOccupancyTrend.Series.Add("Tỷ lệ (%)");
                seriesOccupancyTrend.ChartType = SeriesChartType.Line;
                seriesOccupancyTrend.XValueType = ChartValueType.String;
                seriesOccupancyTrend.BorderWidth = 3;
                seriesOccupancyTrend.Color = Theme.Success;
                seriesOccupancyTrend.MarkerStyle = MarkerStyle.Circle;
                seriesOccupancyTrend.MarkerSize = 8;
                if (chartOccupancyTrend.ChartAreas.Count > 0)
                {
                    var chartArea = chartOccupancyTrend.ChartAreas[0];
                    chartArea.AxisY.Minimum = 0;
                    chartArea.AxisY.Maximum = 100;
                }
            }

            // Chart Tỉ lệ giới tính
            if (chartGender != null)
            {
                if (chartGender.ChartAreas.Count == 0)
                    chartGender.ChartAreas.Add(new ChartArea());
                if (chartGender.Legends.Count == 0)
                    chartGender.Legends.Add(new Legend());
                chartGender.Series.Clear();
                var seriesGender = chartGender.Series.Add("Giới tính");
                seriesGender.ChartType = SeriesChartType.Pie;
                seriesGender.XValueType = ChartValueType.String;
                seriesGender["PieLabelStyle"] = "Outside"; // Hiển thị label bên ngoài biểu đồ tròn
                if (chartGender.ChartAreas.Count > 0)
                {
                    chartGender.ChartAreas[0].Area3DStyle.Enable3D = true;
                }
                if (chartGender.Legends.Count > 0)
                {
                    chartGender.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
                }
            }

            // Chart So sánh các tòa nhà
            if (chartBuildingComparison != null)
            {
                if (chartBuildingComparison.ChartAreas.Count == 0)
                    chartBuildingComparison.ChartAreas.Add(new ChartArea());
                if (chartBuildingComparison.Legends.Count == 0)
                    chartBuildingComparison.Legends.Add(new Legend());
                chartBuildingComparison.Series.Clear();
                var seriesStudents = chartBuildingComparison.Series.Add("Sinh viên");
                seriesStudents.ChartType = SeriesChartType.Column;
                seriesStudents.XValueType = ChartValueType.String;
                seriesStudents.Color = Theme.Primary;
                seriesStudents.YAxisType = AxisType.Primary;

                var seriesRevenueBuilding = chartBuildingComparison.Series.Add("Doanh thu (triệu)");
                seriesRevenueBuilding.ChartType = SeriesChartType.Line;
                seriesRevenueBuilding.XValueType = ChartValueType.String;
                seriesRevenueBuilding.Color = Theme.Success;
                seriesRevenueBuilding.YAxisType = AxisType.Secondary;
                seriesRevenueBuilding.BorderWidth = 3;
                seriesRevenueBuilding.MarkerStyle = MarkerStyle.Circle;
                seriesRevenueBuilding.MarkerSize = 8;
                if (chartBuildingComparison.ChartAreas.Count > 0)
                {
                    var chartArea = chartBuildingComparison.ChartAreas[0];
                    chartArea.AxisX.MajorGrid.Enabled = false;
                    chartArea.AxisY.MajorGrid.Enabled = true;
                    chartArea.AxisY2.MajorGrid.Enabled = false;
                }
                if (chartBuildingComparison.Legends.Count > 0)
                {
                    chartBuildingComparison.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
                }
            }

            // Chart Xu hướng vi phạm
            if (chartViolations != null)
            {
                if (chartViolations.ChartAreas.Count == 0)
                    chartViolations.ChartAreas.Add(new ChartArea());
                chartViolations.Series.Clear();
                var seriesViolations = chartViolations.Series.Add("Vi phạm");
                seriesViolations.ChartType = SeriesChartType.Column;
                seriesViolations.XValueType = ChartValueType.String;
                seriesViolations.Color = Color.FromArgb(231, 76, 60);  // Màu đỏ
                seriesViolations.IsValueShownAsLabel = false;

                // Cấu hình ChartArea cho Bar chart
                if (chartViolations.ChartAreas.Count > 0)
                {
                    var chartArea = chartViolations.ChartAreas[0];
                    chartArea.AxisX.MajorGrid.Enabled = false;
                    chartArea.AxisY.MajorGrid.Enabled = true;
                    chartArea.AxisY.Minimum = 0;
                }
            }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadStatisticsDataWithDebounce();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            LoadStatisticsDataWithDebounce();
        }

        private void LoadStatisticsDataWithDebounce()
        {
            if (isLoading) return;
            
            applyTimer?.Dispose();
            applyTimer = new System.Threading.Timer(_ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => 
                    {
                        await LoadStatisticsData();
                    }));
                }
                else
                {
                    _ = Task.Run(async () => await LoadStatisticsData());
                }
            }, null, 300, Timeout.Infinite);
        }

        private async Task LoadStatisticsData()
        {
            if (isLoading) return;
            
            isLoading = true;
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            
            try
            {
                if (token.IsCancellationRequested) return;
                
                var data = await ApiService.GetStatisticsAsync(dtpDateFrom.Value, dtpDateTo.Value);
                
                if (token.IsCancellationRequested) return;
                
                if (data == null)
                {
                    if (this.mainForm != null)
                    {
                        UiHelper.ShowError(this.mainForm, "Không có dữ liệu thống kê cho khoảng thời gian này.");
                    }
                    return;
                }

                if (chartRevenue == null || chartRevenue.Series["Doanh thu"] == null || chartRevenue.ChartAreas.Count == 0) return;
                if (chartOccupancyTrend == null || chartOccupancyTrend.Series["Tỷ lệ (%)"] == null || chartOccupancyTrend.ChartAreas.Count == 0) return;
                if (chartGender == null || chartGender.Series["Giới tính"] == null || chartGender.ChartAreas.Count == 0) return;
                if (chartBuildingComparison == null || chartBuildingComparison.Series["Sinh viên"] == null || chartBuildingComparison.Series["Doanh thu (triệu)"] == null || chartBuildingComparison.ChartAreas.Count == 0) return;
                if (chartViolations == null || chartViolations.Series["Vi phạm"] == null || chartViolations.ChartAreas.Count == 0) return;

                // 1. Vẽ biểu đồ Doanh thu
                chartRevenue.Series["Doanh thu"].Points.Clear();
                if (data.RevenueByMonth != null)
                {
                    foreach (var p in data.RevenueByMonth)
                    {
                        chartRevenue.Series["Doanh thu"].Points.AddXY(p.Label, p.Value);
                    }
                }

                // 2. Vẽ biểu đồ Xu hướng lấp đầy
                chartOccupancyTrend.Series["Tỷ lệ (%)"].Points.Clear();
                if (data.OccupancyTrend != null)
                {
                    foreach (var p in data.OccupancyTrend)
                    {
                        chartOccupancyTrend.Series["Tỷ lệ (%)"].Points.AddXY(p.Label, p.Value);
                    }
                }

                // 3. Vẽ biểu đồ Tỉ lệ giới tính
                chartGender.Series["Giới tính"].Points.Clear();
                if (data.GenderDistribution != null && data.GenderDistribution.Count > 0)
                {
                    // Tính tổng số sinh viên để tính phần trăm
                    int totalStudents = data.GenderDistribution.Sum(p => p.Value);
                    
                    if (totalStudents > 0)
                    {
                        foreach (GenderDistributionPoint p in data.GenderDistribution)
                        {
                            // Tính phần trăm
                            double percentage = Math.Round((double)p.Value * 100 / totalStudents, 2);
                            
                            // Tạo label đơn giản (chỉ "Nam" hoặc "Nữ")
                            string simpleLabel = p.Label.Contains("Nam") ? "Nam" : "Nữ";
                            
                            int pointIndex = chartGender.Series["Giới tính"].Points.AddXY(simpleLabel, percentage);
                            DataPoint point = chartGender.Series["Giới tính"].Points[pointIndex];
                            
                            // Màu xanh dương cho Nam, màu hồng cho Nữ
                            point.Color = p.Label.Contains("Nam")
                                ? Color.FromArgb(52, 152, 219)  // Xanh dương
                                : Color.FromArgb(231, 76, 60);   // Hồng/Đỏ
                            
                            // Hiển thị phần trăm trong label
                            point.Label = $"{simpleLabel}\n{percentage}%";
                            // Tooltip hiển thị chi tiết số lượng
                            point.ToolTip = $"{simpleLabel}: {p.Value} sinh viên ({percentage}%)";
                        }
                    }
                }

                // 4. Vẽ biểu đồ So sánh các tòa nhà
                chartBuildingComparison.Series["Sinh viên"].Points.Clear();
                chartBuildingComparison.Series["Doanh thu (triệu)"].Points.Clear();
                if (data.BuildingComparison != null)
                {
                    foreach (var p in data.BuildingComparison)
                    {
                        chartBuildingComparison.Series["Sinh viên"].Points.AddXY(p.Building, p.Students);
                        chartBuildingComparison.Series["Doanh thu (triệu)"].Points.AddXY(p.Building, p.Revenue);
                    }
                }

                // 5. Vẽ biểu đồ Xu hướng vi phạm
                chartViolations.Series["Vi phạm"].Points.Clear();
                if (data.ViolationsByMonth != null)
                {
                    foreach (var p in data.ViolationsByMonth)
                    {
                        chartViolations.Series["Vi phạm"].Points.AddXY(p.Label, p.Value);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải thống kê: {ex.Message}");
                }
            }
            finally
            {
                isLoading = false;
            }
        }

    }
}
