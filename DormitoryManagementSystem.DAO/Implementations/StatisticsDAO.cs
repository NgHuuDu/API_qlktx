using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Statistics;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class StatisticsDAO : IStatisticsDAO
    {
        private readonly PostgreDbContext _context;

        public StatisticsDAO(PostgreDbContext context)
        {
            this._context = context;
        }




        public async Task<DashboardStatsDTO> GetDashboardStatsAsync()
        {

            var stats = new DashboardStatsDTO();
            int currentYear = DateTime.Now.Year;

            // 1. Tổng số tòa nhà
            stats.TotalBuildings = await _context.Buildings.CountAsync();

            // 2. Tổng số phòng & Tính toán Tỷ lệ lấp đầy
            // Lấy tổng sức chứa (Capacity) và tổng người đang ở (CurrentOccupancy) của các phòng Active
            var roomStats = await _context.Rooms
                .AsNoTracking()
                .Where(r => r.Status == "Active")
                .GroupBy(x => 1) // Gom tất cả thành 1 nhóm để tính tổng
                .Select(g => new
                {
                    TotalRooms = g.Count(),
                    TotalCapacity = g.Sum(r => r.Capacity),
                    TotalOccupancy = g.Sum(r => r.Currentoccupancy ?? 0)
                })
                .FirstOrDefaultAsync();

            if (roomStats != null)
            {
                stats.TotalRooms = roomStats.TotalRooms;

                // Tính tỷ lệ %: (Người đang ở / Tổng sức chứa) * 100
                if (roomStats.TotalCapacity > 0)
                {
                    stats.OccupancyRate = Math.Round(
                        (double)roomStats.TotalOccupancy / roomStats.TotalCapacity * 100,
                        2 // Làm tròn 2 chữ số thập phân
                    );
                }

                // Tổng sinh viên đang ở chính là TotalOccupancy
                stats.TotalStudents = roomStats.TotalOccupancy;
            }

            // 3. Tính Doanh thu năm nay
            // Chỉ tính các hóa đơn đã thanh toán (Paid) trong năm hiện tại
            stats.YearlyRevenue = await _context.Payments
                .AsNoTracking()
                .Where(p => p.Paymentstatus == "Paid")
                .Where(p => p.Paymentdate.HasValue && p.Paymentdate.Value.Year == currentYear)
                .SumAsync(p => p.Paymentamount);

            return stats;
        }



        public async Task<IEnumerable<RevenueStatsDTO>> GetMonthlyRevenueAsync(int year)
        {

            var stats = await _context.Payments
                .AsNoTracking()
                // Chỉ lấy các hóa đơn đã đóng tiền trong năm được chọn
                .Where(p => p.Paymentdate.HasValue && p.Paymentdate.Value.Year == year)
                // Gom nhóm theo Tháng
                .GroupBy(p => p.Paymentdate.Value.Month)
                .Select(g => new RevenueStatsDTO
                {
                    Month = g.Key,
                    Year = year,
                    // Tính tổng số tiền thực đóng (PaidAmount)
                    Revenue = g.Sum(p => p.Paidamount)
                })
                .OrderBy(s => s.Month)
                .ToListAsync();

            return stats;
        }

        public async Task<IEnumerable<Contract>> GetContractsByYearAsync(int year)
        {

            // Logic: Lấy tất cả hợp đồng có khoảng thời gian "chạm" vào năm cần xem
            // Tức là: Bắt đầu trước khi năm kết thúc VÀ Kết thúc sau khi năm bắt đầu
            var firstDayOfYear = new DateTime(year, 1, 1);
            var lastDayOfYear = new DateTime(year, 12, 31);

            // Nếu Entity dùng DateOnly thì convert: DateOnly.FromDateTime(...)

            return await _context.Contracts
                .AsNoTracking()
                .Where(c => c.Status != "Terminated") // Bỏ qua hợp đồng bị hủy/vô hiệu
                                                      // Kiểm tra giao nhau về thời gian
                .Where(c => c.Starttime <= DateOnly.FromDateTime(lastDayOfYear) &&
                            c.Endtime >= DateOnly.FromDateTime(firstDayOfYear))
                .ToListAsync();
        }

        public async Task<GenderStatsDTO> GetGenderStatsAsync()
        {

            // 1. Gom nhóm và đếm trong DB
            var stats = await _context.Students
                .AsNoTracking()
                // Lọc sinh viên đang hoạt động (nếu cần)
                // .Where(s => s.User.IsActive == true) 
                .GroupBy(s => s.Gender)
                .Select(g => new
                {
                    Gender = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            // 2. Đổ vào DTO
            var result = new GenderStatsDTO();

            foreach (var item in stats)
            {
                if (item.Gender == "Male") result.MaleCount = item.Count;
                else if (item.Gender == "Female") result.FemaleCount = item.Count;
            }

            return result;
        }

        public async Task<IEnumerable<BuildingComparisonDTO>> GetBuildingComparisonAsync(int? year)
        {

            // Truy vấn từ bảng Tòa nhà
            var query = _context.Buildings
                .AsNoTracking()
                .Select(b => new BuildingComparisonDTO
                {
                    BuildingID = b.Buildingid,
                    BuildingName = b.Buildingname,

                    // 1. Đếm số sinh viên đang ở (Hợp đồng Active thuộc các phòng của tòa này)
                    TotalStudents = b.Rooms
                        .SelectMany(r => r.Contracts)
                        .Count(c => c.Status == "Active"),

                    // 2. Tính tổng tiền đã thu (Payment Status = Paid)
                    // Logic: Building -> Rooms -> Contracts -> Payments
                    TotalRevenue = b.Rooms
                        .SelectMany(r => r.Contracts)
                        .SelectMany(c => c.Payments)
                        .Where(p => p.Paymentstatus == "Paid")
                        // Lọc theo năm nếu có tham số truyền vào
                        .Where(p => !year.HasValue || (p.Paymentdate.HasValue && p.Paymentdate.Value.Year == year))
                        .Sum(p => p.Paymentamount)
                })
                .OrderByDescending(x => x.TotalRevenue); // Sắp xếp tòa nào doanh thu cao nhất lên đầu

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ViolationTrendDTO>> GetViolationTrendAsync(int year)
        {

            var stats = await _context.Violations
                .AsNoTracking()
                // 1. Chỉ lấy vi phạm trong năm được chọn
                .Where(v => v.Violationdate.HasValue && v.Violationdate.Value.Year == year)
                // 2. Gom nhóm theo Tháng
                .GroupBy(v => v.Violationdate.Value.Month)
                .Select(g => new ViolationTrendDTO
                {
                    Month = g.Key,
                    Year = year,
                    ViolationCount = g.Count()
                })
                .OrderBy(s => s.Month)
                .ToListAsync();

            return stats;
        }
    }
}
