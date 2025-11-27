using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DormitoryManagementSystem.BUS.Interfaces;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsBUS _statisticsBUS;

        public StatisticsController(IStatisticsBUS statisticsBUS)
        {
            _statisticsBUS = statisticsBUS;
        }
        
        
        
        //admin
        // GET: api/statistics/dashboard
        [HttpGet("admin/dashboard")]
        //[Authorize(Roles = "Admin,Manager")] 
        public async Task<IActionResult> GetDashboardStats()
        {
            try
            {
                var stats = await _statisticsBUS.GetDashboardStatsAsync();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }

        //Admin
        // API: Lấy doanh thu theo tháng (Vẽ biểu đồ cột/đường)
        [HttpGet("admin/revenue")]
        //[Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetRevenueStats([FromQuery] int year)
        {
            try
            {
                // Nếu không truyền năm, mặc định lấy năm nay
                if (year == 0) year = DateTime.Now.Year;

                var stats = await _statisticsBUS.GetMonthlyRevenueAsync(year);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }



        // API: Lấy xu hướng lấp đầy (Vẽ biểu đồ đường Line Chart)
        // GET: api/statistics/occupancy-trend?year=2024
        [HttpGet("admin/occupancy-trend")]
       // [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetOccupancyTrend([FromQuery] int year)
        {
            try
            {
                if (year == 0) year = DateTime.Now.Year;

                var stats = await _statisticsBUS.GetOccupancyTrendAsync(year);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        // API: Thống kê tỷ lệ nam nữ
        // GET: api/statistics/gender
        [HttpGet("admin/gender")]
        //[Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetGenderStats()
        {
            try
            {
                var stats = await _statisticsBUS.GetGenderStatsAsync();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        // API: So sánh các tòa nhà (SV & Doanh thu)
        // GET: api/statistics/building-comparison?year=2024
        [HttpGet("admin/building-comparison")]
       // [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetBuildingComparison([FromQuery] int? year)
        {
            try
            {
                var data = await _statisticsBUS.GetBuildingComparisonAsync(year);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        // API: Lấy xu hướng vi phạm (Vẽ biểu đồ đường/cột)
        // GET: api/statistics/violation-trend?year=2024
        [HttpGet("admin/violation-trend")]
       // [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetViolationTrend([FromQuery] int year)
        {
            try
            {
                if (year == 0) year = DateTime.Now.Year;

                var stats = await _statisticsBUS.GetViolationTrendAsync(year);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}