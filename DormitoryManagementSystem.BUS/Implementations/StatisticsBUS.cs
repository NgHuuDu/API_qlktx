using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Implementations;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Statistics;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class StatisticsBUS : IStatisticsBUS
    {
        private readonly IStatisticsDAO _statisticsDAO;

        public StatisticsBUS(IStatisticsDAO statisticsDAO)
        {
            _statisticsDAO = statisticsDAO;
        }

        public async Task<DashboardStatsDTO> GetDashboardStatsAsync()
        {
            return await _statisticsDAO.GetDashboardStatsAsync();
        }

        public async Task<IEnumerable<RevenueStatsDTO>> GetMonthlyRevenueAsync(int year)
        {            
            var dbStats = await _statisticsDAO.GetMonthlyRevenueAsync(year);

            var fullStats = new List<RevenueStatsDTO>();

            for (int m = 1; m <= 12; m++)
            {
                var stat = dbStats.FirstOrDefault(s => s.Month == m);
                if (stat != null)
                {
                    fullStats.Add(stat);
                }
                else
                {
                    // Nếu tháng này không có doanh thu, tạo dữ liệu ảo = 0
                    fullStats.Add(new RevenueStatsDTO { Month = m, Year = year, Revenue = 0 });
                }
            }

            return fullStats;
        }


        public async Task<IEnumerable<OccupancyStatsDTO>> GetOccupancyTrendAsync(int year)
        {
            // Lấy danh sách hợp đồng liên quan đến năm nay
            var contracts = await _statisticsDAO.GetContractsByYearAsync(year);

            var result = new List<OccupancyStatsDTO>();

            // Chạy vòng lặp 12 tháng để tính toán
            for (int month = 1; month <= 12; month++)
            {
                // Xác định ngày đầu và cuối của tháng đang xét
                var firstDayOfMonth = new DateOnly(year, month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                // Đếm số hợp đồng "còn sống" trong tháng này
                int count = contracts.Count(c =>
                    c.Starttime <= lastDayOfMonth &&
                    c.Endtime >= firstDayOfMonth);

                result.Add(new OccupancyStatsDTO
                {
                    Month = month,
                    Year = year,
                    TotalStudents = count
                });
            }

            return result;
        }


        public async Task<GenderStatsDTO> GetGenderStatsAsync()
        {
            return await _statisticsDAO.GetGenderStatsAsync();
        }
        public async Task<IEnumerable<BuildingComparisonDTO>> GetBuildingComparisonAsync(int? year)
        {
            // Nếu không truyền năm, mặc định lấy năm hiện tại cho số liệu có ý nghĩa
            // Hoặc bạn có thể để null để lấy "từ trước đến nay"
            if (!year.HasValue) year = DateTime.Now.Year;

            return await _statisticsDAO.GetBuildingComparisonAsync(year);
        }

        public async Task<IEnumerable<ViolationTrendDTO>> GetViolationTrendAsync(int year)
        {
            // Lấy dữ liệu thô từ DB
            var dbStats = await _statisticsDAO.GetViolationTrendAsync(year);

            // Chuẩn hóa dữ liệu (Đảm bảo đủ 12 tháng)
            var fullStats = new List<ViolationTrendDTO>();

            for (int m = 1; m <= 12; m++)
            {
                var stat = dbStats.FirstOrDefault(s => s.Month == m);
                if (stat != null)
                {
                    fullStats.Add(stat);
                }
                else
                {
                    // Nếu tháng này ngoan hiền không ai vi phạm -> Count = 0
                    fullStats.Add(new ViolationTrendDTO { Month = m, Year = year, ViolationCount = 0 });
                }
            }

            return fullStats;
        }

        public async Task<ViolationSummaryDTO> GetViolationSummaryStatsAsync()
        {
            return await _statisticsDAO.GetViolationSummaryStatsAsync();
        }

        public async Task<PaymentStatsDTO> GetPaymentStatisticsAsync()
        {
            return await _statisticsDAO.GetPaymentStatisticsAsync();
        }
    }
}
