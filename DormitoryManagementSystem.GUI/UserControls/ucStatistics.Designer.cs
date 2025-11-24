
namespace DormitoryManagementSystem.GUI.UserControls
{
    partial class ucStatistics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pnlFilters = new Panel();
            dtpDateTo = new DateTimePicker();
            dtpDateFrom = new DateTimePicker();
            tlpCharts = new TableLayoutPanel();
            groupRevenue = new GroupBox();
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupOccupancy = new GroupBox();
            chartOccupancy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupViolations = new GroupBox();
            chartViolations = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pnlFilters.SuspendLayout();
            tlpCharts.SuspendLayout();
            groupRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            groupOccupancy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartOccupancy).BeginInit();
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
            tlpCharts.ColumnCount = 2;
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpCharts.Controls.Add(groupRevenue, 0, 0);
            tlpCharts.Controls.Add(groupOccupancy, 0, 1);
            tlpCharts.Controls.Add(groupViolations, 1, 0);
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
            groupRevenue.Size = new Size(1022, 374);
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
            chartRevenue.Size = new Size(1014, 335);
            chartRevenue.TabIndex = 0;
            // 
            // groupOccupancy
            // 
            groupOccupancy.Controls.Add(chartOccupancy);
            groupOccupancy.Dock = DockStyle.Fill;
            groupOccupancy.Font = new Font("Segoe UI", 13F);
            groupOccupancy.Location = new Point(4, 389);
            groupOccupancy.Margin = new Padding(4, 5, 4, 5);
            groupOccupancy.Name = "groupOccupancy";
            groupOccupancy.Padding = new Padding(4, 5, 4, 5);
            groupOccupancy.Size = new Size(1022, 375);
            groupOccupancy.TabIndex = 1;
            groupOccupancy.TabStop = false;
            groupOccupancy.Text = "Tỷ lệ lấp đầy theo tòa";
            // 
            // chartOccupancy
            // 
            chartArea2.Name = "ChartArea1";
            chartOccupancy.ChartAreas.Add(chartArea2);
            chartOccupancy.Dock = DockStyle.Fill;
            chartOccupancy.Location = new Point(4, 34);
            chartOccupancy.Margin = new Padding(4, 5, 4, 5);
            chartOccupancy.Name = "chartOccupancy";
            chartOccupancy.Size = new Size(1014, 336);
            chartOccupancy.TabIndex = 1;
            // 
            // groupViolations
            // 
            groupViolations.Controls.Add(chartViolations);
            groupViolations.Dock = DockStyle.Fill;
            groupViolations.Font = new Font("Segoe UI", 13F);
            groupViolations.Location = new Point(1034, 5);
            groupViolations.Margin = new Padding(4, 5, 4, 5);
            groupViolations.Name = "groupViolations";
            groupViolations.Padding = new Padding(4, 5, 4, 5);
            tlpCharts.SetRowSpan(groupViolations, 2);
            groupViolations.Size = new Size(680, 759);
            groupViolations.TabIndex = 2;
            groupViolations.TabStop = false;
            groupViolations.Text = "Các loại vi phạm";
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
            chartViolations.Size = new Size(672, 720);
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
            pnlFilters.ResumeLayout(false);
            tlpCharts.ResumeLayout(false);
            groupRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            groupOccupancy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartOccupancy).EndInit();
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
        private System.Windows.Forms.GroupBox groupOccupancy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOccupancy;
        private System.Windows.Forms.GroupBox groupViolations;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartViolations;
    }
}