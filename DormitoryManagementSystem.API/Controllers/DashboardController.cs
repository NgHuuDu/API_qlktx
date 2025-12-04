using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/admin/dashboard")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Chỉ Admin mới xem được Dashboard
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardBUS _dashboardBUS;
        public DashboardController(IDashboardBUS dashboardBUS) => _dashboardBUS = dashboardBUS;

        [HttpGet("buildings")]
        public async Task<ActionResult<BuildingKpiResponseDTO>> GetBuildingKpis()
        {
            var result = await _dashboardBUS.GetBuildingKpisAsync();
            return Ok(result);
        }

        [HttpGet("kpis")]
        public async Task<ActionResult<DashboardKpiDTO>> GetDashboardKpis(
            [FromQuery] string? building, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var result = await _dashboardBUS.GetDashboardKpisAsync(building, from, to);
            return Ok(result);
        }

        [HttpGet("charts")]
        public async Task<ActionResult<DashboardChartsDTO>> GetDashboardCharts(
            [FromQuery] string? building, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var result = await _dashboardBUS.GetDashboardChartsAsync(building, from, to);
            return Ok(result);
        }

        [HttpGet("alerts")]
        public async Task<ActionResult<List<AlertDTO>>> GetAlerts()
        {
            var result = await _dashboardBUS.GetAlertsAsync();
            return Ok(result);
        }

        [HttpGet("activities")]
        public async Task<ActionResult<List<ActivityDTO>>> GetActivities([FromQuery] int limit = 20)
        {
            var result = await _dashboardBUS.GetActivitiesAsync(limit);
            return Ok(result);
        }
    }
}