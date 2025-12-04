using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Implements;
using DormitoryManagementSystem.DAO.Interfaces; // Gọi DAO Interface
using DormitoryManagementSystem.DTO.Dashboard;

namespace DormitoryManagementSystem.BUS.Implements
{
    public class DashboardBUS : IDashboardBUS
    {
        private readonly IDashboardDAO _dashboardDAO; // Inject DAO

        public DashboardBUS(IDashboardDAO dashboardDAO)
        {
            _dashboardDAO = dashboardDAO;
        }

        public async Task<BuildingKpiResponseDTO> GetBuildingKpisAsync()
        {
            var buildings = await _dashboardDAO.GetBuildingStatsAsync();

            // Tính toán lại OccupancyRate tại BUS để đảm bảo chính xác logic hiển thị
            foreach (var b in buildings)
            {
                b.OccupancyRate = b.TotalRooms == 0
                    ? 0
                    : Math.Round((decimal)b.OccupiedRooms * 100 / b.TotalRooms, 2);
            }

            return new BuildingKpiResponseDTO
            {
                Buildings = buildings.OrderByDescending(k => k.OccupancyRate).ToList()
            };
        }

        public async Task<DashboardKpiDTO> GetDashboardKpisAsync(string? building, DateTime? from, DateTime? to)
        {
            var dateFrom = from ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var dateTo = to ?? DateTime.Now;
            return await _dashboardDAO.GetGeneralKpiAsync(building, dateFrom, dateTo);
        }

        public async Task<DashboardChartsDTO> GetDashboardChartsAsync(string? building, DateTime? from, DateTime? to)
        {
            var dateFrom = from ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var dateTo = to ?? DateTime.Now;
            return await _dashboardDAO.GetChartDataAsync(building, dateFrom, dateTo);
        }

        public async Task<List<AlertDTO>> GetAlertsAsync()
        {
            var paymentAlerts = await _dashboardDAO.GetPaymentAlertsAsync();
            var violationAlerts = await _dashboardDAO.GetViolationAlertsAsync();

            // Gộp 2 list lại và sắp xếp theo thời gian mới nhất
            var allAlerts = new List<AlertDTO>();
            allAlerts.AddRange(paymentAlerts);
            allAlerts.AddRange(violationAlerts);

            return allAlerts.OrderByDescending(a => a.Date).ToList();
        }

        public async Task<List<ActivityDTO>> GetActivitiesAsync(int limit)
        {
            // Logic gộp Activity: Lấy top limit của mỗi loại từ DAO, sau đó gộp và sort lại
            // Đây là cách xử lý "clean" mà không cần viết câu SQL quá phức tạp
            var contracts = await ((DashboardDAO)_dashboardDAO).GetRecentContractsAsync(limit);
            var payments = await ((DashboardDAO)_dashboardDAO).GetRecentPaymentsAsync(limit);
            var violations = await ((DashboardDAO)_dashboardDAO).GetRecentViolationsAsync(limit);

            var allActivities = new List<ActivityDTO>();
            allActivities.AddRange(contracts);
            allActivities.AddRange(payments);
            allActivities.AddRange(violations);

            return allActivities
                .OrderByDescending(a => a.Time)
                .Take(limit)
                .ToList();
        }
    }
}