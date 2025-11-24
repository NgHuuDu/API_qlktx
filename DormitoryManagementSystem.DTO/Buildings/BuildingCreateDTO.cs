using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Buildings
{
    public class BuildingCreateDTO
    {
        [Required(ErrorMessage = "Building ID is required")]
        [StringLength(10, ErrorMessage = "Building ID cannot exceed 10 chars")]
        public string BuildingID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Building Name is required")]
        [StringLength(50, ErrorMessage = "Building name cannot exceed 50 chars")]
        public string BuildingName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Number of rooms is required")]
        [Range(1, 1000, ErrorMessage = "Number of rooms must be between 1 and 1000")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Mixed)$", ErrorMessage = "Gender must be 'Male', 'Female', or 'Mixed'")]
        public string Gender { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}