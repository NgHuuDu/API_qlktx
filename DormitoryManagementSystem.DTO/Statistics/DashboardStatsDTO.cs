using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Statistics
{
    public class DashboardStatsDTO
    {
        public int TotalStudents { get; set; }

        public int TotalRooms { get; set; }

        public int TotalBuildings { get; set; }

        
        public double OccupancyRate { get; set; }

        public decimal YearlyRevenue { get; set; }
    }
}
