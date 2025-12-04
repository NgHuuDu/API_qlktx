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




        Task<IEnumerable<NewsSummaryDTO>> GetNewsSummariesAsync();
        
    }
}