using DormitoryManagementSystem.DTO.Violations;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmViolationDetail : Form
    {
        private string violationId;
        private ViolationReadDTO? originalData;
        public bool IsSuccess { get; private set; }

        public frmViolationDetail(string violationId)
        {
            InitializeComponent();
            this.violationId = violationId;
            _ = LoadViolationDetailAsync();
        }

        private async Task LoadViolationDetailAsync()
        {
            try
            {
                originalData = await ApiService.GetViolationByIdAsync(violationId);
                if (originalData == null)
                {
                    UiHelper.ShowError(this, "Không tìm thấy thông tin vi phạm.");
                    this.Close();
                    return;
                }

                // Tải dữ liệu vào form
                txtViolationID.Text = originalData.ViolationID;
                txtStudentID.Text = originalData.StudentID ?? string.Empty;
                txtStudentName.Text = originalData.StudentName ?? string.Empty;
                txtRoom.Text = originalData.RoomID;
                txtViolationType.Text = originalData.ViolationType;
                dtpViolationDate.Value = originalData.ViolationDate;
                txtDescriptionDetail.Text = string.Empty; // Mô tả không có trong DTO
                txtReportedByUserID.Text = originalData.ReportedByUserID ?? string.Empty;
                numPenaltyFee.Value = originalData.PenaltyFee;

                // Thiết lập trạng thái
                LoadStatusOptions();
                var statusIndex = GetStatusIndex(originalData.Status);
                if (statusIndex >= 0)
                {
                    cmbStatus.SelectedIndex = statusIndex;
                }

                SetReadOnly(true);
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải thông tin vi phạm: {ex.Message}");
            }
        }

        private int GetStatusIndex(string status)
        {
            if (string.IsNullOrEmpty(status)) return -1;
            
            if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase) || 
                status.Contains("Chưa", StringComparison.OrdinalIgnoreCase))
                return 0;
            if (status.Equals("Resolved", StringComparison.OrdinalIgnoreCase) || 
                status.Contains("Đã xử lý", StringComparison.OrdinalIgnoreCase))
                return 1;
            if (status.Equals("Paid", StringComparison.OrdinalIgnoreCase) || 
                status.Contains("Đã thanh toán", StringComparison.OrdinalIgnoreCase))
                return 2;
            return -1;
        }

        private string GetStatusFromIndex(int index)
        {
            return index switch
            {
                0 => "Pending",
                1 => "Resolved",
                2 => "Paid",
                _ => "Pending"
            };
        }

        private void LoadStatusOptions()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Chưa xử lý");
            cmbStatus.Items.Add("Đã xử lý");
            cmbStatus.Items.Add("Đã thanh toán");
        }

        private void SetReadOnly(bool readOnly)
        {
            txtViolationID.ReadOnly = true;
            txtStudentName.ReadOnly = true;
            txtStudentID.ReadOnly = true;
            txtRoom.ReadOnly = true;
            txtReportedByUserID.ReadOnly = true;
            dtpViolationDate.Enabled = false;
            
            // Chỉ cho phép sửa: PenaltyFee, Status, ViolationType, Description
            txtViolationType.ReadOnly = readOnly;
            txtDescriptionDetail.ReadOnly = readOnly;
            cmbStatus.Enabled = !readOnly;
            numPenaltyFee.Enabled = !readOnly;

            btnClose.Visible = readOnly;
            btnEdit.Visible = readOnly;
            btnCancel.Visible = !readOnly;
            btnApply.Visible = !readOnly;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            await LoadViolationDetailAsync(); // Reload original data
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtViolationType.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập loại vi phạm.");
                txtViolationType.Focus();
                return;
            }

            if (cmbStatus.SelectedIndex < 0)
            {
                UiHelper.ShowError(this, "Vui lòng chọn trạng thái.");
                cmbStatus.Focus();
                return;
            }

            // Validate PenaltyFee
            if (numPenaltyFee.Value < 0)
            {
                UiHelper.ShowError(this, "Phí phạt không được là số âm.");
                numPenaltyFee.Focus();
                return;
            }

            try
            {
                var dto = new ViolationUpdateDTO
                {
                    ViolationType = txtViolationType.Text.Trim(),
                    StudentID = string.IsNullOrWhiteSpace(txtStudentID.Text) ? null : txtStudentID.Text.Trim(),
                    PenaltyFee = numPenaltyFee.Value,
                    Status = GetStatusFromIndex(cmbStatus.SelectedIndex)
                };

                var (success, errorMessage) = await ApiService.UpdateViolationAsync(violationId, dto);
                if (success)
                {
                    IsSuccess = true;
                    SetReadOnly(true);
                    UiHelper.ShowSuccess(this, "Cập nhật vi phạm thành công!");
                    await LoadViolationDetailAsync(); // Reload to get updated data
                }
                else
                {
                    UiHelper.ShowError(this, errorMessage ?? "Cập nhật vi phạm thất bại.");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi khi cập nhật vi phạm: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
