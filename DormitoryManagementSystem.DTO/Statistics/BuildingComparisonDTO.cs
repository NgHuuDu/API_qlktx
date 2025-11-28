using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Statistics
{
    public class BuildingComparisonDTO
    {
        public string BuildingID { get; set; } = string.Empty;
        public string BuildingName { get; set; } = string.Empty;

        // Số lượng sinh viên đang ở
        public int TotalStudents { get; set; }

        //  Tổng doanh thu (đã thu được)
        public decimal TotalRevenue { get; set; }
    }
}
