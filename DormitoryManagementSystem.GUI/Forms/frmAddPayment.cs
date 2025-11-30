using DormitoryManagementSystem.DTO.Payments;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmAddPayment : Form
    {
        public bool IsSuccess { get; private set; }

        public frmAddPayment()
        {
            InitializeComponent();
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                await LoadContractsAsync();
                LoadPaymentMethodOptions();
                LoadPaymentStatusOptions();
                dtpPaymentDate.Value = DateTime.Now;
                numBillMonth.Value = DateTime.Now.Month;
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải dữ liệu: {ex.Message}");
            }
        }

        private async Task LoadContractsAsync()
        {
            try
            {
                var contracts = await ApiService.GetContractsAsync("Tất cả", "");
                cmbContractID.Items.Clear();
                if (contracts != null && contracts.Any())
                {
                    foreach (var contract in contracts)
                    {
                        cmbContractID.Items.Add($"{contract.ContractId} - {contract.StudentName}");
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải danh sách hợp đồng: {ex.Message}");
            }
        }

        private void LoadPaymentMethodOptions()
        {
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("Bank Transfer");
            cmbPaymentMethod.Items.Add("Online");
        }

        private void LoadPaymentStatusOptions()
        {
            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.Add("Unpaid");
            cmbPaymentStatus.Items.Add("Paid");
            cmbPaymentStatus.Items.Add("Late");
            cmbPaymentStatus.Items.Add("Refunded");
            cmbPaymentStatus.SelectedIndex = 0; // Mặc định là Unpaid
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtPaymentID.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập mã thanh toán");
                txtPaymentID.Focus();
                return;
            }

            // Kiểm tra PaymentID trùng lặp
            try
            {
                var existingPayment = await ApiService.GetPaymentByIdAsync(txtPaymentID.Text.Trim());
                if (existingPayment != null)
                {
                    UiHelper.ShowError(this, $"Mã thanh toán {txtPaymentID.Text.Trim()} đã tồn tại. Vui lòng chọn mã khác.");
                    txtPaymentID.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                // Nếu lỗi khi check (có thể do API không có), tiếp tục tạo mới
                // BUS layer sẽ validate lại
            }

            if (cmbContractID.SelectedIndex < 0)
            {
                UiHelper.ShowError(this, "Vui lòng chọn hợp đồng");
                cmbContractID.Focus();
                return;
            }

            if (numPaymentAmount.Value <= 0)
            {
                UiHelper.ShowError(this, "Số tiền cần đóng phải lớn hơn 0");
                numPaymentAmount.Focus();
                return;
            }

            if (numPaidAmount.Value < 0)
            {
                UiHelper.ShowError(this, "Số tiền đã đóng không được là số âm");
                numPaidAmount.Focus();
                return;
            }

            if (numPaidAmount.Value > numPaymentAmount.Value)
            {
                UiHelper.ShowError(this, "Số tiền đã đóng không được lớn hơn số tiền cần đóng");
                numPaidAmount.Focus();
                return;
            }

            // Trích xuất ContractID từ mục đã chọn
            string selectedItem = cmbContractID.SelectedItem?.ToString() ?? "";
            string contractID = selectedItem.Split('-')[0].Trim();

            // Tạo DTO
            var dto = new PaymentCreateDTO
            {
                PaymentID = txtPaymentID.Text.Trim(),
                ContractID = contractID,
                BillMonth = (int)numBillMonth.Value,
                PaymentAmount = numPaymentAmount.Value,
                PaidAmount = numPaidAmount.Value,
                PaymentDate = dtpPaymentDate.Value,
                PaymentMethod = cmbPaymentMethod.SelectedItem?.ToString(),
                PaymentStatus = cmbPaymentStatus.SelectedItem?.ToString() ?? "Unpaid",
                Description = txtDescription.Text.Trim()
            };

            // Lưu thanh toán
            try
            {
                var (success, errorMessage) = await ApiService.CreatePaymentAsync(dto);
                if (success)
                {
            IsSuccess = true;
                    UiHelper.ShowSuccess(this, "Tạo thanh toán thành công!");
            this.DialogResult = DialogResult.OK;
            this.Close();
                }
                else
                {
                    UiHelper.ShowError(this, errorMessage ?? "Lỗi khi tạo thanh toán");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi khi tạo thanh toán: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
