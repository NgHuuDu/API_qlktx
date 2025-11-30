using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Payments
{
    public class PaymentUpdateDTO
    {
        // Cho phép cập nhật số tiền đã đóng (trường hợp đóng làm nhiều lần)
        [Range(0, 1000000000, ErrorMessage = "Paid amount must be positive")]
        public decimal PaidAmount { get; set; }

        [Required(ErrorMessage = "Payment Method is required when updating payment")]
        [RegularExpression("^(Cash|Bank Transfer|Online)$", ErrorMessage = "Method must be 'Cash', 'Bank Transfer', or 'Online'")]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(Unpaid|Paid|Late|Refunded)$", ErrorMessage = "Status must be valid")]
        public string PaymentStatus { get; set; } = string.Empty;

        public DateTime PaymentDate { get; set; } = DateTime.Now; // Cập nhật lại ngày giờ đóng tiền thực tế

        [StringLength(255)]
        public string? Description { get; set; }
    }
}