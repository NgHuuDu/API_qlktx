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
        private System.Threading.Timer? searchTimer;
        
        // Filter state
        private string? currentFilterBuilding = null;
        private string? currentFilterViolationType = null;
        private string? currentFilterStatus = null;
        private string? currentFilterReportedByUserID = null;
        private DateTime? currentViolationDateFrom = null;
        private DateTime? currentViolationDateTo = null;
        private string? currentFilterStudentID = null;
        private string? currentFilterRoomID = null;
        private decimal? currentPenaltyFeeFrom = null;
        private decimal? currentPenaltyFeeTo = null;
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
            AdjustSearchLayout();
            this.Resize += (s, args) => AdjustSearchLayout();
            
            // Add TextChanged event for txtSearch with debounce
            txtSearch.TextChanged += txtSearch_TextChanged;
            
            await LoadDataAsync();
            await UpdateKPICards();
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            // Debounce: Clear existing timer and create new one
            searchTimer?.Dispose();
            searchTimer = new System.Threading.Timer(_ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => 
                    {
                        await LoadDataAsync();
                    }));
                }
                else
                {
                    _ = LoadDataAsync();
                }
            }, null, 500, Timeout.Infinite); // Wait 500ms after user stops typing
        }

        private void AdjustSearchLayout()
        {
            if (btnSearch != null && txtSearch != null && pnlFilters != null)
            {
                int spacing = 10;
                int txtSearchRight = btnSearch.Left - spacing;
                int newWidth = txtSearchRight - txtSearch.Left;
                
                if (newWidth >= 200)
                {
                    txtSearch.Width = newWidth;
                }
            }
        }

        private void SetupGridColumns()
        {
            dgvViolations.Columns.Clear();
            dgvViolations.ReadOnly = true;
            dgvViolations.Columns.Add("ViolationId", "Mã vi phạm");
            dgvViolations.Columns.Add("StudentId", "Mã SV");
            dgvViolations.Columns.Add("StudentName", "Tên Sinh viên");
            dgvViolations.Columns.Add("RoomID", "Mã phòng");
            dgvViolations.Columns.Add("RoomNumber", "Số phòng");
            dgvViolations.Columns.Add("ReportedByUserID", "Người báo cáo");
            dgvViolations.Columns.Add("ViolationType", "Loại vi phạm");
            dgvViolations.Columns.Add("ViolationDate", "Ngày vi phạm");
            dgvViolations.Columns.Add("PenaltyFee", "Phí phạt");
            dgvViolations.Columns.Add("Status", "Trạng thái");

            // Format columns
            dgvViolations.Columns["ViolationDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvViolations.Columns["PenaltyFee"].DefaultCellStyle.Format = "N0"; // Number format
            dgvViolations.Columns["PenaltyFee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            // Set column widths
            dgvViolations.Columns["ViolationId"].Width = 120;
            dgvViolations.Columns["StudentId"].Width = 100;
            dgvViolations.Columns["StudentName"].Width = 150;
            dgvViolations.Columns["RoomID"].Width = 100;
            dgvViolations.Columns["RoomNumber"].Width = 100;
            dgvViolations.Columns["ReportedByUserID"].Width = 120;
            dgvViolations.Columns["ViolationType"].Width = 200;
            dgvViolations.Columns["ViolationDate"].Width = 120;
            dgvViolations.Columns["PenaltyFee"].Width = 120;
            dgvViolations.Columns["Status"].Width = 120;

            var btnColumn = new DataGridViewButtonColumn
            {
                Name = "Detail",
                HeaderText = "Thao tác",
                Text = "Chi tiết",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvViolations.Columns.Add(btnColumn);
            
            dgvViolations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViolations.CellContentClick += DgvViolations_CellContentClick;
        }

        private void DgvViolations_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            if (dgvViolations.Columns[e.ColumnIndex].Name == "Detail")
            {
                string violationId = dgvViolations.Rows[e.RowIndex].Cells["ViolationId"].Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(violationId))
                {
                    ShowViolationDetail(violationId);
                }
            }
        }

        private async void ShowViolationDetail(string violationId)
        {
            if (this.mainForm == null) return;
            
            using var form = new Forms.frmViolationDetail(violationId);
            if (form.ShowDialog(this.mainForm) == DialogResult.OK && form.IsSuccess)
            {
                await LoadDataAsync();
                await UpdateKPICards();
            }
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
                
                // txtSearch is for general search (student ID, name, room, violation type)
                string searchText = string.IsNullOrWhiteSpace(txtSearch.Text) ? string.Empty : txtSearch.Text.Trim();

                string status = currentFilterStatus ?? "Tất cả";
                var violations = await ApiService.GetViolationsAsync(status, searchText);

                if (token.IsCancellationRequested) return;

                // Apply additional filters that API doesn't handle
                if (violations != null && violations.Any())
                {
                    // Filter by building - need to get rooms to match BuildingID
                    if (!string.IsNullOrEmpty(currentFilterBuilding))
                    {
                        try
                        {
                            var rooms = await ApiService.GetRoomsAsync("Tất cả", "Tất cả", "");
                            var roomIdsInBuilding = rooms
                                .Where(r => r.BuildingId == currentFilterBuilding)
                                .Select(r => r.RoomId)
                                .ToHashSet();
                            
                            violations = violations
                                .Where(v => !string.IsNullOrEmpty(v.RoomNumber) && roomIdsInBuilding.Contains(v.RoomNumber))
                                .ToList();
                        }
                        catch
                        {
                            // If error loading rooms, skip building filter
                        }
                    }
                    
                    // Filter by reported by user ID
                    if (!string.IsNullOrEmpty(currentFilterReportedByUserID))
                    {
                        violations = violations.Where(v =>
                            !string.IsNullOrEmpty(v.ReportedByUserID) &&
                            v.ReportedByUserID.Contains(currentFilterReportedByUserID, StringComparison.OrdinalIgnoreCase)
                        ).ToList();
                    }
                    
                    // Filter by date range
                    if (currentViolationDateFrom.HasValue || currentViolationDateTo.HasValue)
                    {
                        DateTime filterStart = currentViolationDateFrom ?? DateTime.MinValue;
                        DateTime filterEnd = currentViolationDateTo ?? DateTime.MaxValue;
                        
                        violations = violations.Where(v =>
                            v.ViolationDate.Date >= filterStart.Date && v.ViolationDate.Date <= filterEnd.Date
                        ).ToList();
                    }
                    
                    // Filter by violation type if specified in filter form
                    // This is separate from txtSearch - txtSearch searches in all fields
                    if (!string.IsNullOrWhiteSpace(currentFilterViolationType))
                    {
                        violations = violations.Where(v =>
                            v.ViolationType.Contains(currentFilterViolationType, StringComparison.OrdinalIgnoreCase)
                        ).ToList();
                    }
                    
                    // Filter by StudentID
                    if (!string.IsNullOrWhiteSpace(currentFilterStudentID))
                    {
                        violations = violations.Where(v =>
                            !string.IsNullOrEmpty(v.StudentId) &&
                            v.StudentId.Contains(currentFilterStudentID, StringComparison.OrdinalIgnoreCase)
                        ).ToList();
                    }
                    
                    // Filter by RoomID
                    if (!string.IsNullOrWhiteSpace(currentFilterRoomID))
                    {
                        violations = violations.Where(v =>
                            !string.IsNullOrEmpty(v.RoomID) &&
                            v.RoomID.Contains(currentFilterRoomID, StringComparison.OrdinalIgnoreCase)
                        ).ToList();
                    }
                    
                    // Filter by PenaltyFee range
                    if (currentPenaltyFeeFrom.HasValue)
                    {
                        violations = violations.Where(v => v.PenaltyFee >= currentPenaltyFeeFrom.Value).ToList();
                    }
                    if (currentPenaltyFeeTo.HasValue)
                    {
                        violations = violations.Where(v => v.PenaltyFee <= currentPenaltyFeeTo.Value).ToList();
                    }
                }

                dgvViolations.Rows.Clear();
                if (violations != null)
                {
                    foreach (var v in violations)
                    {
                        dgvViolations.Rows.Add(
                            v.ViolationId,
                            v.StudentId,
                            v.StudentName,
                            v.RoomID,
                            v.RoomNumber,
                            v.ReportedByUserID ?? string.Empty,
                            v.ViolationType,
                            v.ViolationDate,
                            v.PenaltyFee,
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
            if (this.mainForm == null) return;

            using (var filterForm = new Forms.frmFilterViolation(
                currentFilterBuilding,
                currentFilterViolationType,
                currentFilterStatus,
                currentFilterReportedByUserID,
                currentViolationDateFrom,
                currentViolationDateTo,
                currentFilterStudentID,
                currentFilterRoomID,
                currentPenaltyFeeFrom,
                currentPenaltyFeeTo))
            {
                if (filterForm.ShowDialog(this.mainForm) == DialogResult.OK && filterForm.IsApplied)
                {
                    // Lưu các giá trị bộ lọc
                    currentFilterBuilding = filterForm.SelectedBuilding;
                    currentFilterViolationType = filterForm.SelectedViolationType;
                    currentFilterStatus = filterForm.SelectedStatus;
                    currentFilterReportedByUserID = filterForm.SelectedReportedByUserID;
                    currentViolationDateFrom = filterForm.ViolationDateFrom;
                    currentViolationDateTo = filterForm.ViolationDateTo;
                    currentFilterStudentID = filterForm.SelectedStudentID;
                    currentFilterRoomID = filterForm.SelectedRoomID;
                    currentPenaltyFeeFrom = filterForm.PenaltyFeeFrom;
                    currentPenaltyFeeTo = filterForm.PenaltyFeeTo;
                    
                    // Don't change txtSearch - keep it separate for general search
                    // Violation type filter is applied separately in LoadDataAsync

                    await LoadDataAsync();
                    await UpdateKPICards();
                }
            }
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

        private async void btnAddViolation_Click(object sender, EventArgs e)
        {
            if (this.mainForm == null) return;

            using (var addForm = new Forms.frmAddViolation())
            {
                if (addForm.ShowDialog(this.mainForm) == DialogResult.OK && addForm.IsSuccess)
                {
                    // Reload data sau khi add
                    await LoadDataAsync();
                    await UpdateKPICards();
                    UiHelper.ShowSuccess(this.mainForm, "Thêm vi phạm thành công!");
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

    }
}
