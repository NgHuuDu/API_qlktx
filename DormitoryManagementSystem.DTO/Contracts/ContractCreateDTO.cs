using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Contracts
{
    public class ContractCreateDTO
    {
        [Required(ErrorMessage = "Contract ID is required")]
        [StringLength(10, ErrorMessage = "Contract ID cannot exceed 10 chars")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Contract ID must be alphanumeric")]
        public string ContractID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student ID is required")]
        [StringLength(10, ErrorMessage = "Student ID cannot exceed 10 chars")]
        public string StudentID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Room ID is required")]
        [StringLength(10, ErrorMessage = "Room ID cannot exceed 10 chars")]
        public string RoomID { get; set; } = string.Empty;

        // StaffUserID có thể null trong code (nếu hệ thống tự lấy user đang login), 
        // nhưng nếu gửi từ FE thì cần validate độ dài.
        [StringLength(10, ErrorMessage = "Staff User ID cannot exceed 10 chars")]
        public string? StaffUserID { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        public DateOnly StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        public DateOnly EndTime { get; set; }

        [RegularExpression("^(Active|Expired|Terminated)$", ErrorMessage = "Status must be 'Active', 'Expired', or 'Terminated'")]
        public string Status { get; set; } = "Active";
    }
}