namespace DormitoryManagementSystem.DTO.Violations
{
    public class ViolationReadDTO
    {
        public string ViolationID { get; set; } = string.Empty;
        public string? StudentID { get; set; }
        public string? StudentName { get; set; } // Nên join bảng Student để lấy tên hiển thị cho rõ
        public string RoomID { get; set; } = string.Empty;
        public string? ReportedByUserID { get; set; }
        public string ViolationType { get; set; } = string.Empty;
        public DateTime ViolationDate { get; set; }
        public decimal PenaltyFee { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}