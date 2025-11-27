using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryManagementSystem.DTO.Statistics;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IStatisticsBUS
    {
        Task<DashboardStatsDTO> GetDashboardStatsAsync();
        Task<IEnumerable<RevenueStatsDTO>> GetMonthlyRevenueAsync(int year);
        
        Task<IEnumerable<OccupancyStatsDTO>> GetOccupancyTrendAsync(int year);
        Task<GenderStatsDTO> GetGenderStatsAsync();

        Task<IEnumerable<BuildingComparisonDTO>> GetBuildingComparisonAsync(int? year);

        Task<IEnumerable<ViolationTrendDTO>> GetViolationTrendAsync(int year);
    }
}
