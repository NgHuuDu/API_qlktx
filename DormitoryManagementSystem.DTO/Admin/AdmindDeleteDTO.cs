using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Admins
{
    public class AdminDeleteDTO
    {
        [Required(ErrorMessage = "Admin ID is required")]
        [StringLength(10, ErrorMessage = "Admin ID cannot exceed 10 chars")]
        public string AdminID { get; set; } = string.Empty;
    }
}