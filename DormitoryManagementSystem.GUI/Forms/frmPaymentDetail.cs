using DormitoryManagementSystem.DTO.Payments;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmPaymentDetail : Form
    {
        private string paymentId;
        private PaymentReadDTO? originalPayment;
        public bool IsSuccess { get; private set; }

        public frmPaymentDetail(string paymentId)
        {
            InitializeComponent();
            this.paymentId = paymentId;
            _ = LoadPaymentDetailAsync();
        }

        private async Task LoadPaymentDetailAsync()
        {
            try
            {
                originalPayment = await ApiService.GetPaymentByIdAsync(paymentId);
                if (originalPayment == null)
                {
                    UiHelper.ShowError(this, "Không tìm thấy thông tin thanh toán");
                    this.Close();
                    return;
                }

                await LoadContractInfoAsync(originalPayment.ContractID);
                LoadPaymentMethodOptions();
                LoadPaymentStatusOptions();
                PopulateFields(originalPayment);
                SetReadOnly(true);
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải thông tin thanh toán: {ex.Message}");
            }
        }

        private async Task LoadContractInfoAsync(string contractId)
        {
            try
            {
                var contract = await ApiService.GetContractByIdAsync(contractId);
                if (contract != null)
                {
                    txtStudentID.Text = contract.StudentID;
                    txtStudentName.Text = contract.StudentName;
                    txtRoom.Text = contract.RoomNumber;
                }
            }
            catch
            {
                // Silently fail - không cần hiển thị warning cho việc load contract info
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
        }

        private void PopulateFields(PaymentReadDTO payment)
        {
            txtPaymentID.Text = payment.PaymentID;
            txtContractID.Text = payment.ContractID;
            numBillMonth.Value = payment.BillMonth;
            numPaymentAmount.Value = payment.PaymentAmount;
            numPaidAmount.Value = payment.PaidAmount;
            dtpPaymentDate.Value = payment.PaymentDate;
            
            // Thiết lập phương thức thanh toán
            if (!string.IsNullOrEmpty(payment.PaymentMethod))
            {
                for (int i = 0; i < cmbPaymentMethod.Items.Count; i++)
                {
                    if (cmbPaymentMethod.Items[i].ToString() == payment.PaymentMethod)
                    {
                        cmbPaymentMethod.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Thiết lập trạng thái thanh toán
            if (!string.IsNullOrEmpty(payment.PaymentStatus))
            {
                for (int i = 0; i < cmbPaymentStatus.Items.Count; i++)
                {
                    if (cmbPaymentStatus.Items[i].ToString() == payment.PaymentStatus)
                    {
                        cmbPaymentStatus.SelectedIndex = i;
                        break;
                    }
                }
            }

            txtDescription.Text = payment.Description ?? "";
        }

        private void SetReadOnly(bool readOnly)
        {
            txtPaymentID.ReadOnly = true; 
            txtContractID.ReadOnly = true; 
            numBillMonth.Enabled = false; 
            numPaymentAmount.Enabled = false;
            txtStudentID.ReadOnly = true; 
            txtStudentName.ReadOnly = true; 
            txtRoom.ReadOnly = true; 

            numPaidAmount.Enabled = !readOnly;
            cmbPaymentMethod.Enabled = !readOnly;
            dtpPaymentDate.Enabled = !readOnly;
            cmbPaymentStatus.Enabled = !readOnly;
            txtDescription.ReadOnly = readOnly;

            btnClose.Visible = readOnly;
            btnEdit.Visible = readOnly;
            btnCancel.Visible = !readOnly;
            btnApply.Visible = !readOnly;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (originalPayment != null)
            {
                PopulateFields(originalPayment);
            }
            SetReadOnly(true);
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            if (originalPayment == null) return;

            // Kiểm tra dữ liệu
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

            if (cmbPaymentMethod.SelectedIndex < 0)
            {
                UiHelper.ShowError(this, "Vui lòng chọn phương thức thanh toán");
                cmbPaymentMethod.Focus();
                return;
            }

            if (cmbPaymentStatus.SelectedIndex < 0)
            {
                UiHelper.ShowError(this, "Vui lòng chọn trạng thái");
                cmbPaymentStatus.Focus();
                return;
            }

            // Tạo DTO cập nhật
            var updateDto = new PaymentUpdateDTO
            {
                PaidAmount = numPaidAmount.Value,
                PaymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "",
                PaymentStatus = cmbPaymentStatus.SelectedItem?.ToString() ?? "",
                PaymentDate = dtpPaymentDate.Value,
                Description = txtDescription.Text.Trim()
            };

            // Cập nhật thanh toán
            try
            {
                var (success, errorMessage) = await ApiService.UpdatePaymentAsync(paymentId, updateDto);
                if (success)
                {
            IsSuccess = true;
                    await LoadPaymentDetailAsync(); // Tải lại để lấy dữ liệu đã cập nhật
            SetReadOnly(true);
                    UiHelper.ShowSuccess(this, "Cập nhật thanh toán thành công!");
                }
                else
                {
                    UiHelper.ShowError(this, errorMessage ?? "Cập nhật thanh toán thất bại");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi khi cập nhật thanh toán: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
