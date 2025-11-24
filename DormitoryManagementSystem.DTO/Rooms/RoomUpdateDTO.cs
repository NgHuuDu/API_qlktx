using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Rooms
{
    public class RoomUpdateDTO
    {
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

        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("^(Active|Maintenance|Inactive)$", ErrorMessage = "Status must be 'Active' or 'Maintenance' or 'Inactive'")]
        public string Status { get; set; } = string.Empty;

        public bool AllowCooking { get; set; }

        public bool AirConditioner { get; set; }
    }
}