using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryManagementSystem.DTO.Statistics;
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IStatisticsDAO
    {
        Task<DashboardStatsDTO> GetDashboardStatsAsync();
        Task<IEnumerable<RevenueStatsDTO>> GetMonthlyRevenueAsync(int year);
        Task<IEnumerable<Contract>> GetContractsByYearAsync(int year);
        Task<GenderStatsDTO> GetGenderStatsAsync();
        Task<IEnumerable<BuildingComparisonDTO>> GetBuildingComparisonAsync(int? year);
        Task<IEnumerable<ViolationTrendDTO>> GetViolationTrendAsync(int year);
    }
}
