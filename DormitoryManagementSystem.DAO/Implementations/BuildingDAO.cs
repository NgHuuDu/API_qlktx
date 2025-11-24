
using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class BuildingDAO : IBuildingDAO
    {
        private readonly PostgreDbContext _context;

        public BuildingDAO(PostgreDbContext context)
        {
            this._context = context;

            /*
             * 1.
             * Bỏ using (...) trong từng hàm:
             * Trong ASP.NET Core API, DbContext thường được đăng ký là Scoped. 
             * Nghĩa là nó được tạo ra khi có Request và tự động hủy (Dispose) khi Request kết thúc.
             * Bạn không cần (và không nên) dùng using hoặc Dispose thủ công trong DAO, 
             * vì nó sẽ làm đóng kết nối trước khi Request xử lý xong (gây lỗi "DbContext has been disposed").
             * 
             * 2.
             * Trong hàm GetAll, mình thêm .AsNoTracking(). Đây là kỹ thuật tối ưu hiệu năng.
             * Vì hàm này chỉ lấy dữ liệu ra để xem (Read-Only) chứ không định sửa đổi gì ngay lập tức, 
             * nên EF Core không cần theo dõi sự thay đổi của nó -> Nhanh hơn.
             */
        }

        public async Task<IEnumerable<Building>> GetAllBuildingAsync()
        {
            return await _context.Buildings.AsNoTracking()
                                           .Where(building => building.IsActive == true)
                                           .ToListAsync();
        }

        public async Task<IEnumerable<Building>> GetAllBuildingIncludingInactivesAsync()
        {
            return await _context.Buildings.AsNoTracking().ToListAsync();
        }

        public async Task<Building?> GetByIDAsync(string id)
        {
            return await _context.Buildings.FindAsync(id);
        }

        public async Task AddBuildingAsync(Building building)
        {
            await _context.Buildings.AddAsync(building);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBuildingAsync(string id)
        {
            Building? b = await _context.Buildings.FindAsync(id);

            if (b == null) return;

            b.IsActive = false;

            _context.Buildings.Update(b);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateBuildingAsync(Building building)
        {
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync();
        }
    }
}