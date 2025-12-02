using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Rooms
{
    public class RoomDetailDTO
    {
        public string RoomID { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool AllowCooking { get; set; }
        public bool AirConditioner { get; set; }

    }
}


