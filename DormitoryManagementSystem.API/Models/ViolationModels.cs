using System;

namespace DormitoryManagementSystem.API.Models
{
    public class ViolationResponse
    {
        public string ViolationId { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string RoomID { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public string? ReportedByUserID { get; set; }
        public string ViolationType { get; set; } = string.Empty;
        public DateTime ViolationDate { get; set; }
        public decimal PenaltyFee { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class ViolationKpiResponse
    {
        public int UnprocessedCount { get; set; }
        public int ProcessedCount { get; set; }
        public int SeriousCount { get; set; }
    }
}

