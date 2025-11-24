using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Contracts
{
    public class ContractUpdateDTO
    {
        [Required(ErrorMessage = "Room ID is required")]
        [StringLength(10, ErrorMessage = "Room ID cannot exceed 10 chars")]
        public string RoomID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start Time is required")]
        public DateOnly StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        public DateOnly EndTime { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("^(Active|Expired|Terminated)$", ErrorMessage = "Status must be 'Active', 'Expired', or 'Terminated'")]
        public string Status { get; set; } = string.Empty;
    }
}