using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class AdminDAO : IAdminDAO
    {
        private readonly PostgreDbContext _context;

        public AdminDAO(PostgreDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.AsNoTracking()
                                        .Where(admin => admin.User.IsActive == true)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsIncludingInactivesAsync()
        {
            return await _context.Admins.AsNoTracking()
                                        .ToListAsync();
        }

        public async Task<Admin?> GetAdminByIDAsync(string id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<Admin?> GetAdminByUserIDAsync(string userID)
        {
            return await _context.Admins.AsNoTracking()
                                        .Where(admin => admin.Userid == userID)
                                        .FirstOrDefaultAsync();
        }

        public async Task<Admin?> GetAdminByCCCDAsync(string cccd)
        {
            return await _context.Admins.AsNoTracking()
                                        .Where(admin => admin.Idcard == cccd)
                                        .FirstOrDefaultAsync();
        }

        public async Task AddAdminAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdminAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteAdminAsync(string id)
        //{
        //    Admin? ad = await _context.Admins.FindAsync(id);
        //    if (ad == null) return;

            

        //    await _context.SaveChangesAsync();
        //}
    }
}
