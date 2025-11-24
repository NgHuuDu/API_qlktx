using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.BUS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IPaymentBUS _paymentBUS;
        private readonly IRoomBUS _roomBUS;
        private readonly IBuildingBUS _buildingBUS;
        private readonly IViolationBUS _violationBUS;

        public StatisticsController(
            IPaymentBUS paymentBUS,
            IRoomBUS roomBUS,
            IBuildingBUS buildingBUS,
            IViolationBUS violationBUS)
        {
            _paymentBUS = paymentBUS;
            _roomBUS = roomBUS;
            _buildingBUS = buildingBUS;
            _violationBUS = violationBUS;
        }

        [HttpGet]
        public async Task<ActionResult<StatisticsResponse>> GetStatistics(
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to)
        {
            var dateFrom = (from ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).Date;
            var dateTo = (to ?? DateTime.Now).Date;
            if (dateFrom > dateTo)
                (dateFrom, dateTo) = (dateTo, dateFrom);

            // Chạy tuần tự để tránh concurrent access trên cùng DbContext instance
            var payments = await _paymentBUS.GetAllPaymentsAsync();
            var rooms = await _roomBUS.GetAllRoomsAsync();
            var buildings = await _buildingBUS.GetAllBuildingAsync();
            var violations = await _violationBUS.GetAllViolationsAsync();

            var buildingLookup = buildings
                .ToDictionary(b => b.BuildingID, b => b, StringComparer.OrdinalIgnoreCase);

            var revenuePoints = payments
                .Where(p => p.PaymentDate.Date >= dateFrom && p.PaymentDate.Date <= dateTo)
                .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .Select(g => new StatisticsPoint
                {
                    Label = $"{g.Key.Month:D2}/{g.Key.Year}",
                    Value = (double)g.Sum(x => x.PaymentAmount)
                })
                .ToList();

            var occupancyPoints = rooms
                .GroupBy(r => r.BuildingID)
                .Select(group =>
                {
                    var buildingName = buildingLookup.TryGetValue(group.Key, out var dto)
                        ? dto.BuildingName
                        : group.Key;

                    var capacity = group.Sum(r => r.Capacity);
                    var occupied = group.Sum(r => r.CurrentOccupancy);
                    var rate = capacity == 0 ? 0 : Math.Round((double)occupied * 100 / capacity, 2);

                    return new StatisticsPoint
                    {
                        Label = buildingName,
                        Value = rate
                    };
                })
                .OrderByDescending(p => p.Value)
                .ToList();

            var violationPoints = violations
                .Where(v => v.ViolationDate.Date >= dateFrom && v.ViolationDate.Date <= dateTo)
                .GroupBy(v => v.ViolationType)
                .Select(g => new StatisticsPoint
                {
                    Label = g.Key,
                    Value = g.Count()
                })
                .OrderByDescending(p => p.Value)
                .ToList();

            var response = new StatisticsResponse
            {
                RevenueByMonth = revenuePoints,
                OccupancyByBuilding = occupancyPoints,
                ViolationsByType = violationPoints
            };

            return Ok(response);
        }
    }
}

