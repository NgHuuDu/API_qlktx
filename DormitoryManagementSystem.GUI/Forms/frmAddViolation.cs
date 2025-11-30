using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmAddViolation : Form
    {
        public bool IsSuccess { get; private set; }

        public frmAddViolation()
        {
            InitializeComponent();
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                await LoadReportedByUserIDsAsync();
                await LoadRoomsAsync();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải dữ liệu: {ex.Message}");
            }
        }

        private async Task LoadRoomsAsync()
        {
            try
            {
                var rooms = await ApiService.GetRoomsAsync("Tất cả", "Tất cả", "");
                if (rooms != null)
                {
                    cmbRoomID.Items.Clear();
                    foreach (var room in rooms.OrderBy(r => r.RoomId))
                    {
                        cmbRoomID.Items.Add($"{room.RoomId} - {room.RoomNumber}");
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải danh sách phòng: {ex.Message}");
            }
        }

        private async Task LoadReportedByUserIDsAsync()
        {
            try
            {
                // Lấy danh sách admin từ API
                var admins = await ApiService.GetAdminsAsync();
                
                if (admins != null && admins.Any())
                {
                    cmbReportedByUserID.Items.Clear();
                    // Lấy UserID của các admin và sắp xếp
                    var adminUserIDs = admins
                        .Where(a => !string.IsNullOrWhiteSpace(a.UserID))
                        .Select(a => a.UserID)
                        .Distinct()
                        .OrderBy(id => id)
                        .ToList();

                    foreach (var userID in adminUserIDs)
                    {
                        cmbReportedByUserID.Items.Add(userID);
                    }

                    if (cmbReportedByUserID.Items.Count > 0)
                    {
                        cmbReportedByUserID.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi tải danh sách người báo cáo: {ex.Message}");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtViolationID.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập mã vi phạm.");
                txtViolationID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtViolationType.Text))
            {
                UiHelper.ShowError(this, "Vui lòng nhập loại vi phạm.");
                txtViolationType.Focus();
                return;
            }

            if (cmbReportedByUserID.SelectedItem == null)
            {
                UiHelper.ShowError(this, "Vui lòng chọn người báo cáo.");
                cmbReportedByUserID.Focus();
                return;
            }

            try
            {
                // Lấy RoomID từ ComboBox hoặc tự động từ contract
                string roomID = string.Empty;
                
                // Ưu tiên lấy từ ComboBox
                if (cmbRoomID.SelectedItem != null)
                {
                    string selected = cmbRoomID.SelectedItem.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(selected))
                    {
                        // Extract RoomID từ format "RoomID - RoomNumber"
                        int dashIndex = selected.IndexOf(" - ");
                        if (dashIndex > 0)
                        {
                            roomID = selected.Substring(0, dashIndex).Trim();
                        }
                        else
                        {
                            roomID = selected.Trim();
                        }
                    }
                }
                
                // Nếu ComboBox trống, thử lấy từ text input
                if (string.IsNullOrWhiteSpace(roomID) && !string.IsNullOrWhiteSpace(cmbRoomID.Text))
                {
                    string text = cmbRoomID.Text.Trim();
                    int dashIndex = text.IndexOf(" - ");
                    if (dashIndex > 0)
                    {
                        roomID = text.Substring(0, dashIndex).Trim();
                    }
                    else
                    {
                        roomID = text.Trim();
                    }
                }
                
                // Nếu vẫn chưa có, thử lấy từ contract của student
                if (string.IsNullOrWhiteSpace(roomID) && !string.IsNullOrWhiteSpace(txtStudentID.Text))
                {
                    try
                    {
                        var contracts = await ApiService.GetContractsAsync("Tất cả", txtStudentID.Text.Trim());
                        var activeContract = contracts?.FirstOrDefault(c => 
                            c.StudentId.Equals(txtStudentID.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
                            c.Status.Equals("Active", StringComparison.OrdinalIgnoreCase));
                        
                        if (activeContract != null && !string.IsNullOrEmpty(activeContract.RoomId))
                        {
                            roomID = activeContract.RoomId;
                            // Tự động chọn trong ComboBox nếu có
                            for (int i = 0; i < cmbRoomID.Items.Count; i++)
                            {
                                if (cmbRoomID.Items[i].ToString()?.StartsWith(roomID + " - ") == true)
                                {
                                    cmbRoomID.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        // Silently fail
                    }
                }
                
                if (string.IsNullOrWhiteSpace(roomID))
                {
                    UiHelper.ShowError(this, "Mã phòng là bắt buộc. Vui lòng chọn hoặc nhập mã phòng.");
                    cmbRoomID.Focus();
                    return;
                }

                var dto = new DormitoryManagementSystem.DTO.Violations.ViolationCreateDTO
                {
                    ViolationID = txtViolationID.Text.Trim(),
                    StudentID = string.IsNullOrWhiteSpace(txtStudentID.Text) ? null : txtStudentID.Text.Trim(),
                    RoomID = roomID,
                    ReportedByUserID = cmbReportedByUserID.SelectedItem?.ToString(),
                    ViolationType = txtViolationType.Text.Trim(),
                    ViolationDate = dtpViolationDate.Value,
                    PenaltyFee = 0, 
                    Status = "Pending"
                };

                var success = await ApiService.CreateViolationAsync(dto);
                if (success)
                {
                    IsSuccess = true;
                    UiHelper.ShowSuccess(this, "Tạo vi phạm thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    UiHelper.ShowError(this, "Tạo vi phạm thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Lỗi khi tạo vi phạm: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
