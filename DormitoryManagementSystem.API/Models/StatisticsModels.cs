using System.Collections.Generic;

namespace DormitoryManagementSystem.API.Models
{
    public class StatisticsResponse
    {
        public List<StatisticsPoint> RevenueByMonth { get; set; } = new();
        public List<StatisticsPoint> OccupancyByBuilding { get; set; } = new();
        public List<StatisticsPoint> ViolationsByMonth { get; set; } = new();
        public List<StatisticsPoint> OccupancyTrend { get; set; } = new();
        public List<GenderDistributionPoint> GenderDistribution { get; set; } = new();
        public List<BuildingComparisonPoint> BuildingComparison { get; set; } = new();
    }

    public class StatisticsPoint
    {
        public string Label { get; set; } = string.Empty;
        public double Value { get; set; }
    }

    public class GenderDistributionPoint
    {
        public string Label { get; set; } = string.Empty;
        public int Value { get; set; }
    }

    public class BuildingComparisonPoint
    {
        public string Building { get; set; } = string.Empty;
        public int Students { get; set; }
        public double Revenue { get; set; }
    }
}

