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
        public int RoomNumber { get; set; }
        public string Status { get; set; } = string.Empty;  
        public DateTime StartTime { get; set; }              
        public string ViolationType { get; set; } = string.Empty;
        public decimal PenaltyFee { get; set; }
    }
}

