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


        //Student
        // API : Lấy danh sách vi phạm của chính mình
        [HttpGet("my-violations")]
        //[Authorize(Roles = "Student")] // tắt cái này để test
        public async Task<IActionResult> GetMyViolations()
        {
            try
            {
                // var studentId = User.FindFirst("StudentID")?.Value;
                var studentId = "STU003"; // Dùng để test tạm thời, nhớ xóa khi có Token

                if (string.IsNullOrEmpty(studentId))
                    return Unauthorized(new { message = "Không tìm thấy thông tin sinh viên." });

                var violations = await _violationBUS.GetMyViolations(studentId);

                return Ok(violations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server: " + ex.Message });
            }
        }

    }
}