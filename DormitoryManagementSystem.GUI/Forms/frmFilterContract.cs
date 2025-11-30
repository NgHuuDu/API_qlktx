using DormitoryManagementSystem.DTO.Buildings;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmFilterContract : Form
    {
        public string? SelectedBuilding { get; private set; }
        public string? SelectedStatus { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool IsApplied { get; private set; }

        private string? pendingBuilding = null;
        
        public frmFilterContract(
            string? currentBuilding = null,
            string? currentStatus = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            InitializeComponent();
            
            // Thiết lập giá trị ngày
            if (startDate.HasValue) dtpStartDate.Value = startDate.Value;
            else dtpStartDate.Value = DateTime.Now.AddYears(-1);
            
            if (endDate.HasValue) dtpEndDate.Value = endDate.Value;
            else dtpEndDate.Value = DateTime.Now.AddYears(1);
            
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
            
            // Lưu tòa nhà để thiết lập sau khi tải
            pendingBuilding = currentBuilding;
            
            // Tải danh sách tòa nhà bất đồng bộ
            _ = LoadBuildingsAndSetSelection();
        }
        
        private async Task LoadBuildingsAndSetSelection()
        {
            await LoadBuildings();
            
            // Thiết lập tòa nhà sau khi tải
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
            
            // Thiết lập mục đầu tiên nếu có
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (cmbBuilding.Items.Count > 0)
                cmbBuilding.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now.AddYears(-1);
            dtpEndDate.Value = DateTime.Now.AddYears(1);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Validate dates
            if (dtpStartDate.Value > dtpEndDate.Value)
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

            // Trích xuất trạng thái
            string? status = null;
            if (cmbStatus.SelectedIndex > 0 && cmbStatus.SelectedItem != null)
            {
                status = cmbStatus.SelectedItem.ToString();
            }

            // Thiết lập giá trị bộ lọc
            SelectedBuilding = building;
            SelectedStatus = status;
            
            // Thiết lập bộ lọc ngày
            DateTime defaultFrom = DateTime.Now.AddYears(-1).Date;
            DateTime defaultTo = DateTime.Now.AddYears(1).Date;
            
            StartDate = (dtpStartDate.Value.Date != defaultFrom) ? dtpStartDate.Value.Date : (DateTime?)null;
            EndDate = (dtpEndDate.Value.Date != defaultTo) ? dtpEndDate.Value.Date : (DateTime?)null;
            
            IsApplied = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
