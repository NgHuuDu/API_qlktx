using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.News
{
    public class NewsDeleteDTO
    {
        [Required(ErrorMessage = "News ID is required")]
        [StringLength(10, ErrorMessage = "News ID cannot exceed 10 chars")]
        public string NewsID { get; set; } = string.Empty;
    }
}