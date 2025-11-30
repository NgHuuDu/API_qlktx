using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Payments
{
    public class PaymentCreateDTO
    {
        [Required(ErrorMessage = "Payment ID is required")]
        [StringLength(10, ErrorMessage = "Payment ID cannot exceed 10 chars")]
        public string PaymentID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contract ID is required")]
        [StringLength(10, ErrorMessage = "Contract ID cannot exceed 10 chars")]
        public string ContractID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bill month is required")]
        [Range(1, 12, ErrorMessage = "Bill month must be between 1 and 12")]
        public int BillMonth { get; set; }

        [Required(ErrorMessage = "Payment amount is required")]
        [Range(0, 1000000000, ErrorMessage = "Payment amount must be positive")]
        public decimal PaymentAmount { get; set; } // Số tiền CẦN đóng

        [Range(0, 1000000000, ErrorMessage = "Paid amount must be positive")]
        public decimal PaidAmount { get; set; } = 0; // Số tiền ĐÃ đóng (Mặc định là 0 khi mới tạo bill)

        // Nullable vì khi mới tạo hóa đơn, có thể chưa thanh toán ngay
        [RegularExpression("^(Cash|Bank Transfer|Online)$", ErrorMessage = "Method must be 'Cash', 'Bank Transfer', or 'Online'")]
        public string? PaymentMethod { get; set; }

        // Mặc định là Unpaid, nhưng cho phép set nếu đóng tiền ngay
        [RegularExpression("^(Unpaid|Paid|Late|Refunded)$", ErrorMessage = "Status must be valid")]
        public string PaymentStatus { get; set; } = "Unpaid";

        public DateTime? PaymentDate { get; set; } = DateTime.Now;

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 chars")]
        public string? Description { get; set; }
    }
}