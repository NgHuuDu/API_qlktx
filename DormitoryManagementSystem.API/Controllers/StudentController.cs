using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBUS _studentBUS;
        public StudentController(IStudentBUS studentBUS) => _studentBUS = studentBUS;

        [HttpGet("profile")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMyProfile()
        {
            var studentId = User.FindFirst("StudentID")?.Value;
            if (string.IsNullOrEmpty(studentId)) throw new UnauthorizedAccessException("Token lỗi: Không có StudentID.");

            var profile = await _studentBUS.GetStudentProfileAsync(studentId);
            if (profile == null) throw new KeyNotFoundException("Không tìm thấy hồ sơ sinh viên.");

            return Ok(profile);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDTO dto)
        {
            var newStudentId = await _studentBUS.AddStudentAsync(dto);
            return StatusCode(201, new { message = "Thêm sinh viên thành công!", studentId = newStudentId });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Nên bật lại Authorize để bảo mật
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] StudentUpdateDTO dto)
        {
            await _studentBUS.UpdateStudentAsync(id, dto);
            return Ok(new { message = "Cập nhật thông tin thành công!" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            await _studentBUS.DeleteStudentAsync(id);
            return Ok(new { message = "Xóa hồ sơ sinh viên thành công!" });
        }

        [HttpPut("contact-info")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> UpdateContactInfo([FromBody] StudentContactUpdateDTO dto)
        {
            var studentId = User.FindFirst("StudentID")?.Value;
            if (string.IsNullOrEmpty(studentId)) throw new UnauthorizedAccessException("Token lỗi.");

            await _studentBUS.UpdateContactInfoAsync(studentId, dto);
            return Ok(new { message = "Cập nhật thông tin liên lạc thành công!" });
        }
    }
}