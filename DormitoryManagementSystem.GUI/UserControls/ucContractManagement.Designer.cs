
namespace DormitoryManagementSystem.GUI.UserControls
{
    partial class ucContractManagement
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
            btnAddContract = new Button();
            btnFilter = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvContracts = new DataGridView();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContracts).BeginInit();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(btnAddContract);
            pnlFilters.Controls.Add(btnFilter);
            pnlFilters.Controls.Add(btnSearch);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(13, 15);
            pnlFilters.Margin = new Padding(4, 5, 4, 5);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(13, 15, 13, 15);
            pnlFilters.Size = new Size(1750, 107);
            pnlFilters.TabIndex = 1;
            // 
            // btnAddContract
            // 
            btnAddContract.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddContract.BackColor = Color.FromArgb(26, 188, 156);
            btnAddContract.FlatAppearance.BorderSize = 0;
            btnAddContract.FlatStyle = FlatStyle.Flat;
            btnAddContract.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnAddContract.ForeColor = Color.White;
            btnAddContract.Location = new Point(1401, 20);
            btnAddContract.Margin = new Padding(4, 5, 4, 5);
            btnAddContract.Name = "btnAddContract";
            btnAddContract.Size = new Size(257, 62);
            btnAddContract.TabIndex = 4;
            btnAddContract.Text = "+ Thêm hợp đồng";
            btnAddContract.UseVisualStyleBackColor = false;
            btnAddContract.Click += btnAddContract_Click;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.BackColor = Color.FromArgb(102, 118, 239);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(1185, 20);
            btnFilter.Margin = new Padding(4, 5, 4, 5);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(133, 62);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSearch.Font = new Font("Segoe UI", 13F);
            txtSearch.Location = new Point(17, 30);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo mã/tên SV...";
            txtSearch.Size = new Size(1000, 42);
            txtSearch.TabIndex = 0;
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
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvContracts
            // 
            // dgvContracts
            // 
            dgvContracts.ColumnHeadersHeight = 40;
            dgvContracts.Dock = DockStyle.Fill;
            dgvContracts.Location = new Point(13, 122);
            dgvContracts.Margin = new Padding(4, 5, 4, 5);
            dgvContracts.Name = "dgvContracts";
            dgvContracts.RowHeadersWidth = 51;
            dgvContracts.RowTemplate.Height = 35;
            dgvContracts.Size = new Size(1750, 741);
            dgvContracts.TabIndex = 2;
            // 
            // ucContractManagement
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(dgvContracts);
            Controls.Add(pnlFilters);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ucContractManagement";
            Padding = new Padding(13, 15, 13, 15);
            Size = new Size(1776, 878);
            Load += ucContractManagement_Load;
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContracts).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnAddContract;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvContracts;
    }
}