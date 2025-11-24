using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Users
{
    public class UserCreateDTO
    {
        [Required(ErrorMessage = "User ID is required")]
        [StringLength(10, ErrorMessage = "User ID cannot exceed 10 chars")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "User ID can only contain letters, numbers, and underscore")]
        public string UserID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 chars")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        [RegularExpression("^(Admin|Student)$", ErrorMessage = "Role must be 'Admin' or 'Student'")]
        public string Role { get; set; } = string.Empty;
    }
}