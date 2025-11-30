
namespace DormitoryManagementSystem.GUI.UserControls
{
    partial class ucViolationManagement
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
                filterTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlFilters = new Panel();
            btnAddViolation = new Button();
            btnFilter = new Button();
            cmbFilterStatus = new ComboBox();
            txtSearch = new TextBox();
            pnlKPICards = new Panel();
            cardUnprocessed = new Panel();
            lblUnprocessedValue = new Label();
            lblUnprocessedAction = new Label();
            lblUnprocessedTitle = new Label();
            cardProcessed = new Panel();
            lblProcessedValue = new Label();
            lblProcessedAction = new Label();
            lblProcessedTitle = new Label();
            cardSerious = new Panel();
            lblSeriousValue = new Label();
            lblSeriousAction = new Label();
            lblSeriousTitle = new Label();
            dgvViolations = new DataGridView();
            pnlFilters.SuspendLayout();
            pnlKPICards.SuspendLayout();
            cardUnprocessed.SuspendLayout();
            cardProcessed.SuspendLayout();
            cardSerious.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViolations).BeginInit();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(btnAddViolation);
            pnlFilters.Controls.Add(btnFilter);
            pnlFilters.Controls.Add(cmbFilterStatus);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(13, 15);
            pnlFilters.Margin = new Padding(4, 5, 4, 5);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(13, 15, 13, 15);
            pnlFilters.Size = new Size(1718, 107);
            pnlFilters.TabIndex = 2;
            // 
            // btnAddViolation
            // 
            btnAddViolation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddViolation.BackColor = Color.FromArgb(231, 76, 60);
            btnAddViolation.FlatAppearance.BorderSize = 0;
            btnAddViolation.FlatStyle = FlatStyle.Flat;
            btnAddViolation.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnAddViolation.ForeColor = Color.White;
            btnAddViolation.Location = new Point(1412, 15);
            btnAddViolation.Margin = new Padding(4, 5, 4, 5);
            btnAddViolation.Name = "btnAddViolation";
            btnAddViolation.Size = new Size(246, 62);
            btnAddViolation.TabIndex = 4;
            btnAddViolation.Text = "+ Thêm vi phạm";
            btnAddViolation.UseVisualStyleBackColor = false;
            btnAddViolation.Click += btnAddViolation_Click;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.BackColor = Color.FromArgb(102, 118, 239);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(1241, 15);
            btnFilter.Margin = new Padding(4, 5, 4, 5);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(133, 62);
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
            cmbFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Chưa xử lý", "Đã xử lý" });
            cmbFilterStatus.Location = new Point(912, 29);
            cmbFilterStatus.Margin = new Padding(4, 5, 4, 5);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(225, 44);
            cmbFilterStatus.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 13F);
            txtSearch.Location = new Point(17, 31);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo mã/tên SV...";
            txtSearch.Size = new Size(724, 42);
            txtSearch.TabIndex = 0;
            // 
            // pnlKPICards
            // 
            pnlKPICards.BackColor = Color.Transparent;
            pnlKPICards.Controls.Add(cardUnprocessed);
            pnlKPICards.Controls.Add(cardProcessed);
            pnlKPICards.Controls.Add(cardSerious);
            pnlKPICards.Dock = DockStyle.Top;
            pnlKPICards.Location = new Point(13, 122);
            pnlKPICards.Margin = new Padding(4, 5, 4, 5);
            pnlKPICards.Name = "pnlKPICards";
            pnlKPICards.Padding = new Padding(20, 20, 20, 15);
            pnlKPICards.Size = new Size(1718, 235);
            pnlKPICards.TabIndex = 3;
            // 
            // cardUnprocessed
            // 
            cardUnprocessed.Anchor = AnchorStyles.None;
            cardUnprocessed.BackColor = Color.White;
            cardUnprocessed.BorderStyle = BorderStyle.FixedSingle;
            cardUnprocessed.Controls.Add(lblUnprocessedValue);
            cardUnprocessed.Controls.Add(lblUnprocessedAction);
            cardUnprocessed.Controls.Add(lblUnprocessedTitle);
            cardUnprocessed.Location = new Point(161, 58);
            cardUnprocessed.Margin = new Padding(5);
            cardUnprocessed.Name = "cardUnprocessed";
            cardUnprocessed.Padding = new Padding(15);
            cardUnprocessed.Size = new Size(242, 125);
            cardUnprocessed.TabIndex = 0;
            // 
            // lblUnprocessedValue
            // 
            lblUnprocessedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUnprocessedValue.AutoSize = true;
            lblUnprocessedValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblUnprocessedValue.ForeColor = Color.FromArgb(241, 196, 15);
            lblUnprocessedValue.Location = new Point(15, 45);
            lblUnprocessedValue.Margin = new Padding(0);
            lblUnprocessedValue.Name = "lblUnprocessedValue";
            lblUnprocessedValue.Size = new Size(41, 48);
            lblUnprocessedValue.TabIndex = 1;
            lblUnprocessedValue.Text = "0";
            // 
            // lblUnprocessedAction
            // 
            lblUnprocessedAction.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUnprocessedAction.AutoSize = true;
            lblUnprocessedAction.Font = new Font("Segoe UI", 9F);
            lblUnprocessedAction.ForeColor = Color.FromArgb(231, 76, 60);
            lblUnprocessedAction.Location = new Point(15, 95);
            lblUnprocessedAction.Margin = new Padding(0);
            lblUnprocessedAction.Name = "lblUnprocessedAction";
            lblUnprocessedAction.Size = new Size(128, 25);
            lblUnprocessedAction.TabIndex = 2;
            lblUnprocessedAction.Text = "Cần xử lý ngay";
            // 
            // lblUnprocessedTitle
            // 
            lblUnprocessedTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUnprocessedTitle.AutoSize = true;
            lblUnprocessedTitle.Font = new Font("Segoe UI", 9F);
            lblUnprocessedTitle.ForeColor = Color.Gray;
            lblUnprocessedTitle.Location = new Point(15, 15);
            lblUnprocessedTitle.Margin = new Padding(0);
            lblUnprocessedTitle.Name = "lblUnprocessedTitle";
            lblUnprocessedTitle.Size = new Size(95, 25);
            lblUnprocessedTitle.TabIndex = 0;
            lblUnprocessedTitle.Text = "Chưa xử lý";
            // 
            // cardProcessed
            // 
            cardProcessed.Anchor = AnchorStyles.None;
            cardProcessed.BackColor = Color.White;
            cardProcessed.BorderStyle = BorderStyle.FixedSingle;
            cardProcessed.Controls.Add(lblProcessedValue);
            cardProcessed.Controls.Add(lblProcessedAction);
            cardProcessed.Controls.Add(lblProcessedTitle);
            cardProcessed.Location = new Point(581, 58);
            cardProcessed.Margin = new Padding(5);
            cardProcessed.Name = "cardProcessed";
            cardProcessed.Padding = new Padding(15);
            cardProcessed.Size = new Size(242, 125);
            cardProcessed.TabIndex = 1;
            // 
            // lblProcessedValue
            // 
            lblProcessedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProcessedValue.AutoSize = true;
            lblProcessedValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblProcessedValue.ForeColor = Color.FromArgb(26, 188, 156);
            lblProcessedValue.Location = new Point(15, 45);
            lblProcessedValue.Margin = new Padding(0);
            lblProcessedValue.Name = "lblProcessedValue";
            lblProcessedValue.Size = new Size(41, 48);
            lblProcessedValue.TabIndex = 1;
            lblProcessedValue.Text = "0";
            // 
            // lblProcessedAction
            // 
            lblProcessedAction.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProcessedAction.AutoSize = true;
            lblProcessedAction.Font = new Font("Segoe UI", 9F);
            lblProcessedAction.ForeColor = Color.FromArgb(26, 188, 156);
            lblProcessedAction.Location = new Point(15, 95);
            lblProcessedAction.Margin = new Padding(0);
            lblProcessedAction.Name = "lblProcessedAction";
            lblProcessedAction.Size = new Size(105, 25);
            lblProcessedAction.TabIndex = 2;
            lblProcessedAction.Text = "Hoàn thành";
            // 
            // lblProcessedTitle
            // 
            lblProcessedTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProcessedTitle.AutoSize = true;
            lblProcessedTitle.Font = new Font("Segoe UI", 9F);
            lblProcessedTitle.ForeColor = Color.Gray;
            lblProcessedTitle.Location = new Point(15, 15);
            lblProcessedTitle.Margin = new Padding(0);
            lblProcessedTitle.Name = "lblProcessedTitle";
            lblProcessedTitle.Size = new Size(76, 25);
            lblProcessedTitle.TabIndex = 0;
            lblProcessedTitle.Text = "Đã xử lý";
            // 
            // cardSerious
            // 
            cardSerious.BackColor = Color.White;
            cardSerious.BorderStyle = BorderStyle.FixedSingle;
            cardSerious.Controls.Add(lblSeriousValue);
            cardSerious.Controls.Add(lblSeriousAction);
            cardSerious.Controls.Add(lblSeriousTitle);
            cardSerious.Location = new Point(1001, 58);
            cardSerious.Margin = new Padding(5);
            cardSerious.Name = "cardSerious";
            cardSerious.Padding = new Padding(15);
            cardSerious.Size = new Size(242, 125);
            cardSerious.TabIndex = 2;
            // 
            // lblSeriousValue
            // 
            lblSeriousValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSeriousValue.AutoSize = true;
            lblSeriousValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblSeriousValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblSeriousValue.Location = new Point(15, 45);
            lblSeriousValue.Margin = new Padding(0);
            lblSeriousValue.Name = "lblSeriousValue";
            lblSeriousValue.Size = new Size(41, 48);
            lblSeriousValue.TabIndex = 1;
            lblSeriousValue.Text = "0";
            // 
            // lblSeriousAction
            // 
            lblSeriousAction.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSeriousAction.AutoSize = true;
            lblSeriousAction.Font = new Font("Segoe UI", 9F);
            lblSeriousAction.ForeColor = Color.FromArgb(231, 76, 60);
            lblSeriousAction.Location = new Point(15, 95);
            lblSeriousAction.Margin = new Padding(0);
            lblSeriousAction.Name = "lblSeriousAction";
            lblSeriousAction.Size = new Size(89, 25);
            lblSeriousAction.TabIndex = 2;
            lblSeriousAction.Text = "Cần chú ý";
            // 
            // lblSeriousTitle
            // 
            lblSeriousTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSeriousTitle.AutoSize = true;
            lblSeriousTitle.Font = new Font("Segoe UI", 9F);
            lblSeriousTitle.ForeColor = Color.Gray;
            lblSeriousTitle.Location = new Point(15, 15);
            lblSeriousTitle.Margin = new Padding(0);
            lblSeriousTitle.Name = "lblSeriousTitle";
            lblSeriousTitle.Size = new Size(192, 25);
            lblSeriousTitle.TabIndex = 0;
            lblSeriousTitle.Text = "Vi phạm nghiêm trọng";
            // 
            // dgvViolations
            // 
            dgvViolations.ColumnHeadersHeight = 40;
            dgvViolations.Dock = DockStyle.Fill;
            dgvViolations.Location = new Point(13, 357);
            dgvViolations.Margin = new Padding(4, 5, 4, 5);
            dgvViolations.Name = "dgvViolations";
            dgvViolations.RowHeadersWidth = 51;
            dgvViolations.RowTemplate.Height = 35;
            dgvViolations.Size = new Size(1718, 534);
            dgvViolations.TabIndex = 3;
            // 
            // ucViolationManagement
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(dgvViolations);
            Controls.Add(pnlKPICards);
            Controls.Add(pnlFilters);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ucViolationManagement";
            Padding = new Padding(13, 15, 13, 15);
            Size = new Size(1744, 906);
            Load += ucViolationManagement_Load;
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlKPICards.ResumeLayout(false);
            cardUnprocessed.ResumeLayout(false);
            cardUnprocessed.PerformLayout();
            cardProcessed.ResumeLayout(false);
            cardProcessed.PerformLayout();
            cardSerious.ResumeLayout(false);
            cardSerious.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViolations).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnAddViolation;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlKPICards;
        private System.Windows.Forms.Panel cardUnprocessed;
        private System.Windows.Forms.Label lblUnprocessedTitle;
        private System.Windows.Forms.Label lblUnprocessedValue;
        private System.Windows.Forms.Label lblUnprocessedAction;
        private System.Windows.Forms.Panel cardProcessed;
        private System.Windows.Forms.Label lblProcessedTitle;
        private System.Windows.Forms.Label lblProcessedValue;
        private System.Windows.Forms.Label lblProcessedAction;
        private System.Windows.Forms.Panel cardSerious;
        private System.Windows.Forms.Label lblSeriousTitle;
        private System.Windows.Forms.Label lblSeriousValue;
        private System.Windows.Forms.Label lblSeriousAction;
        private System.Windows.Forms.DataGridView dgvViolations;
    }
}