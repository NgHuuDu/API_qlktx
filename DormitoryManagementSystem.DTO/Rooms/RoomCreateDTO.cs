using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Rooms
{
    public class RoomCreateDTO
    {
        [Required(ErrorMessage = "Room ID is required")]
        [StringLength(10, ErrorMessage = "Room ID cannot exceed 10 chars")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]*$", ErrorMessage = "Room ID can only contain letters, numbers, and basic special chars")]
        public string RoomID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Room Number is required")]
        [Range(1, 9999, ErrorMessage = "Room Number must be valid")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Building ID is required")]
        [StringLength(10, ErrorMessage = "Building ID cannot exceed 10 chars")]
        public string BuildingID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, 50, ErrorMessage = "Capacity must be between 1 and 50")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 1000000000, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [RegularExpression("^(Active|Maintenance)$", ErrorMessage = "Status must be 'Active' or 'Maintenance'")]
        public string Status { get; set; } = "Active";

        public bool AllowCooking { get; set; } = false;

        public bool AirConditioner { get; set; } = false;
    }
}