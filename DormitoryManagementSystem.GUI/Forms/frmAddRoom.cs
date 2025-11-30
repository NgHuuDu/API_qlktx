using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmAddRoom : Form
    {
        public bool IsSuccess { get; private set; }

        public frmAddRoom()
        {
            InitializeComponent();
            LoadBuildings();
        }

        private async void LoadBuildings()
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
                    if (cmbBuilding.Items.Count > 0)
                        cmbBuilding.SelectedIndex = 0;
                }
                else
                {
                    cmbBuilding.Items.Add("BLD_A");
                    cmbBuilding.Items.Add("BLD_B");
                    cmbBuilding.Items.Add("BLD_C");
                    cmbBuilding.Items.Add("BLD_D");
                    if (cmbBuilding.Items.Count > 0)
                        cmbBuilding.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải danh sách tòa: {ex.Message}");
                cmbBuilding.Items.Add("BLD_A");
                cmbBuilding.Items.Add("BLD_B");
                cmbBuilding.Items.Add("BLD_C");
                cmbBuilding.Items.Add("BLD_D");
                if (cmbBuilding.Items.Count > 0)
                    cmbBuilding.SelectedIndex = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            // Kiểm tra RoomID trùng lặp
            try
            {
                var existingRoom = await ApiService.GetRoomByIdAsync(txtRoomID.Text.Trim());
                if (existingRoom != null)
                {
                    UiHelper.ShowError(this, $"Mã phòng {txtRoomID.Text.Trim()} đã tồn tại. Vui lòng chọn mã khác.");
                    txtRoomID.Focus();
                    return;
                }
            }
            catch
            {
                // Nếu lỗi khi check (có thể do API không có), tiếp tục tạo mới
                // BUS layer sẽ validate lại
            }

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

                var dto = new RoomCreateDTO
                {
                    RoomID = txtRoomID.Text.Trim(),
                    RoomNumber = int.Parse(txtRoomNumber.Text.Trim()),
                    BuildingID = buildingID,
                    Capacity = int.Parse(cmbCapacity.SelectedItem?.ToString() ?? "2"),
                    Price = decimal.Parse(txtPrice.Text.Trim()),
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Active",
                    AllowCooking = chkAllowCooking.Checked,
                    AirConditioner = chkAirConditioner.Checked
                };

                var (success, errorMessage) = await ApiService.CreateRoomAsync(dto);
                if (success)
                {
                    IsSuccess = true;
                    UiHelper.ShowSuccess(this, "Thêm phòng thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    UiHelper.ShowError(this, errorMessage ?? "Thêm phòng thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi: {ex.Message}");
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtRoomID.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập mã phòng.");
                txtRoomID.Focus();
                return false;
            }

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

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                UiHelper.ShowError(this, "Giá phòng phải là số dương.");
                txtPrice.Focus();
                return false;
            }

            return true;
        }
    }
}

