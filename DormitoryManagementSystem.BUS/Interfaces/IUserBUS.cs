using DormitoryManagementSystem.DTO.Users;
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IUserBUS
    {
        Task<IEnumerable<UserReadDTO>> GetAllUsersAsync();
        Task<IEnumerable<UserReadDTO>> GetAllUsersIncludingInactivesAsync();
        Task<UserReadDTO?> GetUserByIDAsync(string id);

        Task<User?> GetUserByUsernameAsync(string username);






      
        Task<LoginResponseDTO?> LoginAsync(UserLoginDTO dto);

        Task<string> AddUserAsync(UserCreateDTO dto);

        Task UpdateUserAsync(string id, UserUpdateDTO dto);

        Task DeleteUserAsync(string id);

        Task ChangePasswordAsync(string userId, ChangePasswordDTO dto);
    }
}