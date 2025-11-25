using System.Security.Claims; 
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBUS _userBUS;

        public UserController(IUserBUS userBUS)
        {
            _userBUS = userBUS;
        }

        // PUT: api/user/change-password
        [HttpPut("change-password")]
        //[Authorize] //tắt đi để test, nào chạy chính thì hãy mở
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            try
            {
                
                 var userId = User.FindFirst("UserID")?.Value;
                //var userId = "U_STU01"; Dùng cái này để test

                if (string.IsNullOrEmpty(userId))
                    return Unauthorized(new { message = "Token không hợp lệ hoặc đã hết hạn." });

                await _userBUS.ChangePasswordAsync(userId, dto);

                return Ok(new { message = "Đổi mật khẩu thành công!" });
            }
            catch (ArgumentException ex) // Lỗi do người dùng (sai pass cũ, trùng pass cũ)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex) // Lỗi không tìm thấy user
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex) // Lỗi hệ thống khác
            {
                return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }
    }
}