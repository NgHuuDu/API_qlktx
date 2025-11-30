
namespace DormitoryManagementSystem.GUI.UserControls
{
    partial class ucPaymentManagement
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
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlFilters = new Panel();
            btnAddPayment = new Button();
            btnFilter = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            pnlKPICards = new Panel();
            cardCollected = new Panel();
            lblCollectedValue = new Label();
            lblCollectedCount = new Label();
            lblCollectedTitle = new Label();
            cardPending = new Panel();
            lblPendingValue = new Label();
            lblPendingCount = new Label();
            lblPendingTitle = new Label();
            cardOverdue = new Panel();
            lblOverdueValue = new Label();
            lblOverdueCount = new Label();
            lblOverdueTitle = new Label();
            dgvPayments = new DataGridView();
            pnlFilters.SuspendLayout();
            pnlKPICards.SuspendLayout();
            cardCollected.SuspendLayout();
            cardPending.SuspendLayout();
            cardOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(btnAddPayment);
            pnlFilters.Controls.Add(btnFilter);
            pnlFilters.Controls.Add(btnSearch);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(13, 15);
            pnlFilters.Margin = new Padding(4, 5, 4, 5);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(13, 15, 13, 15);
            pnlFilters.Size = new Size(1718, 107);
            pnlFilters.TabIndex = 2;
            // 
            // btnAddPayment
            // 
            btnAddPayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddPayment.BackColor = Color.FromArgb(26, 188, 156);
            btnAddPayment.FlatAppearance.BorderSize = 0;
            btnAddPayment.FlatStyle = FlatStyle.Flat;
            btnAddPayment.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnAddPayment.ForeColor = Color.White;
            btnAddPayment.Location = new Point(1414, 15);
            btnAddPayment.Margin = new Padding(4, 5, 4, 5);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(212, 62);
            btnAddPayment.TabIndex = 4;
            btnAddPayment.Text = "+ Ghi nhận TT";
            btnAddPayment.UseVisualStyleBackColor = false;
            btnAddPayment.Click += btnAddPayment_Click;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.BackColor = Color.FromArgb(102, 118, 239);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(1185, 15);
            btnFilter.Margin = new Padding(4, 5, 4, 5);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(133, 62);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(102, 118, 239);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1030, 30);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(133, 42);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 13F);
            txtSearch.Location = new Point(17, 30);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo mã thanh toán, mã hợp đồng...";
            txtSearch.Size = new Size(1000, 42);
            txtSearch.TabIndex = 0;
            // 
            // pnlKPICards
            // 
            pnlKPICards.BackColor = Color.Transparent;
            pnlKPICards.Controls.Add(cardCollected);
            pnlKPICards.Controls.Add(cardPending);
            pnlKPICards.Controls.Add(cardOverdue);
            pnlKPICards.Dock = DockStyle.Top;
            pnlKPICards.Location = new Point(13, 122);
            pnlKPICards.Margin = new Padding(4, 5, 4, 5);
            pnlKPICards.Name = "pnlKPICards";
            pnlKPICards.Padding = new Padding(20, 20, 20, 15);
            pnlKPICards.Size = new Size(1718, 235);
            pnlKPICards.TabIndex = 3;
            // 
            // cardCollected
            // 
            cardCollected.Anchor = AnchorStyles.None;
            cardCollected.BackColor = Color.White;
            cardCollected.BorderStyle = BorderStyle.FixedSingle;
            cardCollected.Controls.Add(lblCollectedValue);
            cardCollected.Controls.Add(lblCollectedCount);
            cardCollected.Controls.Add(lblCollectedTitle);
            cardCollected.Location = new Point(161, 58);
            cardCollected.Margin = new Padding(5);
            cardCollected.Name = "cardCollected";
            cardCollected.Padding = new Padding(15);
            cardCollected.Size = new Size(200, 125);
            cardCollected.TabIndex = 0;
            // 
            // lblCollectedValue
            // 
            lblCollectedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCollectedValue.AutoSize = true;
            lblCollectedValue.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblCollectedValue.ForeColor = Color.FromArgb(26, 188, 156);
            lblCollectedValue.Location = new Point(15, 50);
            lblCollectedValue.Margin = new Padding(0);
            lblCollectedValue.Name = "lblCollectedValue";
            lblCollectedValue.Size = new Size(56, 37);
            lblCollectedValue.TabIndex = 2;
            lblCollectedValue.Text = "0đ";
            // 
            // lblCollectedCount
            // 
            lblCollectedCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCollectedCount.AutoSize = true;
            lblCollectedCount.Font = new Font("Microsoft Sans Serif", 9F);
            lblCollectedCount.ForeColor = Color.Gray;
            lblCollectedCount.Location = new Point(15, 85);
            lblCollectedCount.Margin = new Padding(0);
            lblCollectedCount.Name = "lblCollectedCount";
            lblCollectedCount.Size = new Size(110, 22);
            lblCollectedCount.TabIndex = 1;
            lblCollectedCount.Text = "0 thanh toán";
            // 
            // lblCollectedTitle
            // 
            lblCollectedTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCollectedTitle.AutoSize = true;
            lblCollectedTitle.Font = new Font("Microsoft Sans Serif", 9F);
            lblCollectedTitle.ForeColor = Color.Gray;
            lblCollectedTitle.Location = new Point(15, 15);
            lblCollectedTitle.Margin = new Padding(0);
            lblCollectedTitle.Name = "lblCollectedTitle";
            lblCollectedTitle.Size = new Size(63, 22);
            lblCollectedTitle.TabIndex = 0;
            lblCollectedTitle.Text = "Đã thu";
            // 
            // cardPending
            // 
            cardPending.Anchor = AnchorStyles.None;
            cardPending.BackColor = Color.White;
            cardPending.BorderStyle = BorderStyle.FixedSingle;
            cardPending.Controls.Add(lblPendingValue);
            cardPending.Controls.Add(lblPendingCount);
            cardPending.Controls.Add(lblPendingTitle);
            cardPending.Location = new Point(581, 58);
            cardPending.Margin = new Padding(5);
            cardPending.Name = "cardPending";
            cardPending.Padding = new Padding(15);
            cardPending.Size = new Size(200, 125);
            cardPending.TabIndex = 1;
            // 
            // lblPendingValue
            // 
            lblPendingValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPendingValue.AutoSize = true;
            lblPendingValue.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblPendingValue.ForeColor = Color.FromArgb(241, 196, 15);
            lblPendingValue.Location = new Point(15, 50);
            lblPendingValue.Margin = new Padding(0);
            lblPendingValue.Name = "lblPendingValue";
            lblPendingValue.Size = new Size(56, 37);
            lblPendingValue.TabIndex = 2;
            lblPendingValue.Text = "0đ";
            // 
            // lblPendingCount
            // 
            lblPendingCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPendingCount.AutoSize = true;
            lblPendingCount.Font = new Font("Microsoft Sans Serif", 9F);
            lblPendingCount.ForeColor = Color.Gray;
            lblPendingCount.Location = new Point(15, 85);
            lblPendingCount.Margin = new Padding(0);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(144, 22);
            lblPendingCount.TabIndex = 1;
            lblPendingCount.Text = "0 chờ thanh toán";
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
            lblPendingTitle.Size = new Size(73, 22);
            lblPendingTitle.TabIndex = 0;
            lblPendingTitle.Text = "Chờ thu";
            // 
            // cardOverdue
            // 
            cardOverdue.Anchor = AnchorStyles.None;
            cardOverdue.BackColor = Color.White;
            cardOverdue.BorderStyle = BorderStyle.FixedSingle;
            cardOverdue.Controls.Add(lblOverdueValue);
            cardOverdue.Controls.Add(lblOverdueCount);
            cardOverdue.Controls.Add(lblOverdueTitle);
            cardOverdue.Location = new Point(1001, 58);
            cardOverdue.Margin = new Padding(5);
            cardOverdue.Name = "cardOverdue";
            cardOverdue.Padding = new Padding(15);
            cardOverdue.Size = new Size(200, 125);
            cardOverdue.TabIndex = 2;
            // 
            // lblOverdueValue
            // 
            lblOverdueValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOverdueValue.AutoSize = true;
            lblOverdueValue.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblOverdueValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblOverdueValue.Location = new Point(15, 50);
            lblOverdueValue.Margin = new Padding(0);
            lblOverdueValue.Name = "lblOverdueValue";
            lblOverdueValue.Size = new Size(56, 37);
            lblOverdueValue.TabIndex = 2;
            lblOverdueValue.Text = "0đ";
            // 
            // lblOverdueCount
            // 
            lblOverdueCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOverdueCount.AutoSize = true;
            lblOverdueCount.Font = new Font("Microsoft Sans Serif", 9F);
            lblOverdueCount.ForeColor = Color.Gray;
            lblOverdueCount.Location = new Point(15, 85);
            lblOverdueCount.Margin = new Padding(0);
            lblOverdueCount.Name = "lblOverdueCount";
            lblOverdueCount.Size = new Size(180, 22);
            lblOverdueCount.TabIndex = 1;
            lblOverdueCount.Text = "0 thanh toán quá hạn";
            // 
            // lblOverdueTitle
            // 
            lblOverdueTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOverdueTitle.AutoSize = true;
            lblOverdueTitle.Font = new Font("Microsoft Sans Serif", 9F);
            lblOverdueTitle.ForeColor = Color.Gray;
            lblOverdueTitle.Location = new Point(15, 15);
            lblOverdueTitle.Margin = new Padding(0);
            lblOverdueTitle.Name = "lblOverdueTitle";
            lblOverdueTitle.Size = new Size(79, 22);
            lblOverdueTitle.TabIndex = 0;
            lblOverdueTitle.Text = "Quá hạn";
            // 
            // dgvPayments
            // 
            dgvPayments.ColumnHeadersHeight = 40;
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.Location = new Point(13, 357);
            dgvPayments.Margin = new Padding(4, 5, 4, 5);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.RowHeadersWidth = 51;
            dgvPayments.RowTemplate.Height = 35;
            dgvPayments.Size = new Size(1718, 666);
            dgvPayments.TabIndex = 4;
            dgvPayments.CellContentClick += dgvPayments_CellContentClick;
            // 
            // ucPaymentManagement
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(dgvPayments);
            Controls.Add(pnlKPICards);
            Controls.Add(pnlFilters);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ucPaymentManagement";
            Padding = new Padding(13, 15, 13, 15);
            Size = new Size(1744, 1038);
            Load += ucPaymentManagement_Load;
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlKPICards.ResumeLayout(false);
            cardCollected.ResumeLayout(false);
            cardCollected.PerformLayout();
            cardPending.ResumeLayout(false);
            cardPending.PerformLayout();
            cardOverdue.ResumeLayout(false);
            cardOverdue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlKPICards;
        private System.Windows.Forms.Panel cardCollected;
        private System.Windows.Forms.Label lblCollectedTitle;
        private System.Windows.Forms.Label lblCollectedValue;
        private System.Windows.Forms.Label lblCollectedCount;
        private System.Windows.Forms.Panel cardPending;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Label lblPendingValue;
        private System.Windows.Forms.Label lblPendingCount;
        private System.Windows.Forms.Panel cardOverdue;
        private System.Windows.Forms.Label lblOverdueTitle;
        private System.Windows.Forms.Label lblOverdueValue;
        private System.Windows.Forms.Label lblOverdueCount;
        private System.Windows.Forms.DataGridView dgvPayments;
    }
}