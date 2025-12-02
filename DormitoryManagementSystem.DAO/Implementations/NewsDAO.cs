using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class NewsDAO : INewsDAO
    {
        private readonly PostgreDbContext _context;

        public NewsDAO(PostgreDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            return await _context.News.AsNoTracking()
                                       .Where(news => news.Isvisible == true)
                                       .ToListAsync();
        }

        public async Task<IEnumerable<News>> GetAllNewsIncludingInactivesAsync()
        {
            return await _context.News.AsNoTracking().ToListAsync();
        }

        public async Task<News?> GetNewsByIDAsync(string id)
        {
            return await _context.News.FindAsync(id);
        }

        public async Task AddNewsAsync(News newNews)
        {
            await _context.News.AddAsync(newNews);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNewsAsync(News newNews)
        {
            _context.News.Update(newNews);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNewsAsync(string id)
        {
            News? n = await _context.News.FindAsync(id);
            if (n == null) return;

            n.Isvisible = false;

            _context.News.Update(n);
            await _context.SaveChangesAsync();
        }


        //Mới thêm - Lấy danh sách tóm tắt tin tức
        public async Task<IEnumerable<News>> GetNewsSummariesAsync()
        {

            return await _context.News
                .AsNoTracking()
                .Where(n => n.Isvisible == true)
                .OrderByDescending(n => n.Publisheddate) // Mới nhất lên đầu
                .ToListAsync();
        }
    }
}
