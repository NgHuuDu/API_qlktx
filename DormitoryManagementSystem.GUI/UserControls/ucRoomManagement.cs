using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucRoomManagement : UserControl
    {
        private Form? mainForm;
        public ucRoomManagement()
        {
            InitializeComponent();
            this.Resize += ucRoomManagement_Resize;
            this.Layout += ucRoomManagement_Layout;
        }

        private void ucRoomManagement_Layout(object? sender, LayoutEventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                ArrangeKPICards();
            }
        }

        private void ucRoomManagement_Resize(object? sender, EventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                ArrangeKPICards();
            }
        }

        private void ArrangeKPICards()
        {
            if (pnlKPICards == null) return;

            const int padding = 20;
            const int cardHeight = 165;
            const int cardSpacing = 20;
            const int cardCount = 4;
            const int minCardWidth = 300;
            const int maxCardWidth = 400;

            var (cardWidth, startX) = CalculateCardLayout(pnlKPICards.ClientSize.Width, padding, cardSpacing, cardCount, minCardWidth, maxCardWidth);
            int y = padding;
            const int cardPadding = 15;

            // Arrange building cards
            ArrangeBuildingCard(cardA1, lblA1Building, lblA1Gender, lblA1Floors, lblA1Occupancy, prgA1, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeBuildingCard(cardA2, lblA2Building, lblA2Gender, lblA2Floors, lblA2Occupancy, prgA2, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeBuildingCard(cardB1, lblB1Building, lblB1Gender, lblB1Floors, lblB1Occupancy, prgB1, startX, y, cardWidth, cardHeight, cardPadding);
            startX += cardWidth + cardSpacing;

            ArrangeBuildingCard(cardB2, lblB2Building, lblB2Gender, lblB2Floors, lblB2Occupancy, prgB2, startX, y, cardWidth, cardHeight, cardPadding);
        }

        private static (int cardWidth, int startX) CalculateCardLayout(int panelWidth, int padding, int cardSpacing, int cardCount, int minWidth, int maxWidth)
        {
            int availableWidth = panelWidth - (padding * 2);
            int spaces = cardCount - 1;
            int calculatedCardWidth = Math.Max(minWidth, Math.Min(maxWidth, (availableWidth - (cardSpacing * spaces)) / cardCount));

            int totalWidth = (calculatedCardWidth * cardCount) + (cardSpacing * spaces);
            if (totalWidth > availableWidth)
            {
                calculatedCardWidth = (availableWidth - (cardSpacing * spaces)) / cardCount;
                totalWidth = (calculatedCardWidth * cardCount) + (cardSpacing * spaces);
            }

            int startX = padding;
            if (totalWidth < availableWidth)
            {
                startX = padding + ((availableWidth - totalWidth) / 2);
            }

            return (calculatedCardWidth, startX);
        }

        private static void ArrangeBuildingCard(Panel card, Label lblBuilding, Label lblGender, Label lblFloors, Label lblOccupancy, ProgressBar prg, int x, int y, int width, int height, int padding)
        {
            card.Location = new Point(x, y);
            card.Size = new Size(width, height);

            lblBuilding.Location = new Point(padding, padding);
            lblGender.Location = new Point(width - padding - lblGender.Width, padding + 4);
            lblFloors.Location = new Point(padding, padding + 32);
            lblOccupancy.Location = new Point(padding, padding + 84);

            int progressBarY = height - padding - 20;
            int progressBarWidth = width - (padding * 2);
            prg.Location = new Point(padding, progressBarY);
            prg.Size = new Size(progressBarWidth, 20);
            prg.BringToFront();
        }

        private async void ucRoomManagement_Load(object sender, EventArgs e)
        {
            this.mainForm = this.FindForm();
            SetupGridColumns();
            await LoadDataAsync();
            await UpdateKPICards();
        }

        private void SetupGridColumns()
        {
            dgvRooms.Columns.Clear();
            dgvRooms.Columns.Add("RoomNumber", "Số phòng");
            dgvRooms.Columns.Add("Building", "Tòa");
            dgvRooms.Columns.Add("RoomType", "Loại phòng");
            dgvRooms.Columns.Add("Occupancy", "Số người");
            dgvRooms.Columns.Add("Status", "Trạng thái");
            dgvRooms.Columns.Add("Price", "Giá");

            dgvRooms.Columns["Price"].DefaultCellStyle.Format = "C0";
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task LoadDataAsync()
        {
            UiHelper.ShowLoading(this);
            try
            {
                string building = cmbFilterBuilding.SelectedIndex > 0 ? cmbFilterBuilding.SelectedItem.ToString() : "Tất cả";
                string status = cmbFilterStatus.SelectedIndex > 0 ? cmbFilterStatus.SelectedItem.ToString() : "Tất cả";
                string search = txtSearch.Text;

                var rooms = await ApiService.GetRoomsAsync(building, status, search);

                dgvRooms.Rows.Clear();
                if (rooms != null)
                {
                    foreach (var room in rooms)
                    {
                        dgvRooms.Rows.Add(
                            room.RoomNumber,
                            room.Building,
                            room.RoomType,
                            $"{room.CurrentOccupants}/{room.MaxOccupants}",
                            room.Status,
                            room.Price
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu phòng: {ex.Message}");
            }
            finally
            {
                UiHelper.HideLoading(this);
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            await UpdateKPICards();
        }

        private async Task UpdateKPICards()
        {
            try
            {
                var kpiData = await ApiService.GetBuildingKPIsAsync();

                if (kpiData?.Buildings != null)
                {
                    if (kpiData.Buildings.Count > 0)
                        UpdateBuildingCard(cardA1, lblA1Building, lblA1Gender, lblA1Floors, lblA1Occupancy, prgA1, kpiData.Buildings[0]);
                    if (kpiData.Buildings.Count > 1)
                        UpdateBuildingCard(cardA2, lblA2Building, lblA2Gender, lblA2Floors, lblA2Occupancy, prgA2, kpiData.Buildings[1]);
                    if (kpiData.Buildings.Count > 2)
                        UpdateBuildingCard(cardB1, lblB1Building, lblB1Gender, lblB1Floors, lblB1Occupancy, prgB1, kpiData.Buildings[2]);
                    if (kpiData.Buildings.Count > 3)
                        UpdateBuildingCard(cardB2, lblB2Building, lblB2Gender, lblB2Floors, lblB2Occupancy, prgB2, kpiData.Buildings[3]);
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu KPI tòa: {ex.Message}");
            }
        }

        private static void UpdateBuildingCard(Panel card, Label lblBuilding, Label lblGender, Label lblFloors, Label lblOccupancy, ProgressBar prg, BuildingKpiModel building)
        {
            lblBuilding.Text = building.BuildingName;
            lblGender.Text = building.Gender;
            lblFloors.Text = $"{building.Floors} tầng";
            lblOccupancy.Text = $"{building.OccupiedRooms}/{building.TotalRooms}";
            
            prg.Maximum = 100;
            prg.Value = (int)Math.Round(building.OccupancyRate);
            prg.Style = ProgressBarStyle.Continuous;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            UiHelper.ShowSuccess(this.mainForm, "Chức năng Thêm phòng (chưa hoàn thiện)");
        }
    }
}
