using DormitoryManagementSystem.API.Models;
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
        private System.Threading.Timer? filterTimer;

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

            // Arrange cards
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
            dgvPayments.Columns.Add("Id", "Id");
            dgvPayments.Columns.Add("BillCode", "Mã HĐ");
            dgvPayments.Columns.Add("StudentName", "Sinh viên");
            dgvPayments.Columns.Add("RoomNumber", "Phòng");
            dgvPayments.Columns.Add("MonthYear", "Tháng");
            dgvPayments.Columns.Add("TotalAmount", "Số tiền");
            dgvPayments.Columns.Add("Date", "Ngày");
            dgvPayments.Columns.Add("Status", "Trạng thái");
            var btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Chi tiết",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvPayments.Columns.Add(btnDetail);
            dgvPayments.Columns["Id"].Visible = false;
            dgvPayments.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
            dgvPayments.Columns["TotalAmount"].DefaultCellStyle.FormatProvider = new CultureInfo("vi-VN");
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
                
                string status = cmbFilterStatus.SelectedIndex > 0 ? cmbFilterStatus.SelectedItem?.ToString() : "Tất cả";
                string search = txtSearch.Text;
                var payments = await ApiService.GetPaymentsAsync(status ?? "Tất cả", search);

                if (token.IsCancellationRequested) return;

                dgvPayments.Rows.Clear();
                if (payments != null)
                {
                    foreach (var p in payments)
                    {
                        DateTime dueDate = new DateTime(p.Year, p.Month, 1).AddMonths(1);
                        bool isPaid = p.PaymentDate.HasValue;
                        bool isOverdue = !isPaid && DateTime.Now > dueDate;
                        string statusText = isPaid ? "Đã thanh toán" : (isOverdue ? "Quá hạn" : "Chờ thanh toán");
                        string dateText = isPaid ? $"Đã thanh toán:\n{p.PaymentDate.Value:dd/MM/yyyy}" : $"Hạn:\n{dueDate:dd/MM/yyyy}";
                        string amountText = $"{p.TotalAmount:N0}đ";

                        dgvPayments.Rows.Add(p.Id, p.BillCode, p.StudentName, p.RoomNumber, $"{p.Month}/{p.Year}", amountText, dateText, statusText, "Chi tiết");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ignore cancellation
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
            if (btnFilter != null)
            {
                btnFilter.Enabled = false;
            }
            
            filterTimer?.Dispose();
            filterTimer = new System.Threading.Timer(_ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => 
                    {
                        await LoadDataAsync();
                        await UpdateKPICards();
                        if (btnFilter != null) btnFilter.Enabled = true;
                    }));
                }
                else
                {
                    Task.Run(async () =>
                    {
                        await LoadDataAsync();
                        await UpdateKPICards();
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() => { if (btnFilter != null) btnFilter.Enabled = true; }));
                        }
                        else
                        {
                            if (btnFilter != null) btnFilter.Enabled = true;
                        }
                    });
                }
            }, null, 300, Timeout.Infinite);
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (this.mainForm != null)
            {
                UiHelper.ShowSuccess(this.mainForm, "Chức năng Ghi nhận thanh toán (chưa hoàn thiện)");
            }
        }

        private void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Columns[e.ColumnIndex].Name == "Detail")
            {
                int paymentId = (int)dgv.Rows[e.RowIndex].Cells["Id"].Value;
                if (this.mainForm != null)
                {
                    UiHelper.ShowSuccess(this.mainForm, $"Xem chi tiết thanh toán ID: {paymentId}");
                }
            }
        }

    }
}
