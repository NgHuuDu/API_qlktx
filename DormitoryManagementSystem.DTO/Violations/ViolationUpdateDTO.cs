using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Violations
{
    public class ViolationUpdateDTO
    {
        [Required(ErrorMessage = "Violation Type is required")]
        [StringLength(100, ErrorMessage = "Violation Type cannot exceed 100 chars")]
        public string ViolationType { get; set; } = string.Empty;

        [Range(0, 1000000000, ErrorMessage = "Penalty fee must be a positive number")]
        public decimal PenaltyFee { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("^(Pending|Resolved|Paid)$", ErrorMessage = "Status must be 'Pending', 'Resolved', or 'Paid'")]
        public string Status { get; set; } = string.Empty;

        [StringLength(10)]
        public string? StudentID { get; set; }
    }
}