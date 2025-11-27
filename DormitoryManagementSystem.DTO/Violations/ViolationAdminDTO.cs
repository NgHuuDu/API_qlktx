using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Violations
{
    public class ViolationAdminDTO
    {
        public string ViolationID { get; set; } = string.Empty;

        public string StudentID { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty; 
        public string RoomID { get; set; } = string.Empty;      

        public string ViolationType { get; set; } = string.Empty;
        public DateTime ViolationDate { get; set; }
        public decimal PenaltyFee { get; set; }
        public string Status { get; set; } = string.Empty; 
    }
}

