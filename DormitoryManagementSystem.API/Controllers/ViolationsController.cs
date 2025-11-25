using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DormitoryManagementSystem.BUS.Interfaces;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly IViolationBUS _violationBUS;

        public ViolationController(IViolationBUS violationBUS)
        {
            _violationBUS = violationBUS;
        }

        // API 1: Lấy danh sách vi phạm của CHÍNH MÌNH (Dành cho Sinh viên)
        [HttpGet("my-violations")]
        //[Authorize(Roles = "Student")] // Chỉ sinh viên được gọi
        public async Task<IActionResult> GetMyViolations()
        {
            try
            {
                // 1. Lấy ID từ Token
                var studentId = User.FindFirst("StudentID")?.Value;


                if (string.IsNullOrEmpty(studentId))
                    return Unauthorized(new { message = "Không tìm thấy thông tin sinh viên." });

                // 2. Gọi BUS
                var violations = await _violationBUS.GetViolationsByStudentIDAsync(studentId);

                return Ok(violations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server: " + ex.Message });
            }
        }

        // API 2: Lấy vi phạm của sinh viên bất kỳ (Dành cho Admin quản lý)
        [HttpGet("student/{studentId}")]
        //  [Authorize(Roles = "Admin")] // Chỉ Admin được gọi
        public async Task<IActionResult> GetStudentViolations(string studentId)
        {
            var violations = await _violationBUS.GetViolationsByStudentIDAsync(studentId);
            return Ok(violations);
        }
    }
}