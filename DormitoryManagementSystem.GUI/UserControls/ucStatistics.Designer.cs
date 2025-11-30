
namespace DormitoryManagementSystem.GUI.UserControls
{
    partial class ucStatistics
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                // Cleanup timers and cancellation tokens
                cancellationTokenSource?.Cancel();
                cancellationTokenSource?.Dispose();
                applyTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pnlFilters = new Panel();
            dtpDateTo = new DateTimePicker();
            dtpDateFrom = new DateTimePicker();
            tlpCharts = new TableLayoutPanel();
            groupRevenue = new GroupBox();
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupOccupancyTrend = new GroupBox();
            chartOccupancyTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupGender = new GroupBox();
            chartGender = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBuildingComparison = new GroupBox();
            chartBuildingComparison = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupViolations = new GroupBox();
            chartViolations = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pnlFilters.SuspendLayout();
            tlpCharts.SuspendLayout();
            groupRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            groupOccupancyTrend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartOccupancyTrend).BeginInit();
            groupGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartGender).BeginInit();
            groupBuildingComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartBuildingComparison).BeginInit();
            groupViolations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartViolations).BeginInit();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(dtpDateTo);
            pnlFilters.Controls.Add(dtpDateFrom);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(13, 15);
            pnlFilters.Margin = new Padding(4, 5, 4, 5);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(13, 15, 13, 15);
            pnlFilters.Size = new Size(1718, 107);
            pnlFilters.TabIndex = 3;
            // 
            // dtpDateTo
            // 
            dtpDateTo.CalendarFont = new Font("Segoe UI", 13F);
            dtpDateTo.Location = new Point(300, 18);
            dtpDateTo.Margin = new Padding(4, 5, 4, 5);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.Size = new Size(265, 27);
            dtpDateTo.TabIndex = 1;
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.CalendarFont = new Font("Segoe UI", 13F);
            dtpDateFrom.Location = new Point(13, 18);
            dtpDateFrom.Margin = new Padding(4, 5, 4, 5);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.Size = new Size(265, 27);
            dtpDateFrom.TabIndex = 0;
            // 
            // tlpCharts
            // 
            tlpCharts.ColumnCount = 3;
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpCharts.Controls.Add(groupRevenue, 0, 0);
            tlpCharts.Controls.Add(groupOccupancyTrend, 1, 0);
            tlpCharts.Controls.Add(groupGender, 2, 0);
            tlpCharts.Controls.Add(groupBuildingComparison, 0, 1);
            tlpCharts.SetColumnSpan(groupBuildingComparison, 2);
            tlpCharts.Controls.Add(groupViolations, 2, 1);
            tlpCharts.Dock = DockStyle.Fill;
            tlpCharts.Location = new Point(13, 122);
            tlpCharts.Margin = new Padding(4, 5, 4, 5);
            tlpCharts.Name = "tlpCharts";
            tlpCharts.RowCount = 2;
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCharts.Size = new Size(1718, 769);
            tlpCharts.TabIndex = 4;
            // 
            // groupRevenue
            // 
            groupRevenue.Controls.Add(chartRevenue);
            groupRevenue.Dock = DockStyle.Fill;
            groupRevenue.Font = new Font("Segoe UI", 13F);
            groupRevenue.Location = new Point(4, 5);
            groupRevenue.Margin = new Padding(4, 5, 4, 5);
            groupRevenue.Name = "groupRevenue";
            groupRevenue.Padding = new Padding(4, 5, 4, 5);
            groupRevenue.Size = new Size(562, 374);
            groupRevenue.TabIndex = 0;
            groupRevenue.TabStop = false;
            groupRevenue.Text = "Doanh thu theo tháng";
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            chartRevenue.ChartAreas.Add(chartArea1);
            chartRevenue.Dock = DockStyle.Fill;
            chartRevenue.Location = new Point(4, 34);
            chartRevenue.Margin = new Padding(4, 5, 4, 5);
            chartRevenue.Name = "chartRevenue";
            chartRevenue.Size = new Size(554, 335);
            chartRevenue.TabIndex = 0;
            // 
            // groupOccupancyTrend
            // 
            groupOccupancyTrend.Controls.Add(chartOccupancyTrend);
            groupOccupancyTrend.Dock = DockStyle.Fill;
            groupOccupancyTrend.Font = new Font("Segoe UI", 13F);
            groupOccupancyTrend.Location = new Point(574, 5);
            groupOccupancyTrend.Margin = new Padding(4, 5, 4, 5);
            groupOccupancyTrend.Name = "groupOccupancyTrend";
            groupOccupancyTrend.Padding = new Padding(4, 5, 4, 5);
            groupOccupancyTrend.Size = new Size(562, 374);
            groupOccupancyTrend.TabIndex = 3;
            groupOccupancyTrend.TabStop = false;
            groupOccupancyTrend.Text = "Xu hướng lấp đầy";
            // 
            // chartOccupancyTrend
            // 
            chartArea2.Name = "ChartArea1";
            chartOccupancyTrend.ChartAreas.Add(chartArea2);
            chartOccupancyTrend.Dock = DockStyle.Fill;
            chartOccupancyTrend.Location = new Point(4, 34);
            chartOccupancyTrend.Margin = new Padding(4, 5, 4, 5);
            chartOccupancyTrend.Name = "chartOccupancyTrend";
            chartOccupancyTrend.Size = new Size(554, 335);
            chartOccupancyTrend.TabIndex = 0;
            // 
            // groupGender
            // 
            groupGender.Controls.Add(chartGender);
            groupGender.Dock = DockStyle.Fill;
            groupGender.Font = new Font("Segoe UI", 13F);
            groupGender.Location = new Point(1144, 5);
            groupGender.Margin = new Padding(4, 5, 4, 5);
            groupGender.Name = "groupGender";
            groupGender.Padding = new Padding(4, 5, 4, 5);
            groupGender.Size = new Size(570, 374);
            groupGender.TabIndex = 4;
            groupGender.TabStop = false;
            groupGender.Text = "Tỉ lệ giới tính";
            // 
            // chartGender
            // 
            chartArea3.Name = "ChartArea1";
            chartGender.ChartAreas.Add(chartArea3);
            if (chartGender.Legends.Count == 0)
                chartGender.Legends.Add(legend1);
            chartGender.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            chartGender.Dock = DockStyle.Fill;
            chartGender.Location = new Point(4, 34);
            chartGender.Margin = new Padding(4, 5, 4, 5);
            chartGender.Name = "chartGender";
            chartGender.Size = new Size(562, 335);
            chartGender.TabIndex = 0;
            // 
            // groupBuildingComparison
            // 
            groupBuildingComparison.Controls.Add(chartBuildingComparison);
            groupBuildingComparison.Dock = DockStyle.Fill;
            groupBuildingComparison.Font = new Font("Segoe UI", 13F);
            groupBuildingComparison.Location = new Point(4, 389);
            groupBuildingComparison.Margin = new Padding(4, 5, 4, 5);
            groupBuildingComparison.Name = "groupBuildingComparison";
            groupBuildingComparison.Padding = new Padding(4, 5, 4, 5);
            groupBuildingComparison.Size = new Size(1132, 375);
            groupBuildingComparison.TabIndex = 5;
            groupBuildingComparison.TabStop = false;
            groupBuildingComparison.Text = "So sánh các tòa nhà";
            // 
            // chartBuildingComparison
            // 
            chartArea4.Name = "ChartArea1";
            chartBuildingComparison.ChartAreas.Add(chartArea4);
            if (chartBuildingComparison.Legends.Count == 0)
                chartBuildingComparison.Legends.Add(legend2);
            chartBuildingComparison.Dock = DockStyle.Fill;
            chartBuildingComparison.Location = new Point(4, 34);
            chartBuildingComparison.Margin = new Padding(4, 5, 4, 5);
            chartBuildingComparison.Name = "chartBuildingComparison";
            chartBuildingComparison.Size = new Size(1124, 336);
            chartBuildingComparison.TabIndex = 0;
            // 
            // groupViolations
            // 
            groupViolations.Controls.Add(chartViolations);
            groupViolations.Dock = DockStyle.Fill;
            groupViolations.Font = new Font("Segoe UI", 13F);
            groupViolations.Location = new Point(1144, 389);
            groupViolations.Margin = new Padding(4, 5, 4, 5);
            groupViolations.Name = "groupViolations";
            groupViolations.Padding = new Padding(4, 5, 4, 5);
            groupViolations.Size = new Size(570, 375);
            groupViolations.TabIndex = 2;
            groupViolations.TabStop = false;
            groupViolations.Text = "Xu hướng vi phạm";
            // 
            // chartViolations
            // 
            chartArea3.Name = "ChartArea1";
            chartViolations.ChartAreas.Add(chartArea3);
            chartViolations.Dock = DockStyle.Fill;
            chartViolations.Location = new Point(4, 34);
            chartViolations.Margin = new Padding(4, 5, 4, 5);
            chartViolations.Name = "chartViolations";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            chartViolations.Series.Add(series1);
            chartViolations.Size = new Size(562, 336);
            chartViolations.TabIndex = 1;
            // 
            // ucStatistics
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(tlpCharts);
            Controls.Add(pnlFilters);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ucStatistics";
            Padding = new Padding(13, 15, 13, 15);
            Size = new Size(1744, 906);
            Load += ucStatistics_Load;
            dtpDateFrom.ValueChanged += dtpDateFrom_ValueChanged;
            dtpDateTo.ValueChanged += dtpDateTo_ValueChanged;
            pnlFilters.ResumeLayout(false);
            tlpCharts.ResumeLayout(false);
            groupRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            groupOccupancyTrend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartOccupancyTrend).EndInit();
            groupGender.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartGender).EndInit();
            groupBuildingComparison.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartBuildingComparison).EndInit();
            groupViolations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartViolations).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.TableLayoutPanel tlpCharts;
        private System.Windows.Forms.GroupBox groupRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.GroupBox groupOccupancyTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOccupancyTrend;
        private System.Windows.Forms.GroupBox groupGender;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGender;
        private System.Windows.Forms.GroupBox groupBuildingComparison;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBuildingComparison;
        private System.Windows.Forms.GroupBox groupViolations;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartViolations;
    }
}