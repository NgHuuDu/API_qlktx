using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Statistics
{
    public class OccupancyStatsDTO
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalStudents { get; set; } // Số lượng SV ở trong tháng đó
    }
}
