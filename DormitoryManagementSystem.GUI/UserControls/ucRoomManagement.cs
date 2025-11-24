using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.UserControls
{
    public partial class ucRoomManagement : UserControl
    {
        private Form? mainForm;
        private bool isLoading = false;
        private CancellationTokenSource? cancellationTokenSource;
        private System.Threading.Timer? filterTimer;
        public ucRoomManagement()
        {
            InitializeComponent();
            this.Resize += ucRoomManagement_Resize;
            this.Layout += ucRoomManagement_Layout;
        }

        private void ucRoomManagement_Layout(object? sender, LayoutEventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                ArrangeKPICards();
            }
        }

        private void ucRoomManagement_Resize(object? sender, EventArgs e)
        {
            if (Width > 0 && Height > 0)
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
            await RefreshDataAsync();
        }

        private void SetupGridColumns()
        {
            dgvRooms.Columns.Clear();
            dgvRooms.Columns.Add("RoomId", "Mã phòng");
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
            if (isLoading) return;
            
            isLoading = true;
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            
            try
            {
                if (token.IsCancellationRequested) return;
                
                string building = GetSelectedFilterValue(cmbFilterBuilding);
                string status = GetSelectedFilterValue(cmbFilterStatus);
                string search = txtSearch.Text?.Trim() ?? string.Empty;

                var rooms = await ApiService.GetRoomsAsync(building, status, search);

                if (token.IsCancellationRequested) return;

                UpdateDataGridView(rooms);
            }
            catch (OperationCanceledException)
            {
                // Ignore cancellation
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu phòng: {ex.Message}");
                }
            }
            finally
            {
                isLoading = false;
            }
        }

        private void UpdateDataGridView(List<RoomResponse>? rooms)
        {
            dgvRooms.SuspendLayout();
            try
            {
                dgvRooms.Rows.Clear();
                
                if (rooms != null && rooms.Count > 0)
                {
                    var rows = new DataGridViewRow[rooms.Count];
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        var room = rooms[i];
                        rows[i] = new DataGridViewRow();
                        rows[i].CreateCells(dgvRooms,
                            room.RoomId,
                            room.RoomNumber,
                            room.Building,
                            room.RoomType,
                            $"{room.CurrentOccupants}/{room.MaxOccupants}",
                            room.Status,
                            room.Price
                        );
                    }
                    dgvRooms.Rows.AddRange(rows);
                }
            }
            finally
            {
                dgvRooms.ResumeLayout(true);
            }
        }

        private static string GetSelectedFilterValue(ComboBox comboBox)
        {
            return comboBox.SelectedIndex > 0 && comboBox.SelectedItem != null
                ? comboBox.SelectedItem.ToString() ?? "Tất cả"
                : "Tất cả";
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            if (btnFilter != null)
            {
                btnFilter.Enabled = false;
            }
            
            filterTimer?.Dispose();
            filterTimer = new System.Threading.Timer(_ =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(async () => 
                    {
                        await RefreshDataAsync();
                        if (btnFilter != null) btnFilter.Enabled = true;
                    }));
                }
                else
                {
                    RefreshDataAsync().ContinueWith(_ =>
                    {
                        if (btnFilter != null) btnFilter.Enabled = true;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }, null, 300, Timeout.Infinite);
        }

        private async Task UpdateKPICards()
        {
            try
            {
                var kpiData = await ApiService.GetBuildingKPIsAsync();

                if (kpiData?.Buildings == null || kpiData.Buildings.Count == 0)
                    return;

                var buildingCards = new[]
                {
                    (cardA1, lblA1Building, lblA1Gender, lblA1Floors, lblA1Occupancy, prgA1),
                    (cardA2, lblA2Building, lblA2Gender, lblA2Floors, lblA2Occupancy, prgA2),
                    (cardB1, lblB1Building, lblB1Gender, lblB1Floors, lblB1Occupancy, prgB1),
                    (cardB2, lblB2Building, lblB2Gender, lblB2Floors, lblB2Occupancy, prgB2)
                };

                var buildings = kpiData.Buildings;
                for (int i = 0; i < Math.Min(buildingCards.Length, buildings.Count); i++)
                {
                    var (card, lblBuilding, lblGender, lblFloors, lblOccupancy, prg) = buildingCards[i];
                    UpdateBuildingCard(card, lblBuilding, lblGender, lblFloors, lblOccupancy, prg, buildings[i]);
                }
            }
            catch (Exception ex)
            {
                if (this.mainForm != null)
                {
                    UiHelper.ShowError(this.mainForm, $"Lỗi tải dữ liệu KPI tòa: {ex.Message}");
                }
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

        private async void btnAddRoom_Click(object sender, EventArgs e)
        {
            using var form = new Forms.frmAddRoom();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await RefreshDataAsync();
            }
        }

        private async Task RefreshDataAsync()
        {
            await LoadDataAsync();
            await UpdateKPICards();
        }

    }
}
