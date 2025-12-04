using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Dashboard;
// Import namespace chứa DbContext của bạn, ví dụ:
// using DormitoryManagementSystem.Infrastructure.Data; 

namespace DormitoryManagementSystem.DAO.Implements
{
    public class DashboardDAO : IDashboardDAO
    {
        private readonly DormitoryContext _context; // Thay bằng tên DbContext thật của bạn

        public DashboardDAO(DormitoryContext context)
        {
            _context = context;
        }

        public async Task<List<BuildingKpiDTO>> GetBuildingStatsAsync()
        {
            // Truy vấn Group By ngay tại Database
            return await _context.Buildings
                .Select(b => new BuildingKpiDTO
                {
                    BuildingName = b.BuildingName,
                    Gender = b.Gender,
                    // Giả sử mỗi tòa nhà có list Rooms
                    TotalRooms = b.Rooms.Sum(r => r.Capacity),
                    OccupiedRooms = b.Rooms.Sum(r => r.CurrentOccupancy),
                    Floors = b.Floors // Hoặc tính toán nếu không có trường này
                })
                .ToListAsync();
        }

        public async Task<DashboardKpiDTO> GetGeneralKpiAsync(string? buildingFilter, DateTime from, DateTime to)
        {
            // Lọc phòng theo building
            var roomQuery = _context.Rooms.AsQueryable();
            if (!string.IsNullOrEmpty(buildingFilter) && !buildingFilter.ToLower().StartsWith("tất cả"))
            {
                roomQuery = roomQuery.Where(r => r.Building.BuildingName.Contains(buildingFilter));
            }

            var totalRooms = await roomQuery.CountAsync();
            // Phòng coi là full nếu occupancy >= capacity
            var occupiedRooms = await roomQuery.CountAsync(r => r.CurrentOccupancy >= r.Capacity);

            // Tính toán doanh thu và hợp đồng
            // Lưu ý: Logic lọc theo Building cho Contract/Payment phức tạp hơn nếu DB không map trực tiếp
            // Ở đây tôi viết query mẫu đơn giản

            var payments = await _context.Payments
                .Where(p => p.PaymentDate >= from && p.PaymentDate <= to)
                .SumAsync(p => p.PaymentAmount);

            var pendingContracts = await _context.Contracts
                .CountAsync(c => c.Status == "Pending" || c.Status == "AwaitingApproval");

            var openViolations = await _context.Violations
                .CountAsync(v => v.Status != "Closed" && v.Status != "Resolved");

            return new DashboardKpiDTO
            {
                RoomsTotal = totalRooms,
                RoomsOccupied = occupiedRooms,
                RoomsAvailable = Math.Max(0, totalRooms - occupiedRooms),
                PaymentsThisMonth = payments,
                ContractsPending = pendingContracts,
                ViolationsOpen = openViolations
            };
        }

        public async Task<DashboardChartsDTO> GetChartDataAsync(string? buildingFilter, DateTime from, DateTime to)
        {
            var chartData = new DashboardChartsDTO();

            // 1. Pie Chart Data
            var roomQuery = _context.Rooms.AsQueryable();
            if (!string.IsNullOrEmpty(buildingFilter) && !buildingFilter.ToLower().StartsWith("tất cả"))
            {
                roomQuery = roomQuery.Where(r => r.Building.BuildingName.Contains(buildingFilter));
            }

            chartData.OccupiedCount = await roomQuery.CountAsync(r => r.CurrentOccupancy >= r.Capacity);
            chartData.AvailableCount = await roomQuery.CountAsync(r => r.CurrentOccupancy < r.Capacity);

            // 2. Bar Chart Data (Occupancy by Building)
            chartData.OccupancyByBuilding = await _context.Buildings
                .Select(b => new OccupancyByBuildingDTO
                {
                    Building = b.BuildingName,
                    Occupied = b.Rooms.Sum(r => r.CurrentOccupancy),
                    Capacity = b.Rooms.Sum(r => r.Capacity)
                })
                .OrderBy(x => x.Building)
                .ToListAsync();

            // 3. Line Chart (Contracts by week) - Xử lý phía client hoặc memory một chút do Group By Date phức tạp trong EF Core tùy DB Provider
            var contracts = await _context.Contracts
                .Where(c => c.CreatedDate >= from && c.CreatedDate <= to)
                .Select(c => c.CreatedDate)
                .ToListAsync();

            chartData.ContractsByWeek = contracts
                .GroupBy(d => ISOWeek.GetWeekOfYear(d))
                .Select(g => new ContractByWeekDTO
                {
                    Week = $"Tuần {g.Key}",
                    Count = g.Count()
                })
                .ToList();

            return chartData;
        }

        public async Task<List<AlertDTO>> GetPaymentAlertsAsync()
        {
            // Lấy 3 hóa đơn quá hạn gần nhất
            var limitDate = DateTime.Now.AddDays(-30);
            return await _context.Payments
                .Include(p => p.Contract)
                .Where(p => p.PaymentStatus == "Late" || (p.PaymentStatus != "Paid" && p.PaymentDate < limitDate))
                .OrderByDescending(p => p.PaymentDate)
                .Take(3)
                .Select(p => new AlertDTO
                {
                    Type = "Thanh toán",
                    Message = $"Hóa đơn {p.PaymentID} của {p.Contract.StudentName} đang quá hạn.",
                    Date = p.PaymentDate
                })
                .ToListAsync();
        }

        public async Task<List<AlertDTO>> GetViolationAlertsAsync()
        {
            return await _context.Violations
               .Where(v => v.Status != "Closed" && v.Status != "Resolved")
               .OrderByDescending(v => v.ViolationDate)
               .Take(3)
               .Select(v => new AlertDTO
               {
                   Type = "Vi phạm",
                   Message = $"{v.StudentName}: {v.ViolationType}",
                   Date = v.ViolationDate
               })
               .ToListAsync();
        }

        public async Task<List<ActivityDTO>> GetRecentActivitiesAsync(int limit)
        {
            // Query union 3 bảng là khá phức tạp trong EF Core thuần
            // Cách tốt nhất là query top (limit) của từng bảng rồi merge in-memory tại BUS
            // Tại DAO ta chỉ cung cấp method lấy riêng lẻ hoặc raw
            // Ở đây tôi demo cách lấy riêng lẻ để BUS gộp
            return new List<ActivityDTO>(); // Sẽ xử lý logic gộp ở BUS hoặc viết Stored Procedure
        }

        // Helper để lấy raw activities cho BUS xử lý
        public async Task<List<ActivityDTO>> GetRecentContractsAsync(int limit)
        {
            return await _context.Contracts.OrderByDescending(c => c.CreatedDate).Take(limit)
               .Select(c => new ActivityDTO { Time = c.CreatedDate, Description = $"Hợp đồng mới: {c.StudentName}" })
               .ToListAsync();
        }
        public async Task<List<ActivityDTO>> GetRecentPaymentsAsync(int limit)
        {
            return await _context.Payments.OrderByDescending(c => c.PaymentDate).Take(limit)
               .Select(c => new ActivityDTO { Time = c.PaymentDate, Description = $"Thanh toán: {c.PaymentID}" })
               .ToListAsync();
        }
        public async Task<List<ActivityDTO>> GetRecentViolationsAsync(int limit)
        {
            return await _context.Violations.OrderByDescending(c => c.ViolationDate).Take(limit)
               .Select(c => new ActivityDTO { Time = c.ViolationDate, Description = $"Vi phạm: {c.ViolationType}" })
               .ToListAsync();
        }
    }
}