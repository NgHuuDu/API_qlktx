using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Admins
{
    public class AdminCreateDTO
    {
        [Required(ErrorMessage = "Admin ID is required")]
        [StringLength(10, ErrorMessage = "Admin ID cannot exceed 10 chars")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Admin ID can only contain letters, numbers and underscore")]
        public string AdminID { get; set; } = string.Empty;

        [Required(ErrorMessage = "User ID is required")]
        [StringLength(10, ErrorMessage = "User ID cannot exceed 10 chars")]
        public string UserID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 chars")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "ID Card is required")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "ID Card must be exactly 12 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "ID Card must contain only numbers")]
        public string IDcard { get; set; } = string.Empty;

        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be 'Male' or 'Female'")]
        public string? Gender { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number format")]
        [StringLength(15, ErrorMessage = "Phone Number cannot exceed 15 chars")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 chars")]
        public string? Email { get; set; }
    }
}