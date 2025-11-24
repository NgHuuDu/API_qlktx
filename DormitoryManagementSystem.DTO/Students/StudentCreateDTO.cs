using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Students
{
    public class StudentCreateDTO
    {
        [Required(ErrorMessage = "Student ID is required")]
        [StringLength(10, ErrorMessage = "Student ID cannot exceed 10 chars")]
        public string StudentID { get; set; } = string.Empty;

        [Required(ErrorMessage = "User id is required")]
        [StringLength(10, ErrorMessage = "User id can not exceed 10 chars")]
        public string UserID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 chars")]
        public string FullName { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Major cannot exceed 100 chars")]
        public string? Major { get; set; }

        [StringLength(50, ErrorMessage = "Department cannot exceed 50 chars")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be 'Male' or 'Female'")]
        public string Gender { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; } // Trong DB trường này không bắt buộc (nullable)

        [Required(ErrorMessage = "CCCD is required")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "CCCD must be exactly 12 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CCCD must contain only numbers")]
        public string CCCD { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number format")]
        [StringLength(15, ErrorMessage = "Phone Number cannot exceed 15 chars")]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 chars")]
        public string? Email { get; set; } // Trong DB trường này nullable và unique

        [StringLength(255, ErrorMessage = "Address cannot exceed 255 chars")]
        public string? Address { get; set; }
    }
}