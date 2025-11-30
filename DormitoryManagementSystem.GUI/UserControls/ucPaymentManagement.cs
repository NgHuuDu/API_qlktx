using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Forms;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucPaymentManagement : UserControl
    {
        private Form? mainForm;
        private bool isLoading = false;
        private CancellationTokenSource? cancellationTokenSource;
        
        // Filter values
        private string? filterPaymentID;
        private string? filterContractID;
        private int? filterMonth;
        private DateTime? filterPaymentDate;
        private string? filterPaymentMethod;
        private string? filterPaymentStatus;

        public ucPaymentManagement()
        {
            InitializeComponent();
            this.Resize += ucPaymentManagement_Resize;
            this.Layout += ucPaymentManagement_Layout;
        }

        private void ucPaymentManagement_Layout(object? sender, LayoutEventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                ArrangeKPICards();
            }
        }

        private void ucPaymentManagement_Resize(object? sender, EventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                ArrangeKPICards();
            }
        }

        private void ArrangeKPICards()
        {
            if (pnlKPICards == null) return;

            const int padding = 20;
            const int cardHeight = 125;
            const int cardSpacing = 10;
            const int cardCount = 3;
            const int minCardWidth = 200;
            const int maxCardWidth = 300;

            var (cardWidth, startX) = CalculateCardLayout(pnlKPICards.ClientSize.Width, padding, cardSpacing, cardCount, minCardWidth, maxCardWidth);
            int y = padding;
            const int cardPadding = 15;

            // Sắp xếp các thẻ
            ArrangeCard(cardCollected, lblCollectedTitle, lblCollectedValue, lblCollectedCount, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardPending, lblPendingTitle, lblPendingValue, lblPendingCount, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardOverdue, lblOverdueTitle, lblOverdueValue, lblOverdueCount, startX, y, cardWidth, cardHeight, cardPadding);
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

        private static void ArrangeCard(Panel card, Label lblTitle, Label lblValue, Label lblCount, int x, int y, int width, int height, int padding)
        {
            card.Location = new Point(x, y);
            card.Size = new Size(width, height);
            lblTitle.Location = new Point(padding, padding);
            lblValue.Location = new Point(padding, padding + 35);
            lblCount.Location = new Point(padding, padding + 70);
        }

        private async void ucPaymentManagement_Load(object sender, EventArgs e)
        {
            this.mainForm = this.FindForm();
            SetupGridColumns();
            await LoadDataAsync();
            await UpdateKPICards();
        }

        private void SetupGridColumns()
        {
            dgvPayments.Columns.Clear();
            dgvPayments.ReadOnly = true;
            dgvPayments.Columns.Add("Id", "Id");
            dgvPayments.Columns.Add("PaymentID", "Mã thanh toán");
            dgvPayments.Columns.Add("ContractID", "Mã hợp đồng");
            dgvPayments.Columns.Add("BillMonth", "Tháng");
            dgvPayments.Columns.Add("PaymentAmount", "Số tiền cần đóng");
            dgvPayments.Columns.Add("PaidAmount", "Số tiền đã đóng");
            dgvPayments.Columns.Add("PaymentDate", "Ngày thanh toán");
            dgvPayments.Columns.Add("PaymentMethod", "Phương thức");
            dgvPayments.Columns.Add("PaymentStatus", "Trạng thái");
            dgvPayments.Columns.Add("Description", "Ghi chú");
            var btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                HeaderText = "Thao tác",
                Text = "Chi tiết",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvPayments.Columns.Add(btnDetail);
            dgvPayments.Columns["Id"].Visible = false;
            dgvPayments.Columns["PaymentAmount"].DefaultCellStyle.Format = "N0";
            dgvPayments.Columns["PaymentAmount"].DefaultCellStyle.FormatProvider = new CultureInfo("vi-VN");
            dgvPayments.Columns["PaidAmount"].DefaultCellStyle.Format = "N0";
            dgvPayments.Columns["PaidAmount"].DefaultCellStyle.FormatProvider = new CultureInfo("vi-VN");
            dgvPayments.Columns["PaymentDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.Columns["Detail"].ReadOnly = false;
        }

        private async Task LoadDataAsync()
        {
            if (isLoading) return;
            
            isLoading = true;
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            
            try
            {
                if (token.IsCancellationRequested) return;
                
                string search = txtSearch.Text;
                var payments = await ApiService.GetPaymentsAsync("Tất cả", search);

                if (token.IsCancellationRequested) return;

                dgvPayments.Rows.Clear();
                if (payments != null)
                {
                    foreach (var p in payments)
                    {
                        // Apply filters
                        if (!string.IsNullOrWhiteSpace(filterPaymentID) && 
                            !p.PaymentID.Contains(filterPaymentID, StringComparison.OrdinalIgnoreCase))
                            continue;
                        
                        if (!string.IsNullOrWhiteSpace(filterContractID) && 
                            !p.ContractID.Contains(filterContractID, StringComparison.OrdinalIgnoreCase))
                            continue;
                        
                        if (filterMonth.HasValue && p.BillMonth != filterMonth.Value)
                            continue;
                        
                        if (filterPaymentDate.HasValue && p.PaymentDate.HasValue)
                        {
                            if (p.PaymentDate.Value.Date != filterPaymentDate.Value.Date)
                                continue;
                        }
                        else if (filterPaymentDate.HasValue && !p.PaymentDate.HasValue)
                        {
                            continue;
                        }
                        
                        if (!string.IsNullOrWhiteSpace(filterPaymentMethod))
                        {
                            string method = p.PaymentMethod ?? "";
                            if (!method.Equals(filterPaymentMethod, StringComparison.OrdinalIgnoreCase))
                                continue;
                        }
                        
                        if (!string.IsNullOrWhiteSpace(filterPaymentStatus))
                        {
                            string status = filterPaymentStatus;
                            string paymentStatus = p.PaymentStatus ?? "";
                            
                            // Map Vietnamese status to English
                            bool matches = false;
                            if (status == "Đã thanh toán")
                                matches = paymentStatus.Equals("Paid", StringComparison.OrdinalIgnoreCase);
                            else if (status == "Chờ thanh toán")
                                matches = paymentStatus.Equals("Unpaid", StringComparison.OrdinalIgnoreCase);
                            else if (status == "Quá hạn")
                                matches = paymentStatus.Equals("Late", StringComparison.OrdinalIgnoreCase);
                            else if (status == "Đã hoàn tiền")
                                matches = paymentStatus.Equals("Refunded", StringComparison.OrdinalIgnoreCase);
                            else
                                matches = paymentStatus.Equals(status, StringComparison.OrdinalIgnoreCase);
                            
                            if (!matches)
                                continue;
                        }
                        
                        string statusText = p.PaymentStatus.Equals("Paid", StringComparison.OrdinalIgnoreCase) ? "Đã thanh toán" :
                                           p.PaymentStatus.Equals("Unpaid", StringComparison.OrdinalIgnoreCase) ? "Chờ thanh toán" :
                                           p.PaymentStatus.Equals("Late", StringComparison.OrdinalIgnoreCase) ? "Quá hạn" :
                                           p.PaymentStatus.Equals("Refunded", StringComparison.OrdinalIgnoreCase) ? "Đã hoàn tiền" :
                                           p.PaymentStatus;
                        string paymentMethodText = p.PaymentMethod ?? "";
                        string descriptionText = p.Description ?? "";

                        dgvPayments.Rows.Add(
                            p.Id,
                            p.PaymentID,
                            p.ContractID,
                            p.BillMonth,
                            p.PaymentAmount,
                            p.PaidAmount,
                            p.PaymentDate.HasValue ? p.PaymentDate.Value : (DateTime?)null,
                            paymentMethodText,
                            statusText,
                            descriptionText,
                            "Chi tiết"
                        );
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Bỏ qua hủy bỏ
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu thanh toán: {ex.Message}");
                }
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task UpdateKPICards()
        {
            try
            {
                var kpiData = await ApiService.GetPaymentKPIsAsync();

                if (kpiData != null)
                {
                    lblCollectedValue.Text = FormatCurrency(kpiData.CollectedAmount);
                    lblCollectedCount.Text = $"{kpiData.CollectedCount} thanh toán";
                    lblPendingValue.Text = FormatCurrency(kpiData.PendingAmount);
                    lblPendingCount.Text = $"{kpiData.PendingCount} chờ thanh toán";
                    lblOverdueValue.Text = FormatCurrency(kpiData.OverdueAmount);
                    lblOverdueCount.Text = $"{kpiData.OverdueCount} thanh toán quá hạn";
                }
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu KPI: {ex.Message}");
                }
            }
        }

        private static string FormatCurrency(decimal amount)
        {
            if (amount == 0)
                return "0đ";
            return $"{amount:N0}đ";
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            using var filterForm = new frmFilterPayment(
                filterPaymentID,
                filterContractID,
                filterMonth,
                filterPaymentDate,
                filterPaymentMethod,
                filterPaymentStatus);
            
            if (filterForm.ShowDialog(this) == DialogResult.OK && filterForm.IsApplied)
            {
                // Lưu filter values
                filterPaymentID = filterForm.PaymentID;
                filterContractID = filterForm.ContractID;
                filterMonth = filterForm.Month;
                filterPaymentDate = filterForm.PaymentDate;
                filterPaymentMethod = filterForm.PaymentMethod;
                filterPaymentStatus = filterForm.PaymentStatus;
                
                await LoadDataAsync();
                await UpdateKPICards();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnAddPayment_Click(object sender, EventArgs e)
        {
            using var form = new frmAddPayment();
            if (form.ShowDialog(this) == DialogResult.OK && form.IsSuccess)
            {
                await LoadDataAsync();
                await UpdateKPICards();
            }
        }

        private async void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Columns[e.ColumnIndex].Name == "Detail")
            {
                string paymentId = dgv.Rows[e.RowIndex].Cells["Id"].Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(paymentId))
                {
                    using var form = new Forms.frmPaymentDetail(paymentId);
                    if (form.ShowDialog(this) == DialogResult.OK && form.IsSuccess)
                    {
                        await LoadDataAsync();
                        await UpdateKPICards();
                    }
                }
            }
        }

    }
}
