using DormitoryManagementSystem.BUS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/admin/statistics")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Áp dụng cho toàn bộ Controller
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsBUS _statisticsBUS;
        public StatisticsController(IStatisticsBUS statisticsBUS) => _statisticsBUS = statisticsBUS;

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardStats()
        {
            var stats = await _statisticsBUS.GetDashboardStatsAsync();
            return Ok(stats);
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenueStats([FromQuery] int year)
        {
            if (year == 0) year = DateTime.Now.Year;
            var stats = await _statisticsBUS.GetMonthlyRevenueAsync(year);
            return Ok(stats);
        }

        [HttpGet("occupancy-trend")]
        public async Task<IActionResult> GetOccupancyTrend([FromQuery] int year)
        {
            if (year == 0) year = DateTime.Now.Year;
            var stats = await _statisticsBUS.GetOccupancyTrendAsync(year);
            return Ok(stats);
        }

        [HttpGet("gender")]
        public async Task<IActionResult> GetGenderStats()
        {
            var stats = await _statisticsBUS.GetGenderStatsAsync();
            return Ok(stats);
        }

        [HttpGet("building-comparison")]
        public async Task<IActionResult> GetBuildingComparison([FromQuery] int? year)
        {
            var data = await _statisticsBUS.GetBuildingComparisonAsync(year);
            return Ok(data);
        }

        [HttpGet("violation-trend")]
        public async Task<IActionResult> GetViolationTrend([FromQuery] int year)
        {
            if (year == 0) year = DateTime.Now.Year;
            var stats = await _statisticsBUS.GetViolationTrendAsync(year);
            return Ok(stats);
        }

        [HttpGet("violation-summary")]
        public async Task<IActionResult> GetViolationSummaryStats()
        {
            var stats = await _statisticsBUS.GetViolationSummaryStatsAsync();
            return Ok(stats);
        }

        [HttpGet("payment-summary")]
        public async Task<IActionResult> GetPaymentStats()
        {
            var stats = await _statisticsBUS.GetPaymentStatisticsAsync();
            return Ok(stats);
        }
    }
}