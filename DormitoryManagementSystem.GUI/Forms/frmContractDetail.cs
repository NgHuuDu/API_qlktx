using DormitoryManagementSystem.DTO.Contracts;
using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmContractDetail : Form
    {
        private string contractId;
        private bool isEditMode = false;
        private ContractReadDTO? originalContract;
        private RoomReadDTO? currentRoom;
        public bool IsSuccess { get; private set; }

        public frmContractDetail(string contractId)
        {
            InitializeComponent();
            this.contractId = contractId;
            _ = LoadContractDetail();
        }

        private async Task LoadContractDetail()
        {
            try
            {
                originalContract = await ApiService.GetContractByIdAsync(contractId);
                if (originalContract == null)
                {
                    UiHelper.ShowError(this, "Không tìm thấy thông tin hợp đồng.");
                    this.Close();
                    return;
                }

                await LoadRooms();
                await LoadRoomInfo(originalContract.RoomID);
                PopulateFields(originalContract);
                SetReadOnly(true);
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải thông tin hợp đồng: {ex.Message}");
            }
        }

        private async Task LoadRooms()
        {
            try
            {
                var rooms = await ApiService.GetRoomsAsync("Tất cả", "Tất cả", "");
                cmbRoomID.Items.Clear();
                
                if (rooms != null && rooms.Any())
                {
                    foreach (var room in rooms)
                    {
                        cmbRoomID.Items.Add($"{room.RoomNumber} - {room.Building} ({room.RoomId})");
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải danh sách phòng: {ex.Message}");
            }
        }

        private async Task LoadRoomInfo(string roomId)
        {
            try
            {
                var room = await ApiService.GetRoomByIdAsync(roomId);
                if (room != null)
                {
                    currentRoom = room;
                    txtRoomNumber.Text = room.RoomNumber.ToString();
                    txtPrice.Text = room.Price.ToString("N0");
                }
                else
                {
                    txtRoomNumber.Clear();
                    txtPrice.Clear();
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải thông tin phòng: {ex.Message}");
            }
        }

        private string ExtractID(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            
            if (text.Contains("(") && text.Contains(")"))
            {
                int start = text.IndexOf("(") + 1;
                int end = text.IndexOf(")");
                if (start > 0 && end > start)
                    return text.Substring(start, end - start);
            }
            return text;
        }

        private void PopulateFields(ContractReadDTO contract)
        {
            txtContractID.Text = contract.ContractID;
            txtStudentID.Text = contract.StudentID;
            txtStudentName.Text = contract.StudentName;
            
            for (int i = 0; i < cmbRoomID.Items.Count; i++)
            {
                string item = cmbRoomID.Items[i].ToString();
                if (item.Contains($"({contract.RoomID})"))
                {
                    cmbRoomID.SelectedIndex = i;
                    break;
                }
            }
            
            txtStaffUserID.Text = contract.StaffUserID ?? string.Empty;
            dtpStartTime.Value = contract.StartTime.ToDateTime(TimeOnly.MinValue);
            dtpEndTime.Value = contract.EndTime.ToDateTime(TimeOnly.MinValue);
            
            for (int i = 0; i < cmbStatus.Items.Count; i++)
            {
                if (cmbStatus.Items[i].ToString() == contract.Status)
                {
                    cmbStatus.SelectedIndex = i;
                    break;
                }
            }
            
            txtCreatedDate.Text = contract.CreatedDate.ToString("dd/MM/yyyy HH:mm");
        }

        private void SetReadOnly(bool readOnly)
        {
            txtContractID.ReadOnly = true;
            txtStudentID.ReadOnly = true;
            txtStudentName.ReadOnly = true;
            cmbRoomID.Enabled = !readOnly;
            txtRoomNumber.ReadOnly = true;
            txtStaffUserID.ReadOnly = readOnly;
            dtpStartTime.Enabled = !readOnly;
            dtpEndTime.Enabled = !readOnly;
            cmbStatus.Enabled = !readOnly;
            txtPrice.ReadOnly = true;
            txtCreatedDate.ReadOnly = true;
            
            btnClose.Visible = readOnly;
            btnEdit.Visible = readOnly;
            btnCancel.Visible = !readOnly;
            btnApply.Visible = !readOnly;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditMode = true;
            SetReadOnly(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isEditMode && originalContract != null)
            {
                var result = UiHelper.ShowConfirm(this, "Bạn có muốn hủy các thay đổi?");
                
                if (result == DialogResult.Yes)
                {
                    PopulateFields(originalContract);
                    isEditMode = false;
                    SetReadOnly(true);
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            if (!await ValidateInput()) return;

            try
            {
                string roomID = ExtractID(cmbRoomID.SelectedItem?.ToString() ?? string.Empty);

                var dto = new ContractUpdateDTO
                {
                    RoomID = roomID,
                    StartTime = DateOnly.FromDateTime(dtpStartTime.Value.Date),
                    EndTime = DateOnly.FromDateTime(dtpEndTime.Value.Date),
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Active"
                };

                var (success, errorMessage) = await ApiService.UpdateContractAsync(contractId, dto);
                if (success)
                {
                    IsSuccess = true;
                    UiHelper.ShowSuccess(this, "Cập nhật hợp đồng thành công!");
                    isEditMode = false;
                    SetReadOnly(true);
                    
                    await Task.Delay(500);
                    await LoadContractDetail();
                }
                else
                {
                    UiHelper.ShowError(this, errorMessage ?? "Cập nhật hợp đồng thất bại.");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi: {ex.Message}");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var result = UiHelper.ShowConfirm(this, 
                $"Bạn có chắc chắn muốn Hủy hợp đồng {txtContractID.Text}?\n\nHành động này không thể hoàn tác!",
                "Xác nhận Hủy hợp đồng");

            if (result == DialogResult.Yes)
            {
                try
                {
                    var (success, errorMessage) = await ApiService.DeleteContractAsync(contractId);
                    if (success)
                    {
                        IsSuccess = true;
                        UiHelper.ShowSuccess(this, "Hủy hợp đồng thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        UiHelper.ShowError(this, errorMessage ?? "Hủy hợp đồng thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    UiHelper.ShowError(this, $"Lỗi: {ex.Message}");
                }
            }
        }

        private async void cmbRoomID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoomID.SelectedItem == null) return;

            try
            {
                string selectedText = cmbRoomID.SelectedItem.ToString();
                string roomID = ExtractID(selectedText);
                await LoadRoomInfo(roomID);
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải thông tin phòng: {ex.Message}");
            }
        }

        private async Task<bool> ValidateInput()
        {
            if (cmbRoomID.SelectedItem == null)
            {
                UiHelper.ShowError(this, "Vui lòng chọn phòng.");
                cmbRoomID.Focus();
                return false;
            }

            // Validate phòng mới có đủ chỗ nếu status là Active
            string newStatus = cmbStatus.SelectedItem?.ToString() ?? "Active";
            if (newStatus == "Active")
            {
                string newRoomID = ExtractID(cmbRoomID.SelectedItem?.ToString() ?? string.Empty);
                if (!string.IsNullOrEmpty(newRoomID))
                {
                    try
                    {
                        var newRoom = await ApiService.GetRoomByIdAsync(newRoomID);
                        if (newRoom != null)
                        {
                            if (newRoom.Status != "Active")
                            {
                                UiHelper.ShowError(this, $"Phòng {newRoomID} không ở trạng thái Active (Status: {newRoom.Status}).");
                                cmbRoomID.Focus();
                                return false;
                            }

                            if (newRoom.IsFull)
                            {
                                UiHelper.ShowError(this, $"Phòng {newRoomID} đã đầy (Sức chứa: {newRoom.Capacity}, Đang ở: {newRoom.CurrentOccupancy}).");
                                cmbRoomID.Focus();
                                return false;
                            }

                            // Nếu chuyển phòng, kiểm tra phòng mới có đủ chỗ cho thêm 1 người
                            if (originalContract != null && originalContract.RoomID != newRoomID)
                            {
                                if (newRoom.CurrentOccupancy >= newRoom.Capacity)
                                {
                                    UiHelper.ShowError(this, $"Phòng {newRoomID} đã đầy, không thể chuyển hợp đồng vào.");
                                    cmbRoomID.Focus();
                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        UiHelper.ShowError(this, $"Lỗi kiểm tra thông tin phòng: {ex.Message}");
                        return false;
                    }
                }
            }

            if (dtpStartTime.Value >= dtpEndTime.Value)
            {
                UiHelper.ShowError(this, "Ngày kết thúc phải sau ngày bắt đầu.");
                dtpEndTime.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                UiHelper.ShowError(this, "Vui lòng chọn trạng thái.");
                cmbStatus.Focus();
                return false;
            }

            return true;
        }
    }
}

