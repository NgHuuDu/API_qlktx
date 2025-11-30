using System.Collections.Generic;

namespace DormitoryManagementSystem.API.Models
{
    public class StatisticsResponse
    {
        public List<StatisticsPoint> RevenueByMonth { get; set; } = new();
        public List<StatisticsPoint> OccupancyByBuilding { get; set; } = new();
        public List<StatisticsPoint> ViolationsByType { get; set; } = new();
    }

    public class StatisticsPoint
    {
        public string Label { get; set; } = string.Empty;
        public double Value { get; set; }
    }
}

