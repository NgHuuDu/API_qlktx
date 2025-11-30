using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Forms;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucContractManagement : UserControl
    {
        private Form? mainForm;
        private bool isLoading = false;
        private CancellationTokenSource? cancellationTokenSource;
        
        // Filter state
        private string? currentFilterBuilding = null;
        private string? currentFilterStatus = null;
        private DateTime? currentStartDate = null;
        private DateTime? currentEndDate = null;

        public ucContractManagement()
        {
            InitializeComponent();
        }

        private async void ucContractManagement_Load(object sender, EventArgs e)
        {
            this.mainForm = this.FindForm();
            SetupGridColumns();
            AdjustSearchLayout();
            this.Resize += (s, args) => AdjustSearchLayout();
            await LoadDataAsync();
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
            dgvContracts.Columns.Clear();
            dgvContracts.ReadOnly = true;
            dgvContracts.Columns.Add("ContractID", "Mã hợp đồng");
            dgvContracts.Columns.Add("StudentID", "Mã SV");
            dgvContracts.Columns.Add("StudentName", "Tên Sinh viên");
            dgvContracts.Columns.Add("RoomID", "Mã phòng");
            dgvContracts.Columns.Add("RoomNumber", "Số phòng");
            dgvContracts.Columns.Add("StaffUserID", "Mã nhân viên");
            dgvContracts.Columns.Add("StartTime", "Ngày bắt đầu");
            dgvContracts.Columns.Add("EndTime", "Ngày kết thúc");
            dgvContracts.Columns.Add("Status", "Trạng thái");
            dgvContracts.Columns.Add("CreatedDate", "Ngày tạo");

            var btnColumn = new DataGridViewButtonColumn
            {
                Name = "Detail",
                HeaderText = "Thao tác",
                Text = "Chi tiết",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvContracts.Columns.Add(btnColumn);

            dgvContracts.Columns["StartTime"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContracts.Columns["EndTime"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContracts.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContracts.CellContentClick += DgvContracts_CellContentClick;
        }

        private void DgvContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            if (dgvContracts.Columns[e.ColumnIndex].Name == "Detail")
            {
                string contractId = dgvContracts.Rows[e.RowIndex].Cells["ContractID"].Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(contractId))
                {
                    ShowContractDetail(contractId);
                }
            }
        }

        private async void ShowContractDetail(string contractId)
        {
            using var form = new Forms.frmContractDetail(contractId);
            if (form.ShowDialog() == DialogResult.OK && form.IsSuccess)
            {
                await LoadDataAsync();
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
                
                string status = currentFilterStatus ?? "Tất cả";
                string search = string.IsNullOrWhiteSpace(txtSearch.Text) ? string.Empty : txtSearch.Text;
                var contracts = await ApiService.GetContractsAsync(status, search);

                if (token.IsCancellationRequested) return;

                // Apply additional filters
                if (contracts != null && contracts.Any())
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
                            
                            contracts = contracts
                                .Where(c => !string.IsNullOrEmpty(c.RoomId) && roomIdsInBuilding.Contains(c.RoomId))
                                .ToList();
                        }
                        catch
                        {
                            // If error loading rooms, skip building filter
                        }
                    }
                    
                    // Apply date filters - find contracts where both StartDate and EndDate are within the filter range
                    if (currentStartDate.HasValue || currentEndDate.HasValue)
                    {
                        DateTime filterStart = currentStartDate ?? DateTime.MinValue;
                        DateTime filterEnd = currentEndDate ?? DateTime.MaxValue;
                        
                        contracts = contracts.Where(c =>
                        {
                            // Both StartDate and EndDate must be within the filter range
                            bool startDateInRange = c.StartDate.Date >= filterStart.Date && c.StartDate.Date <= filterEnd.Date;
                            bool endDateInRange = c.EndDate.Date >= filterStart.Date && c.EndDate.Date <= filterEnd.Date;
                            
                            return startDateInRange && endDateInRange;
                        }).ToList();
                    }
                }

                dgvContracts.Rows.Clear();
                if (contracts != null)
                {
                    foreach (var contract in contracts)
                    {
                        dgvContracts.Rows.Add(
                            contract.ContractId,
                            contract.StudentId,
                            contract.StudentName,
                            contract.RoomId ?? string.Empty,
                            contract.RoomNumber,
                            contract.StaffUserID ?? string.Empty,
                            contract.StartDate,
                            contract.EndDate,
                            contract.Status,
                            contract.CreatedDate
                        );
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu hợp đồng: {ex.Message}");
                }
            }
            finally
            {
                isLoading = false;
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            using var filterForm = new Forms.frmFilterContract(
                currentFilterBuilding,
                currentFilterStatus,
                currentStartDate,
                currentEndDate);
            
            if (filterForm.ShowDialog(this) == DialogResult.OK && filterForm.IsApplied)
            {
                currentFilterBuilding = filterForm.SelectedBuilding;
                currentFilterStatus = filterForm.SelectedStatus;
                currentStartDate = filterForm.StartDate;
                currentEndDate = filterForm.EndDate;
                
                await LoadDataAsync();
            }
        }

        private async void btnAddContract_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.frmAddContract())
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.IsSuccess)
                {
                    await LoadDataAsync();
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

    }
}
