using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Users;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBUS _userBUS;

        public AuthController(IUserBUS userBUS)
        {
            _userBUS = userBUS;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Thiếu thông tin đăng nhập" });
            }

            var loginDto = new UserLoginDTO
            {
                UserName = request.Username,
                Password = request.Password
            };

            try
            {
                var user = await _userBUS.LoginAsync(loginDto);
                if (user == null)
                {
                    return Unauthorized(new { message = "Tên đăng nhập hoặc mật khẩu không đúng" });
                }

                return Ok(new LoginResponse
                {
                    IsSuccess = true,
                    Message = "Đăng nhập thành công",
                    DisplayName = user.UserName,
                    Role = user.Role,
                    Token = Guid.NewGuid().ToString(),
                    User = new UserSummary
                    {
                        UserId = user.UserID,
                        Username = user.UserName,
                        Role = user.Role
                    }
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Log exception for debugging
                return StatusCode(500, new { message = $"Lỗi hệ thống: {ex.Message}" });
            }
        }

        public class LoginRequest
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        public class LoginResponse
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; } = string.Empty;
            public string? DisplayName { get; set; }
            public string? Role { get; set; }
            public string Token { get; set; } = string.Empty;
            public UserSummary? User { get; set; }
        }

        public class UserSummary
        {
            public string UserId { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
        }
    }
}

