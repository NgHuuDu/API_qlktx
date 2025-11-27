using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Payments
{
    public class PaymentConfirmDTO
    {
        // Bắt buộc chọn phương thức (Cash / Bank Transfer)
        [Required]
        [RegularExpression("^(Cash|Bank Transfer|Online)$", ErrorMessage = "Phương thức không hợp lệ.")]
        public string PaymentMethod { get; set; } = "Cash";

        // Mã giao dịch hoặc Ghi chú (Optional)
        // Ví dụ: "CK VCB 123456"
        public string? Note { get; set; }
    }
}
