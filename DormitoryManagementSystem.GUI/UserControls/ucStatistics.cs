using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucStatistics : UserControl
    {
        private Form? mainForm;

        public ucStatistics()
        {
            InitializeComponent();
            SetupCharts();
        }

        private void ucStatistics_Load(object sender, EventArgs e)
        {
            this.mainForm = this.FindForm();
            // Thiết lập ngày mặc định (tháng này)
            dtpDateFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDateTo.Value = DateTime.Now;
        }

        private void SetupCharts()
        {
            // Cấu hình biểu đồ doanh thu (Line)
            chartRevenue.Series.Clear();
            var seriesRevenue = chartRevenue.Series.Add("Doanh thu");
            seriesRevenue.ChartType = SeriesChartType.Line;
            seriesRevenue.XValueType = ChartValueType.String;
            seriesRevenue.BorderWidth = 3;

            // Cấu hình biểu đồ tỷ lệ (Bar)
            chartOccupancy.Series.Clear();
            var seriesOccupancy = chartOccupancy.Series.Add("Tỷ lệ lấp đầy");
            seriesOccupancy.ChartType = SeriesChartType.Bar;
            seriesOccupancy.XValueType = ChartValueType.String;

            // Cấu hình biểu đồ vi phạm (Pie)
            chartViolations.Series.Clear();
            var seriesViolations = chartViolations.Series.Add("Vi phạm");
            seriesViolations.ChartType = SeriesChartType.Pie;
            seriesViolations.Label = "#PERCENT";
            seriesViolations.LegendText = "#VALX";
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            UiHelper.ShowLoading(this);
            try
            {
                var data = await ApiService.GetStatisticsAsync(dtpDateFrom.Value, dtpDateTo.Value);
                if (data == null)
                {
                    UiHelper.ShowError(this.mainForm, "Không có dữ liệu thống kê cho khoảng thời gian này.");
                    return;
                }

                // 1. Vẽ biểu đồ Doanh thu
                chartRevenue.Series["Doanh thu"].Points.Clear();
                if (data.RevenueByMonth != null)
                {
                    foreach (var p in data.RevenueByMonth)
                    {
                        chartRevenue.Series["Doanh thu"].Points.AddXY(p.Label, p.Value);
                    }
                }

                // 2. Vẽ biểu đồ Tỷ lệ lấp đầy
                chartOccupancy.Series["Tỷ lệ lấp đầy"].Points.Clear();
                if (data.OccupancyByBuilding != null)
                {
                    foreach (var p in data.OccupancyByBuilding)
                    {
                        chartOccupancy.Series["Tỷ lệ lấp đầy"].Points.AddXY(p.Label, p.Value);
                    }
                }

                // 3. Vẽ biểu đồ Vi phạm
                chartViolations.Series["Vi phạm"].Points.Clear();
                if (data.ViolationsByType != null)
                {
                    foreach (var p in data.ViolationsByType)
                    {
                        chartViolations.Series["Vi phạm"].Points.AddXY(p.Label, p.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải thống kê: {ex.Message}");
            }
            finally
            {
                UiHelper.HideLoading(this);
            }
        }
    }
}
