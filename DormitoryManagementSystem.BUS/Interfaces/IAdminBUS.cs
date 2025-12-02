using DormitoryManagementSystem.DTO.Admins;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IAdminBUS
    {
        Task<IEnumerable<AdminReadDTO>> GetAllAdminsAsync();
        Task<IEnumerable<AdminReadDTO>> GetAllAdminsIncludingInactivesAsync();
        Task<AdminReadDTO?> GetAdminByIDAsync(string id);
        Task<AdminReadDTO?> GetAdminByUserIDAsync(string userId);
        Task<string> AddAdminAsync(AdminCreateDTO dto);
        Task UpdateAdminAsync(string id, AdminUpdateDTO dto);
        Task DeleteAdminAsync(string id);
    }
}