using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.News
{
    public class NewsCreateDTO
    {
        [Required(ErrorMessage = "News ID is required")]
        [StringLength(10, ErrorMessage = "News ID cannot exceed 10 chars")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "News ID must be alphanumeric")]
        public string NewsID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 chars")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required")]
        // Content kiểu TEXT (PostgreSQL) chứa được rất nhiều, nhưng DTO nên chặn 1 giới hạn hợp lý
        [StringLength(10000, ErrorMessage = "Content is too long")]
        public string Content { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Category cannot exceed 50 chars")]
        public string? Category { get; set; }

        // 0 = Normal, 1 = High (Pin to top)
        [Range(0, 1, ErrorMessage = "Priority must be 0 (Normal) or 1 (High)")]
        public int Priority { get; set; } = 0;

        public bool IsVisible { get; set; } = true;

        // Nếu FE gửi lên thì validate, nếu BE tự lấy từ Token thì có thể bỏ qua
        [StringLength(10, ErrorMessage = "Author ID cannot exceed 10 chars")]
        public string? AuthorID { get; set; }
    }
}