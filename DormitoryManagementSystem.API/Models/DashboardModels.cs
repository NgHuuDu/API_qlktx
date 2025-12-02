using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.API.Models
{
    public class BuildingKpiResponse
    {
        public List<BuildingKpiModel> Buildings { get; set; } = new();
    }

    public class BuildingKpiModel
    {
        public string BuildingName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Floors { get; set; }
        public int OccupiedRooms { get; set; }
        public int TotalRooms { get; set; }
        public decimal OccupancyRate { get; set; }
    }

    public class DashboardKpiResponse
    {
        public int RoomsTotal { get; set; }
        public int RoomsAvailable { get; set; }
        public int RoomsOccupied { get; set; }
        public int ContractsPending { get; set; }
        public decimal PaymentsThisMonth { get; set; }
        public int ViolationsOpen { get; set; }
    }

    public class DashboardChartsResponse
    {
        public int OccupiedCount { get; set; }
        public int AvailableCount { get; set; }
        public List<OccupancyByBuildingItem> OccupancyByBuilding { get; set; } = new();
        public List<ContractByWeekItem> ContractsByWeek { get; set; } = new();
    }

    public class OccupancyByBuildingItem
    {
        public string Building { get; set; } = string.Empty;
        public int Occupied { get; set; }
        public int Capacity { get; set; }
    }

    public class ContractByWeekItem
    {
        public string Week { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class AlertResponse
    {
        public string Type { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }

    public class ActivityResponse
    {
        public DateTime Time { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

