using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Paymenrs
{
    public class PaymentDeleteDTO
    {
        [Required(ErrorMessage = "Payment id is required")]
        [StringLength(10, ErrorMessage = "Payment id can not exceed 10 chars")]
        public string PaymentID { get; set; } = string.Empty;
    }
}
