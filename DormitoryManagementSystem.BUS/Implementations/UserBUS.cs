using System.Security.Claims;
using System.Text;
using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Users;
using DormitoryManagementSystem.Entity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class UserBUS : IUserBUS
    {
        private readonly IUserDAO _userDAO;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration; // Inject thêm cái này để lấy Secret Key

        public UserBUS(IUserDAO userDAO, IMapper mapper, IConfiguration configuration)
        {
            _userDAO = userDAO;
            _mapper = mapper;
            _configuration = configuration;
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

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty");

            var user = await _userDAO.GetUserByUsernameAsync(username);
            if (user == null) return null;

            return user;
        }

        public async Task<LoginResponseDTO?> LoginAsync(UserLoginDTO dto)
        {
            User? user = await _userDAO.GetUserByUsernameAsync(dto.UserName);
            if (user == null) return null;

            if (user.IsActive == false) 
                throw new UnauthorizedAccessException("Account is disabled/deleted.");

            // Nếu login tab Sinh viên mà user là Admin -> Chặn
            if (user.Role != dto.Role) return null;


            bool isPasswordValid = false;
            bool isPlainTextPassword = !IsBCryptHash(user.Password);

            if (isPlainTextPassword)
            {
                // Password chưa được hash - so sánh plain text (backward compatible)
                isPasswordValid = user.Password == dto.Password;
                
                // Nếu đăng nhập thành công, tự động hash và update password
                if (isPasswordValid)
                {
                    // Lấy user với tracking để có thể update
                    User? userToUpdate = await _userDAO.GetUserByIDAsync(user.Userid);
                    if (userToUpdate != null)
                    {
                        userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                        await _userDAO.UpdateUserAsync(userToUpdate);
                    }
                }
            }
            else
            {
                // Password đã được hash - dùng BCrypt verify
                try
                {
                    isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
                }
                catch (Exception)
                {
                    // Nếu BCrypt verify fail, password không đúng
                    isPasswordValid = false;
                }
            }

            if (!isPasswordValid) return null;

            string token = GenerateJwtToken(user);

            // 3. Đăng nhập thành công -> Trả về thông tin User (không kèm Password)
            return new LoginResponseDTO
            {
                Token = token,
                UserID = user.Userid,
                UserName = user.Username,
                Role = user.Role
            };
        }

        private bool IsBCryptHash(string hash)
        {
            // BCrypt hash luôn bắt đầu với $2a$, $2b$, $2x$, $2y$ và có độ dài 60 ký tự
            if (string.IsNullOrWhiteSpace(hash) || hash.Length != 60)
                return false;

            return hash.StartsWith("$2a$") || 
                   hash.StartsWith("$2b$") || 
                   hash.StartsWith("$2x$") || 
                   hash.StartsWith("$2y$");
        }

        private string GenerateJwtToken(User user)
        {
            // 1. Lấy Key ra và kiểm tra null ngay lập tức
            var secretKey = _configuration["Jwt:Key"];

            // Nếu quên cấu hình trong appsettings.json -> Báo lỗi ngay để biết đường sửa
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Chưa cấu hình 'Jwt:Key' trong file appsettings.json");
            }

            // 2. Lấy Issuer và Audience (Dùng toán tử ?? "" để nếu null thì lấy chuỗi rỗng, tránh lỗi đỏ)
            var issuer = _configuration["Jwt:Issuer"] ?? "";
            var audience = _configuration["Jwt:Audience"] ?? "";

            // 3. Bây giờ biến 'secretKey' chắc chắn không null, ném vào GetBytes vô tư
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim("UserID", user.Userid),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role),
        // Dùng toán tử ?? "" để tránh lỗi nếu Studentid bị null
        new Claim("StudentID", user.Student?.Studentid ?? "")   
        };

            var token = new JwtSecurityToken(
                issuer: issuer,      // Đã xử lý null ở trên
                audience: audience,  // Đã xử lý null ở trên
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
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