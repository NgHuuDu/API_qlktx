using DormitoryManagementSystem.DTO.News;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface INewsBUS
    {
        Task<IEnumerable<NewsReadDTO>> GetAllNewsAsync();
        Task<IEnumerable<NewsReadDTO>> GetAllNewsIncludingInactivesAsync();
        Task<NewsReadDTO?> GetNewsByIDAsync(string id);
        Task<string> AddNewsAsync(NewsCreateDTO dto);
        Task UpdateNewsAsync(string id, NewsUpdateDTO dto);
        Task DeleteNewsAsync(string id);




        // Mới thêm - lấy tóm tắt tin tức - trong trang chủ sinh viên
        Task<IEnumerable<NewsSummaryDTO>> GetNewsSummariesAsync();
        
    }
}