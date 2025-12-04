using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Admins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DormitoryManagementSystem.Utils; 


namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = AppConstants.Role.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBUS _adminBUS;

        public AdminController(IAdminBUS adminBUS) => _adminBUS = adminBUS;

        [HttpGet("admins")]
        public async Task<ActionResult<IEnumerable<AdminReadDTO>>> GetAllAdmins()
        {
            var admins = await _adminBUS.GetAllAdminsAsync();
            return Ok(admins.OrderBy(a => a.UserID));
        }

        [HttpGet("admins/{id}")]
        public async Task<IActionResult> GetAdminById(string id)
        {
            var admin = await _adminBUS.GetAdminByIDAsync(id);
            if (admin == null) throw new KeyNotFoundException($"Không tìm thấy Admin: {id}");
            return Ok(admin);
        }

        [HttpPost("admins")]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminCreateDTO dto)
        {
            var newAdminId = await _adminBUS.AddAdminAsync(dto);
            return StatusCode(201, new { message = "Thêm Admin thành công!", adminId = newAdminId });
        }

        [HttpPut("admins/{id}")]
        public async Task<IActionResult> UpdateAdmin(string id, [FromBody] AdminUpdateDTO dto)
        {
            await _adminBUS.UpdateAdminAsync(id, dto);
            return Ok(new { message = "Cập nhật thông tin Admin thành công!" });
        }

        [HttpDelete("admins/{id}")]
        public async Task<IActionResult> DeleteAdmin(string id)
        {
            await _adminBUS.DeleteAdminAsync(id);
            return Ok(new { message = "Xóa Admin thành công!" });
        }
    }
}