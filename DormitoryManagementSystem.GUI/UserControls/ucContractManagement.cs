using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucContractManagement : UserControl
    {
        private Form? mainForm;

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
            UiHelper.ShowLoading(this);
            try
            {
                string status = cmbFilterStatus.SelectedIndex > 0 ? cmbFilterStatus.SelectedItem.ToString() : "Tất cả";
                string search = txtSearch.Text;

                var contracts = await ApiService.GetContractsAsync(status, search);

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
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu hợp đồng: {ex.Message}");
            }
            finally
            {
                UiHelper.HideLoading(this);
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            UiHelper.ShowSuccess(this.mainForm, "Chức năng Thêm hợp đồng (chưa hoàn thiện)");
        }
    }
}
