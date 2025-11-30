using DormitoryManagementSystem.API.Models;
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
        private System.Threading.Timer? filterTimer;

        public ucContractManagement()
        {
            InitializeComponent();
        }

        private async void ucContractManagement_Load(object sender, EventArgs e)
        {
            this.mainForm = this.FindForm();
            SetupGridColumns();
            await LoadDataAsync();
        }

        private void SetupGridColumns()
        {
            dgvContracts.Columns.Clear();
            dgvContracts.Columns.Add("StudentId", "Mã SV");
            dgvContracts.Columns.Add("StudentName", "Tên Sinh viên");
            dgvContracts.Columns.Add("RoomNumber", "Số phòng");
            dgvContracts.Columns.Add("StartDate", "Ngày bắt đầu");
            dgvContracts.Columns.Add("EndDate", "Ngày kết thúc");
            dgvContracts.Columns.Add("Status", "Trạng thái");

            dgvContracts.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContracts.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                var contracts = await ApiService.GetContractsAsync(status ?? "Tất cả", search);

                if (token.IsCancellationRequested) return;

                dgvContracts.Rows.Clear();
                if (contracts != null)
                {
                    foreach (var contract in contracts)
                    {
                        dgvContracts.Rows.Add(
                            contract.StudentId,
                            contract.StudentName,
                            contract.RoomNumber,
                            contract.StartDate,
                            contract.EndDate,
                            contract.Status
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
                        if (btnFilter != null) btnFilter.Enabled = true;
                    }));
                }
                else
                {
                    LoadDataAsync().ContinueWith(_ =>
                    {
                        if (btnFilter != null) btnFilter.Enabled = true;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }, null, 300, Timeout.Infinite);
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            if (this.mainForm != null)
            {
                UiHelper.ShowSuccess(this.mainForm, "Chức năng Thêm hợp đồng (chưa hoàn thiện)");
            }
        }

    }
}
