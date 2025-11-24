using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Users;
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class UserBUS : IUserBUS
    {
        private readonly IUserDAO _userDAO;
        private readonly IMapper _mapper;

        public UserBUS(IUserDAO userDAO, IMapper mapper)
        {
            _userDAO = userDAO;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllUsersAsync()
        {
            var users = await _userDAO.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserReadDTO>>(users);
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllUsersIncludingInactivesAsync()
        {
            var users = await _userDAO.GetAllUsersIncludingInactivesAsync();
            return _mapper.Map<IEnumerable<UserReadDTO>>(users);
        }

        public async Task<UserReadDTO?> GetUserByIDAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("User ID cannot be empty");

            var user = await _userDAO.GetUserByIDAsync(id);
            if (user == null) return null;

            return _mapper.Map<UserReadDTO>(user);
        }

        public async Task<UserReadDTO?> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty");

            var user = await _userDAO.GetUserByUsernameAsync(username);
            if (user == null) return null;

            return _mapper.Map<UserReadDTO>(user);
        }

        public async Task<UserReadDTO?> LoginAsync(UserLoginDTO dto)
        {
            User? user = await _userDAO.GetUserByUsernameAsync(dto.UserName);
            if (user == null) return null;

            if (user.IsActive == false) 
                throw new UnauthorizedAccessException("Account is disabled/deleted.");

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isPasswordValid) return null;

            // 3. Đăng nhập thành công -> Trả về thông tin User (không kèm Password)
            return _mapper.Map<UserReadDTO>(user);
        }

        public async Task<string> AddUserAsync(UserCreateDTO dto)
        {
            User? existingId = await _userDAO.GetUserByIDAsync(dto.UserID);
            if (existingId != null)
                throw new InvalidOperationException($"User ID {dto.UserID} already exists.");

            User? existingUsername = await _userDAO.GetUserByUsernameAsync(dto.UserName);
            if (existingUsername != null)
                throw new InvalidOperationException($"Username '{dto.UserName}' is already taken.");

            User userEntity = _mapper.Map<User>(dto);

            // Hash password trước khi lưu
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _userDAO.AddUserAsync(userEntity);

            return userEntity.Userid;
        }

        public async Task UpdateUserAsync(string id, UserUpdateDTO dto)
        {
            User? userEntity = await _userDAO.GetUserByIDAsync(id);
            if (userEntity == null)
                throw new KeyNotFoundException($"User with ID {id} not found.");

            if (!string.IsNullOrEmpty(dto.Role))
            {
                if (dto.Role != "Admin" && dto.Role != "Student")
                    throw new InvalidOperationException("Role must be either 'Admin' or 'Student'.");
            }

            _mapper.Map(dto, userEntity);

            if (!string.IsNullOrEmpty(dto.Password))
                userEntity.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            userEntity.Userid = id;

            await _userDAO.UpdateUserAsync(userEntity);
        }

        public async Task DeleteUserAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("User ID cannot be empty");

            var user = await _userDAO.GetUserByIDAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found.");

            await _userDAO.DeleteUserAsync(id);
        }
    }
}