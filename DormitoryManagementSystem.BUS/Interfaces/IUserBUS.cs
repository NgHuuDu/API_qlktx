using DormitoryManagementSystem.DTO.Users;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IUserBUS
    {
        Task<IEnumerable<UserReadDTO>> GetAllUsersAsync();
        Task<IEnumerable<UserReadDTO>> GetAllUsersIncludingInactivesAsync();
        Task<UserReadDTO?> GetUserByIDAsync(string id);

        // Hàm này dùng cho Admin tìm kiếm User để quản lý
        Task<UserReadDTO?> GetUserByUsernameAsync(string username);

        // Hàm xử lý nghiệp vụ Đăng nhập
        // Input: LoginDTO, Output: UserReadDTO (hoặc trả về string Token sau này)
        Task<UserReadDTO?> LoginAsync(UserLoginDTO dto);

        // Đăng ký/Tạo User mới
        Task<string> AddUserAsync(UserCreateDTO dto);

        // Đổi mật khẩu hoặc Role
        Task UpdateUserAsync(string id, UserUpdateDTO dto);

        Task DeleteUserAsync(string id);
    }
}