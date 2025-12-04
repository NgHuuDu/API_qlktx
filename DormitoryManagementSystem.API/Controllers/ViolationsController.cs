using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Violations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly IViolationBUS _violationBUS;
        public ViolationController(IViolationBUS violationBUS) => _violationBUS = violationBUS;

        [HttpGet("student/violations")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMyViolations([FromQuery] string? status)
        {
            var studentId = User.FindFirst("StudentID")?.Value;
            if (string.IsNullOrEmpty(studentId)) throw new UnauthorizedAccessException("Token lỗi.");

            if (string.IsNullOrEmpty(status) || status.ToLower() == "all") status = null;

            var violations = await _violationBUS.GetViolationsWithFilterAsync(status, studentId);
            return Ok(violations);
        }

        [HttpGet("admin/violations")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminList(
            [FromQuery] string? search, [FromQuery] string? status, [FromQuery] string? roomId)
        {
            var list = await _violationBUS.GetViolationsForAdminAsync(search, status, roomId);
            return Ok(list);
        }

        [HttpPost("admin/violations")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateViolation([FromBody] ViolationCreateDTO dto)
        {
            var id = await _violationBUS.AddViolationAsync(dto);
            return Ok(new { message = "Tạo vi phạm thành công", id });
        }

        [HttpPut("admin/violations/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateViolation(string id, [FromBody] ViolationUpdateDTO dto)
        {
            await _violationBUS.UpdateViolationAsync(id, dto);
            return Ok(new { message = "Cập nhật thành công" });
        }

        [HttpDelete("admin/violations/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteViolation(string id)
        {
            await _violationBUS.DeleteViolationAsync(id);
            return Ok(new { message = "Xóa thành công" });
        }
    }
}