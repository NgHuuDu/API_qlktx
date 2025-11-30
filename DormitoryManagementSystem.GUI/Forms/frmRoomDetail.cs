using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmRoomDetail : Form
    {
        private string roomId;
        private bool isEditMode = false;
        private RoomReadDTO? originalRoom;
        public bool IsSuccess { get; private set; }

        public frmRoomDetail(string roomId)
        {
            InitializeComponent();
            this.roomId = roomId;
            _ = LoadRoomDetail();
        }

        private async Task LoadRoomDetail()
        {
            try
            {
                originalRoom = await ApiService.GetRoomByIdAsync(roomId);
                if (originalRoom == null)
                {
                    UiHelper.ShowError(this, "Không tìm thấy thông tin phòng.");
                    this.Close();
                    return;
                }

                await LoadBuildings();
                PopulateFields(originalRoom);
                SetReadOnly(true);
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải thông tin phòng: {ex.Message}");
            }
        }

        private async 
        Task
LoadBuildings()
        {
            try
            {
                var buildings = await ApiService.GetBuildingsAsync();
                cmbBuilding.Items.Clear();
                
                if (buildings != null && buildings.Any())
                {
                    foreach (var building in buildings)
                    {
                        cmbBuilding.Items.Add($"{building.BuildingName} ({building.BuildingID})");
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải danh sách tòa: {ex.Message}");
            }
        }

        private void PopulateFields(RoomReadDTO room)
        {
            txtRoomID.Text = room.RoomID;
            txtRoomNumber.Text = room.RoomNumber.ToString();
            
            for (int i = 0; i < cmbBuilding.Items.Count; i++)
            {
                string item = cmbBuilding.Items[i].ToString();
                if (item.Contains($"({room.BuildingID})"))
                {
                    cmbBuilding.SelectedIndex = i;
                    break;
                }
            }
            
            txtFloor.Text = "1";
            
            // Thiết lập sức chứa - tìm mục trong combobox
            string capacityStr = room.Capacity.ToString();
            for (int i = 0; i < cmbCapacity.Items.Count; i++)
            {
                if (cmbCapacity.Items[i].ToString() == capacityStr)
                {
                    cmbCapacity.SelectedIndex = i;
                    break;
                }
            }
            
            txtCurrentOccupancy.Text = room.CurrentOccupancy.ToString();
            
            // Thiết lập trạng thái - tìm mục trong combobox
            for (int i = 0; i < cmbStatus.Items.Count; i++)
            {
                if (cmbStatus.Items[i].ToString() == room.Status)
                {
                    cmbStatus.SelectedIndex = i;
                    break;
                }
            }
            
            txtPrice.Text = room.Price.ToString("N0");
            chkAirConditioner.Checked = room.AirConditioner;
            chkAllowCooking.Checked = room.AllowCooking;
        }

        private void SetReadOnly(bool readOnly)
        {
            txtRoomID.ReadOnly = true;
            txtRoomNumber.ReadOnly = readOnly;
            cmbBuilding.Enabled = true;
            txtFloor.ReadOnly = readOnly;
            cmbCapacity.Enabled = !readOnly;
            txtCurrentOccupancy.ReadOnly = true;
            cmbStatus.Enabled = !readOnly;
            txtPrice.ReadOnly = readOnly;
            chkAirConditioner.Enabled = !readOnly;
            chkAllowCooking.Enabled = !readOnly;
            
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
            if (isEditMode && originalRoom != null)
            {
                var result = UiHelper.ShowConfirm(this, "Bạn có muốn hủy các thay đổi?");
                
                if (result == DialogResult.Yes)
                {
                    PopulateFields(originalRoom);
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
            if (!ValidateInput()) return;

            try
            {
                string selectedBuilding = cmbBuilding.SelectedItem?.ToString() ?? string.Empty;
                string buildingID = selectedBuilding;
                if (selectedBuilding.Contains("(") && selectedBuilding.Contains(")"))
                {
                    int start = selectedBuilding.IndexOf("(") + 1;
                    int end = selectedBuilding.IndexOf(")");
                    if (start > 0 && end > start)
                        buildingID = selectedBuilding.Substring(start, end - start);
                }

                string priceText = txtPrice.Text.Trim().Replace(",", "").Replace(".", "");
                decimal price = decimal.Parse(priceText);

                var dto = new RoomUpdateDTO
                {
                    RoomNumber = int.Parse(txtRoomNumber.Text.Trim()),
                    BuildingID = buildingID,
                    Capacity = int.Parse(cmbCapacity.SelectedItem?.ToString() ?? "2"),
                    Price = price,
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Active",
                    AllowCooking = chkAllowCooking.Checked,
                    AirConditioner = chkAirConditioner.Checked
                };

                var (success, errorMessage) = await ApiService.UpdateRoomAsync(roomId, dto);
                if (success)
                {
                    IsSuccess = true;
                    UiHelper.ShowSuccess(this, "Cập nhật phòng thành công!");
                    isEditMode = false;
                    SetReadOnly(true);
                    
                    // Đợi một chút để đảm bảo database đã commit
                    await Task.Delay(500);
                    await LoadRoomDetail();
                }
                else
                {
                    UiHelper.ShowError(this, errorMessage ?? "Cập nhật phòng thất bại.");
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
                $"Bạn có chắc chắn muốn xóa phòng {txtRoomID.Text}?\n\nHành động này không thể hoàn tác!",
                "Xác nhận xóa phòng");

            if (result == DialogResult.Yes)
            {
                try
                {
                    var (success, errorMessage) = await ApiService.DeleteRoomAsync(roomId);
                    if (success)
                    {
                        IsSuccess = true;
                        UiHelper.ShowSuccess(this, "Xóa phòng thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        UiHelper.ShowError(this, errorMessage ?? "Xóa phòng thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    UiHelper.ShowError(this, $"Lỗi: {ex.Message}");
                }
            }
        }

        private bool ValidateInput()
        {
            if (!int.TryParse(txtRoomNumber.Text, out int roomNumber) || roomNumber <= 0)
            {
                UiHelper.ShowError(this, "Số phòng phải là số nguyên dương.");
                txtRoomNumber.Focus();
                return false;
            }

            if (cmbBuilding.SelectedItem == null)
            {
                UiHelper.ShowError(this, "Vui lòng chọn tòa.");
                cmbBuilding.Focus();
                return false;
            }

            if (cmbCapacity.SelectedItem == null)
            {
                UiHelper.ShowError(this, "Vui lòng chọn sức chứa.");
                cmbCapacity.Focus();
                return false;
            }

            // Validate Capacity không được nhỏ hơn CurrentOccupancy
            if (originalRoom != null)
            {
                int newCapacity = int.Parse(cmbCapacity.SelectedItem?.ToString() ?? "2");
                if (newCapacity < originalRoom.CurrentOccupancy)
                {
                    UiHelper.ShowError(this, $"Không thể giảm sức chứa xuống {newCapacity} vì phòng hiện có {originalRoom.CurrentOccupancy} người đang ở.");
                    cmbCapacity.Focus();
                    return false;
                }
            }

            string priceText = txtPrice.Text.Trim().Replace(",", "").Replace(".", "");
            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
            {
                UiHelper.ShowError(this, "Giá phòng phải là số dương.");
                txtPrice.Focus();
                return false;
            }

            return true;
        }
    }
}

