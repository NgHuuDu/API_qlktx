using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Violations
{
    public class ViolationCreateDTO
    {
        [Required(ErrorMessage = "Violation ID is required")]
        [StringLength(10, ErrorMessage = "Violation ID cannot exceed 10 chars")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Violation ID must be alphanumeric")]
        public string ViolationID { get; set; } = string.Empty;

        // Nullable: Có thể chưa xác định được sinh viên vi phạm ngay lúc lập biên bản
        [StringLength(10, ErrorMessage = "Student ID cannot exceed 10 chars")]
        public string? StudentID { get; set; }

        [Required(ErrorMessage = "Room ID is required")]
        [StringLength(10, ErrorMessage = "Room ID cannot exceed 10 chars")]
        public string RoomID { get; set; } = string.Empty;

        [StringLength(10, ErrorMessage = "User ID cannot exceed 10 chars")]
        public string? ReportedByUserID { get; set; }

        [Required(ErrorMessage = "Violation Type is required")]
        [StringLength(100, ErrorMessage = "Violation Type cannot exceed 100 chars")]
        public string ViolationType { get; set; } = string.Empty;

        public DateTime? ViolationDate { get; set; } = DateTime.Now;

        [Range(0, 1000000000, ErrorMessage = "Penalty fee must be a positive number")]
        public decimal PenaltyFee { get; set; } = 0;

        [RegularExpression("^(Pending|Resolved|Paid)$", ErrorMessage = "Status must be 'Pending', 'Resolved', or 'Paid'")]
        public string Status { get; set; } = "Pending";
    }
}