using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Statistics
{
    public class DashboardStatsDTO
    {
        // 1. Tổng số sinh viên (Đang ở)
        public int TotalStudents { get; set; }

        // 2. Tổng số phòng
        public int TotalRooms { get; set; }

        // 3. Tổng số tòa nhà
        public int TotalBuildings { get; set; }

        // 4. Tỷ lệ lấp đầy (%)
        // Ví dụ: 85.5%
        public double OccupancyRate { get; set; }

        // 5. Doanh thu năm nay (VND)
        public decimal YearlyRevenue { get; set; }
    }
}
