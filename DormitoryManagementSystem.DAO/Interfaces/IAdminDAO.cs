using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IAdminDAO
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<IEnumerable<Admin>> GetAllAdminsIncludingInactivesAsync();
        Task<Admin?> GetAdminByIDAsync(string id);

        Task<Admin?> GetAdminByUserIDAsync(string userId);

        Task<Admin?> GetAdminByCCCDAsync(string cccd);

        Task AddAdminAsync(Admin admin);
        Task UpdateAdminAsync(Admin admin);
    }
}