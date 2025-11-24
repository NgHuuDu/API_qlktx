using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.News
{
    public class NewsUpdateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 chars")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required")]
        [StringLength(10000, ErrorMessage = "Content is too long")]
        public string Content { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Category can not exceed 50 chars")]
        public string? Category { get; set; }

        [Range(0, 1, ErrorMessage = "Priority must be 0 (Normal) or 1 (High)")]
        public int Priority { get; set; }

        public bool IsVisible { get; set; }
    }
}