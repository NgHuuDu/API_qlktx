using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DormitoryManagementSystem.DTO.Dashboard;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IDashboardDAO
    {
        Task<List<BuildingKpiDTO>> GetBuildingStatsAsync();
        Task<DashboardKpiDTO> GetGeneralKpiAsync(string? buildingFilter, DateTime from, DateTime to);
        Task<DashboardChartsDTO> GetChartDataAsync(string? buildingFilter, DateTime from, DateTime to);
        Task<List<AlertDTO>> GetPaymentAlertsAsync();
        Task<List<AlertDTO>> GetViolationAlertsAsync();
        Task<List<ActivityDTO>> GetRecentActivitiesAsync(int limit);
    }
}