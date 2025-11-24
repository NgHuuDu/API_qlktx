using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Buildings
{
    public class BuildingDeleteDTO
    {
        [Required(ErrorMessage = "Building id is required")]
        [StringLength(10, ErrorMessage = "Building id can not exceed 10 chars")]
        public string BuildingID { get; set; } = string.Empty;
    }
}
