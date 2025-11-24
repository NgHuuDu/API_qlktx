using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Violations
{
    public class ViolationDeleteDTO
    {
        [Required(ErrorMessage = "Violation ID is required")]
        [StringLength(10, ErrorMessage = "Violation ID cannot exceed 10 chars")]
        public string ViolationID { get; set; } = string.Empty;
    }
}