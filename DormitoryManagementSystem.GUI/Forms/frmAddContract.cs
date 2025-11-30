using DormitoryManagementSystem.DTO.Contracts;
using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmAddContract : Form
    {
        public bool IsSuccess { get; private set; }
        private System.Threading.Timer? roomIdTimer;
        private RoomReadDTO? currentRoom;

        public frmAddContract()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                LoadStatusOptions();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải dữ liệu: {ex.Message}");
            }
        }


        private void LoadStatusOptions()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Expired");
            cmbStatus.Items.Add("Terminated");
            cmbStatus.SelectedIndex = 0;
        }

        private void txtRoomID_TextChanged(object sender, EventArgs e)
        {
            roomIdTimer?.Dispose();
            
            if (string.IsNullOrWhiteSpace(txtRoomID.Text)) 
            {
                txtBuildingID.Clear();
                txtRoomNumber.Clear();
                return;
            }

            roomIdTimer = new System.Threading.Timer(async _ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => await LoadRoomInfo()));
                }
                else
                {
                    await LoadRoomInfo();
                }
            }, null, 500, Timeout.Infinite);
        }

        private async Task LoadRoomInfo()
        {
            try
            {
                var room = await ApiService.GetRoomByIdAsync(txtRoomID.Text.Trim());
                if (room != null)
                {
                    currentRoom = room;
                    txtBuildingID.Text = room.BuildingID;
                    txtRoomNumber.Text = room.RoomNumber.ToString();
                    
                    // Kiểm tra và hiển thị cảnh báo nếu phòng không hợp lệ
                    string validationError = ValidateRoomForContract(room);
                    if (!string.IsNullOrEmpty(validationError))
                    {
                        // Có thể hiển thị warning màu vàng hoặc để validation khi save
                        // Ở đây tôi sẽ để validation khi save để tránh spam message
                    }
                }
                else
                {
                    currentRoom = null;
                    txtBuildingID.Clear();
                    txtRoomNumber.Clear();
                }
            }
            catch
            {
                currentRoom = null;
                // Silently fail - user might still be typing
            }
        }

        private string ValidateRoomForContract(RoomReadDTO room)
        {
            if (room.Status.Equals("Maintenance", StringComparison.OrdinalIgnoreCase))
            {
                return "Phòng đang bảo trì, không thể tạo hợp đồng.";
            }

            if (room.Status.Equals("Inactive", StringComparison.OrdinalIgnoreCase))
            {
                return "Phòng đã ngừng hoạt động, không thể tạo hợp đồng.";
            }

            if (room.IsFull)
            {
                return "Phòng đã đầy, không thể tạo hợp đồng.";
            }

            return string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!await ValidateInput())
                return;

            try
            {
                var dto = new ContractCreateDTO
                {
                    ContractID = txtContractID.Text.Trim(),
                    StudentID = txtStudentID.Text.Trim(),
                    RoomID = txtRoomID.Text.Trim(),
                    StartTime = DateOnly.FromDateTime(dtpStartTime.Value.Date),
                    EndTime = DateOnly.FromDateTime(dtpEndTime.Value.Date),
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Active",
                    StaffUserID = GlobalState.CurrentUser?.UserId
                };

                var (success, errorMessage) = await ApiService.CreateContractAsync(dto);
                if (success)
                {
                    IsSuccess = true;
                    UiHelper.ShowSuccess(this, "Tạo hợp đồng thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    UiHelper.ShowError(this, errorMessage ?? "Tạo hợp đồng thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi: {ex.Message}");
            }
        }

        private async Task<bool> ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtContractID.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập mã hợp đồng.");
                txtContractID.Focus();
                return false;
            }

            // Kiểm tra ContractID trùng lặp
            try
            {
                var existingContract = await ApiService.GetContractByIdAsync(txtContractID.Text.Trim());
                if (existingContract != null)
                {
                    UiHelper.ShowError(this, $"Mã hợp đồng {txtContractID.Text.Trim()} đã tồn tại. Vui lòng chọn mã khác.");
                    txtContractID.Focus();
                    return false;
                }
            }
            catch (Exception)
            {
                // Nếu lỗi khi check (có thể do API không có), tiếp tục tạo mới
                // BUS layer sẽ validate lại
            }

            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập mã sinh viên.");
                txtStudentID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập họ và tên.");
                txtFullName.Focus();
                return false;
            }

            if (cmbGender.SelectedItem == null)
            {
                UiHelper.ShowError(this, "Vui lòng chọn giới tính.");
                cmbGender.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập số điện thoại.");
                txtPhoneNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập email.");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập địa chỉ thường trú.");
                txtAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRoomID.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập mã phòng.");
                txtRoomID.Focus();
                return false;
            }

            // Kiểm tra thông tin phòng
            if (currentRoom == null)
            {
                // Thử load lại thông tin phòng nếu chưa có
                try
                {
                    var room = await ApiService.GetRoomByIdAsync(txtRoomID.Text.Trim());
                    if (room == null)
                    {
                        UiHelper.ShowError(this, "Không tìm thấy phòng với mã này.");
                        txtRoomID.Focus();
                        return false;
                    }
                    currentRoom = room;
                }
                catch (Exception ex)
                {
                    UiHelper.ShowError(this, $"Lỗi kiểm tra thông tin phòng: {ex.Message}");
                    txtRoomID.Focus();
                    return false;
                }
            }

            // Validate phòng có thể tạo hợp đồng
            string roomValidationError = ValidateRoomForContract(currentRoom);
            if (!string.IsNullOrEmpty(roomValidationError))
            {
                UiHelper.ShowError(this, roomValidationError);
                txtRoomID.Focus();
                return false;
            }

            if (dtpStartTime.Value >= dtpEndTime.Value)
            {
                UiHelper.ShowError(this, "Ngày kết thúc phải sau ngày bắt đầu.");
                dtpEndTime.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                UiHelper.ShowError(this, "Vui lòng chọn tình trạng hợp đồng.");
                cmbStatus.Focus();
                return false;
            }

            return true;
        }
    }
}

