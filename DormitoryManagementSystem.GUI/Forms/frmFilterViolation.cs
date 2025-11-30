using DormitoryManagementSystem.DTO.Buildings;
using DormitoryManagementSystem.DTO.Violations;
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
    public partial class frmFilterViolation : Form
    {
        public string? SelectedBuilding { get; private set; }
        public string? SelectedViolationType { get; private set; }
        public string? SelectedStatus { get; private set; }
        public string? SelectedReportedByUserID { get; private set; }
        public DateTime? ViolationDateFrom { get; private set; }
        public DateTime? ViolationDateTo { get; private set; }
        public string? SelectedStudentID { get; private set; }
        public string? SelectedRoomID { get; private set; }
        public decimal? PenaltyFeeFrom { get; private set; }
        public decimal? PenaltyFeeTo { get; private set; }
        public bool IsApplied { get; private set; }

        private string? pendingBuilding = null;
        
        public frmFilterViolation(
            string? currentBuilding = null,
            string? currentViolationType = null,
            string? currentStatus = null,
            string? currentReportedByUserID = null,
            DateTime? violationDateFrom = null,
            DateTime? violationDateTo = null,
            string? currentStudentID = null,
            string? currentRoomID = null,
            decimal? penaltyFeeFrom = null,
            decimal? penaltyFeeTo = null)
        {
            InitializeComponent();
            
            // Thiết lập giá trị ngày
            if (violationDateFrom.HasValue) dtpViolationDateFrom.Value = violationDateFrom.Value;
            else dtpViolationDateFrom.Value = DateTime.Now.AddYears(-1);
            
            if (violationDateTo.HasValue) dtpViolationDateTo.Value = violationDateTo.Value;
            else dtpViolationDateTo.Value = DateTime.Now.AddYears(1);
            
            // Lưu tòa nhà để thiết lập sau khi tải
            pendingBuilding = currentBuilding;
            
            // Tải danh sách tòa nhà bất đồng bộ
            _ = LoadBuildingsAndSetSelection();
            
            // Thiết lập loại vi phạm
            if (!string.IsNullOrEmpty(currentViolationType))
            {
                txtViolationType.Text = currentViolationType;
            }
            
            // Tải danh sách người báo cáo và thiết lập lựa chọn
            _ = LoadReportedByUserIDsAsync(currentReportedByUserID);
            
            // Thiết lập trạng thái
            if (!string.IsNullOrEmpty(currentStatus))
            {
                for (int i = 0; i < cmbStatus.Items.Count; i++)
                {
                    if (cmbStatus.Items[i].ToString() == currentStatus)
                    {
                        cmbStatus.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                if (cmbStatus.Items.Count > 0)
                    cmbStatus.SelectedIndex = 0;
            }
            
            // Thiết lập mã sinh viên
            if (!string.IsNullOrEmpty(currentStudentID))
            {
                txtStudentID.Text = currentStudentID;
            }
            
            // Thiết lập mã phòng
            if (!string.IsNullOrEmpty(currentRoomID))
            {
                txtRoomID.Text = currentRoomID;
            }
            
            // Thiết lập phí phạt
            if (penaltyFeeFrom.HasValue)
            {
                txtPenaltyFeeFrom.Text = penaltyFeeFrom.Value.ToString("N0");
            }
            if (penaltyFeeTo.HasValue)
            {
                txtPenaltyFeeTo.Text = penaltyFeeTo.Value.ToString("N0");
            }
        }
        
        private async Task LoadBuildingsAndSetSelection()
        {
            await LoadBuildings();
            
            // Set building after loading
            if (!string.IsNullOrEmpty(pendingBuilding))
            {
                for (int i = 0; i < cmbBuilding.Items.Count; i++)
                {
                    if (cmbBuilding.Items[i].ToString()?.Contains($"({pendingBuilding})") == true)
                    {
                        cmbBuilding.SelectedIndex = i;
                        return;
                    }
                }
            }
            
            // Set to first item if available
            if (cmbBuilding.Items.Count > 0)
                cmbBuilding.SelectedIndex = 0;
        }

        private async Task LoadBuildings()
        {
            try
            {
                var buildings = await ApiService.GetBuildingsAsync();
                cmbBuilding.Items.Clear();
                cmbBuilding.Items.Add("Tất cả");
                
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

        private async Task LoadReportedByUserIDsAsync(string? currentReportedByUserID = null)
        {
            try
            {
                // Gọi API trực tiếp để lấy ViolationReadDTO (có ReportedByUserID)
                var response = await DormitoryManagementSystem.GUI.Services.HttpService.Client.GetFromJsonAsync<System.Collections.Generic.List<ViolationReadDTO>>(
                    "api/violations", 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                if (response != null)
                {
                    // Lấy danh sách ReportedByUserID unique và không null
                    var adminUserIDs = response
                        .Where(v => !string.IsNullOrWhiteSpace(v.ReportedByUserID))
                        .Select(v => v.ReportedByUserID!)
                        .Distinct()
                        .OrderBy(id => id)
                        .ToList();

                    cmbReportedByUserID.Items.Clear();
                    cmbReportedByUserID.Items.Add("Tất cả");
                    
                    foreach (var userID in adminUserIDs)
                    {
                        cmbReportedByUserID.Items.Add(userID);
                    }

                    // Thiết lập lựa chọn
                    if (!string.IsNullOrEmpty(currentReportedByUserID))
                    {
                        for (int i = 0; i < cmbReportedByUserID.Items.Count; i++)
                        {
                            if (cmbReportedByUserID.Items[i].ToString() == currentReportedByUserID)
                            {
                                cmbReportedByUserID.SelectedIndex = i;
                                return;
                            }
                        }
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
                // Thiết lập mặc định
                cmbReportedByUserID.Items.Clear();
                cmbReportedByUserID.Items.Add("Tất cả");
                cmbReportedByUserID.SelectedIndex = 0;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (cmbBuilding.Items.Count > 0)
                cmbBuilding.SelectedIndex = 0;
            txtViolationType.Text = string.Empty;
            if (cmbReportedByUserID.Items.Count > 0)
                cmbReportedByUserID.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
            dtpViolationDateFrom.Value = DateTime.Now.AddYears(-1);
            dtpViolationDateTo.Value = DateTime.Now.AddYears(1);
            txtStudentID.Text = string.Empty;
            txtRoomID.Text = string.Empty;
            txtPenaltyFeeFrom.Text = string.Empty;
            txtPenaltyFeeTo.Text = string.Empty;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Validate dates
            if (dtpViolationDateFrom.Value > dtpViolationDateTo.Value)
            {
                UiHelper.ShowWarning(this, "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc");
                return;
            }

            // Trích xuất mã tòa nhà
            string? building = null;
            if (cmbBuilding.SelectedIndex > 0 && cmbBuilding.SelectedItem != null)
            {
                string selected = cmbBuilding.SelectedItem.ToString();
                if (selected.Contains("(") && selected.Contains(")"))
                {
                    int start = selected.IndexOf("(") + 1;
                    int end = selected.IndexOf(")");
                    if (start > 0 && end > start)
                        building = selected.Substring(start, end - start);
                }
            }
            SelectedBuilding = building;
            
            // Trích xuất loại vi phạm
            string? violationType = string.IsNullOrWhiteSpace(txtViolationType.Text) ? null : txtViolationType.Text.Trim();
            SelectedViolationType = violationType;
            
            // Trích xuất mã người báo cáo
            string? reportedByUserID = null;
            if (cmbReportedByUserID.SelectedIndex > 0 && cmbReportedByUserID.SelectedItem != null)
            {
                reportedByUserID = cmbReportedByUserID.SelectedItem.ToString();
            }
            SelectedReportedByUserID = reportedByUserID;
            
            // Trích xuất trạng thái
            string? status = null;
            if (cmbStatus.SelectedIndex > 0 && cmbStatus.SelectedItem != null)
            {
                status = cmbStatus.SelectedItem.ToString();
            }
            SelectedStatus = status;
            
            // Thiết lập bộ lọc ngày
            DateTime defaultFrom = DateTime.Now.AddYears(-1).Date;
            DateTime defaultTo = DateTime.Now.AddYears(1).Date;
            
            ViolationDateFrom = (dtpViolationDateFrom.Value.Date != defaultFrom) ? dtpViolationDateFrom.Value.Date : (DateTime?)null;
            ViolationDateTo = (dtpViolationDateTo.Value.Date != defaultTo) ? dtpViolationDateTo.Value.Date : (DateTime?)null;
            
            // Trích xuất mã sinh viên
            string? studentID = string.IsNullOrWhiteSpace(txtStudentID.Text) ? null : txtStudentID.Text.Trim();
            SelectedStudentID = studentID;
            
            // Trích xuất mã phòng
            string? roomID = string.IsNullOrWhiteSpace(txtRoomID.Text) ? null : txtRoomID.Text.Trim();
            SelectedRoomID = roomID;
            
            // Trích xuất phí phạt
            decimal? penaltyFeeFrom = null;
            decimal? penaltyFeeTo = null;
            
            if (!string.IsNullOrWhiteSpace(txtPenaltyFeeFrom.Text))
            {
                if (decimal.TryParse(txtPenaltyFeeFrom.Text.Replace(",", "").Replace(".", ""), out decimal from))
                {
                    if (from < 0)
                    {
                        UiHelper.ShowWarning(this, "Phí phạt không được là số âm");
                        txtPenaltyFeeFrom.Focus();
                        return;
                    }
                    penaltyFeeFrom = from;
                }
                else
                {
                    UiHelper.ShowWarning(this, "Phí phạt phải là số hợp lệ");
                    txtPenaltyFeeFrom.Focus();
                    return;
                }
            }
            
            if (!string.IsNullOrWhiteSpace(txtPenaltyFeeTo.Text))
            {
                if (decimal.TryParse(txtPenaltyFeeTo.Text.Replace(",", "").Replace(".", ""), out decimal to))
                {
                    if (to < 0)
                    {
                        UiHelper.ShowWarning(this, "Phí phạt không được là số âm");
                        txtPenaltyFeeTo.Focus();
                        return;
                    }
                    penaltyFeeTo = to;
                }
                else
                {
                    UiHelper.ShowWarning(this, "Phí phạt phải là số hợp lệ");
                    txtPenaltyFeeTo.Focus();
                    return;
                }
            }
            
            // Validate penalty fee range
            if (penaltyFeeFrom.HasValue && penaltyFeeTo.HasValue && penaltyFeeFrom > penaltyFeeTo)
            {
                UiHelper.ShowWarning(this, "Phí phạt từ phải nhỏ hơn hoặc bằng phí phạt đến");
                return;
            }
            
            PenaltyFeeFrom = penaltyFeeFrom;
            PenaltyFeeTo = penaltyFeeTo;
            
            IsApplied = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
