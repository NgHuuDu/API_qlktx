using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBUS _userBUS;
        public UserController(IUserBUS userBUS) => _userBUS = userBUS;

        [HttpPut("user/change-password")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            var userId = User.FindFirst("UserID")?.Value;
            if (string.IsNullOrEmpty(userId)) throw new UnauthorizedAccessException("Token không hợp lệ.");

            await _userBUS.ChangePasswordAsync(userId, dto);
            return Ok(new { message = "Đổi mật khẩu thành công!" });
        }

        [HttpGet("user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers([FromQuery] string? search)
        {
            var users = await _userBUS.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost("user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO dto)
        {
            var newUserId = await _userBUS.AddUserAsync(dto);
            return StatusCode(201, new { message = "Tạo tài khoản thành công!", userId = newUserId });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userBUS.DeleteUserAsync(id);
            return Ok(new { message = "Xóa tài khoản thành công!" });
        }
    }
}