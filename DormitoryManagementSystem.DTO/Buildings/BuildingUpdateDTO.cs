using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Buildings
{
    public class BuildingUpdateDTO
    {
        [Required(ErrorMessage = "Building Name is required")]
        [StringLength(50, ErrorMessage = "Building name can not exceed 50 chars")]
        public string BuildingName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Number of rooms is required")]
        [Range(1, 1000, ErrorMessage = "Number of rooms must be positive")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Mixed)$", ErrorMessage = "Gender must be 'Male', 'Female', or 'Mixed'")]
        public string Gender { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}