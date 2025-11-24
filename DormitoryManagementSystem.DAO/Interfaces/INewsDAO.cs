using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface INewsDAO
    {
        public Task<IEnumerable<News>> GetAllNewsAsync();
        public Task<IEnumerable<News>> GetAllNewsIncludingInactivesAsync();
        public Task<News?> GetNewsByIDAsync(string id);
        public Task AddNewsAsync(News newNews);
        public Task UpdateNewsAsync(News newNews);
        public Task DeleteNewsAsync(string id);
    }
}
