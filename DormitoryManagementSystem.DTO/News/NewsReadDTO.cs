namespace DormitoryManagementSystem.DTO.News
{
    public class NewsReadDTO
    {
        public string NewsID { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Category { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Priority { get; set; }
        public bool IsVisible { get; set; }
        public string? AuthorID { get; set; }
        public string? AuthorName { get; set; } 
    }
}