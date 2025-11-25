using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Violations
{
    public class ViolationListDTO
    {
        public string ViolationID { get; set; } = string.Empty;
        public string StudentID { get; set; } = string.Empty;
        public string RoomID { get; set; } = string.Empty;

        // Dùng DateTime để tránh lỗi tương thích, lên FE format sau
        public DateTime StartTime { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
