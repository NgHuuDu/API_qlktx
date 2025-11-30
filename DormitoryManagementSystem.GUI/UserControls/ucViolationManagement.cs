using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucViolationManagement : UserControl
    {
        private Form? mainForm;
        private bool isLoading = false;
        private CancellationTokenSource? cancellationTokenSource;
        private System.Threading.Timer? filterTimer;
        public ucViolationManagement()
        {
            InitializeComponent();
            this.Resize += ucViolationManagement_Resize;
            this.Layout += ucViolationManagement_Layout;
        }

        private void ucViolationManagement_Layout(object? sender, LayoutEventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                ArrangeKPICards();
            }
        }

        private void ucViolationManagement_Resize(object? sender, EventArgs e)
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
            ArrangeCard(cardUnprocessed, lblUnprocessedTitle, lblUnprocessedValue, lblUnprocessedAction, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardProcessed, lblProcessedTitle, lblProcessedValue, lblProcessedAction, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeCard(cardSerious, lblSeriousTitle, lblSeriousValue, lblSeriousAction, startX, y, cardWidth, cardHeight, cardPadding);
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

        private static void ArrangeCard(Panel card, Label lblTitle, Label lblValue, Label lblAction, int x, int y, int width, int height, int padding)
        {
            card.Location = new Point(x, y);
            card.Size = new Size(width, height);
            lblTitle.Location = new Point(padding, padding);
            lblValue.Location = new Point(padding, padding + 30);
            lblAction.Location = new Point(padding, padding + 80);
        }

        private async void ucViolationManagement_Load(object sender, EventArgs e)
        {
            this.mainForm = this.FindForm();
            SetupGridColumns();
            await LoadDataAsync();
            await UpdateKPICards();
        }

        private void SetupGridColumns()
        {
            dgvViolations.Columns.Clear();
            dgvViolations.Columns.Add("StudentId", "Mã SV");
            dgvViolations.Columns.Add("StudentName", "Tên Sinh viên");
            dgvViolations.Columns.Add("RoomNumber", "Phòng");
            dgvViolations.Columns.Add("ViolationType", "Loại vi phạm");
            dgvViolations.Columns.Add("ReportDate", "Ngày lập");
            dgvViolations.Columns.Add("Status", "Trạng thái");

            dgvViolations.Columns["ReportDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvViolations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                var violations = await ApiService.GetViolationsAsync(status ?? "Tất cả", search);

                if (token.IsCancellationRequested) return;

                dgvViolations.Rows.Clear();
                if (violations != null)
                {
                    foreach (var v in violations)
                    {
                        dgvViolations.Rows.Add(
                            v.StudentId,
                            v.StudentName,
                            v.RoomNumber,
                            v.ViolationType,
                            v.ReportDate,
                            v.Status
                        );
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
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu vi phạm: {ex.Message}");
                }
            }
            finally
            {
                isLoading = false;
            }
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

        private async Task UpdateKPICards()
        {
            try
            {
                var kpiData = await ApiService.GetViolationKPIsAsync();

                if (kpiData != null)
                {
                    lblUnprocessedValue.Text = kpiData.UnprocessedCount.ToString();
                    lblProcessedValue.Text = kpiData.ProcessedCount.ToString();
                    lblSeriousValue.Text = kpiData.SeriousCount.ToString();
                }
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu KPI vi phạm: {ex.Message}");
                }
            }
        }

        private void btnAddViolation_Click(object sender, EventArgs e)
        {
            if (this.mainForm != null)
            {
                UiHelper.ShowSuccess(this.mainForm, "Chức năng Thêm vi phạm (chưa hoàn thiện)");
            }
        }

    }
}
