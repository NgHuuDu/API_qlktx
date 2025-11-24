using System;

namespace DormitoryManagementSystem.API.Models
{
    public class PaymentResponse
    {
        public string Id { get; set; } = string.Empty;
        public string BillCode { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class PaymentKpiResponse
    {
        public decimal CollectedAmount { get; set; }
        public int CollectedCount { get; set; }
        public decimal PendingAmount { get; set; }
        public int PendingCount { get; set; }
        public decimal OverdueAmount { get; set; }
        public int OverdueCount { get; set; }
    }
}

