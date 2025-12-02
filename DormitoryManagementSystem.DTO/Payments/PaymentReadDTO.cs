namespace DormitoryManagementSystem.DTO.Payments
{
    public class PaymentReadDTO
    {
        public string PaymentID { get; set; } = string.Empty;
        public string ContractID { get; set; } = string.Empty;
        public int BillMonth { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal RemainingAmount => PaymentAmount - PaidAmount;
    }
}