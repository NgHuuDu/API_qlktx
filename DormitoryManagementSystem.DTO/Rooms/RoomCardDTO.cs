using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Rooms
{
    public class RoomCardDTO
    {
        public string RoomID { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public string BuildingName { get; set; } = string.Empty;

        // Gửi số nguyên, để FE tự tính toán màu sắc hoặc thanh tiến trình
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }

        public string Status { get; set; } = string.Empty;

    }
}
