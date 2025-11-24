using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IUserDAO
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<IEnumerable<User>> GetAllUsersIncludingInactivesAsync();

        Task<User?> GetUserByIDAsync(string id);

        // Cần thiết cho chức năng Đăng Nhập (Login)
        Task<User?> GetUserByUsernameAsync(string username);

        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
    }
}