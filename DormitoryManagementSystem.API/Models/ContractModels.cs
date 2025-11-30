using System;

namespace DormitoryManagementSystem.API.Models
{
    public class ContractResponse
    {
        public string ContractId { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class PendingContractResponse
    {
        public string ContractId { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyFee { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}

