using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Students
{
    public class StudentUpdateDTO
    {
        [Required(ErrorMessage = "User id is required")]
        [StringLength(10, ErrorMessage = "User id can not exceed 10 chars")]
        public string UserID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 chars")]
        public string FullName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Major { get; set; }

        [StringLength(50)]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be 'Male' or 'Female'")]
        public string Gender { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; }

        [Required(ErrorMessage = "CCCD is required")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "CCCD must be exactly 12 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CCCD must contain only numbers")]
        public string CCCD { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number format")]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }
    }
}