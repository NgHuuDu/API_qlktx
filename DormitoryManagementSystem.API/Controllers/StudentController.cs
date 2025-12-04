using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Students;
using DormitoryManagementSystem.Utils; // AppConstants
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

        // ======================== STUDENT ROLE API ========================

        [HttpGet("profile")]
        [Authorize(Roles = AppConstants.Role.Student)]
        public async Task<IActionResult> GetMyProfile()
        {
            var studentId = User.FindFirst("StudentID")?.Value;
            if (string.IsNullOrEmpty(studentId)) throw new UnauthorizedAccessException("Token lỗi: Không tìm thấy StudentID.");

            var profile = await _studentBUS.GetStudentProfileAsync(studentId);
            if (profile == null) throw new KeyNotFoundException("Không tìm thấy hồ sơ sinh viên.");

            return Ok(profile);
        }

        [HttpPut("contact-info")]
        [Authorize(Roles = AppConstants.Role.Student)]
        public async Task<IActionResult> UpdateContactInfo([FromBody] StudentContactUpdateDTO dto)
        {
            var studentId = User.FindFirst("StudentID")?.Value;
            if (string.IsNullOrEmpty(studentId)) throw new UnauthorizedAccessException("Token lỗi.");

            await _studentBUS.UpdateContactInfoAsync(studentId, dto);
            return Ok(new { message = "Cập nhật thông tin liên lạc thành công!" });
        }

        // ======================== ADMIN ROLE API ========================

        // API Tìm kiếm đa năng cho Admin
        [HttpGet]
        [Authorize(Roles = AppConstants.Role.Admin)]
        public async Task<IActionResult> GetStudents(
            [FromQuery] string? keyword,
            [FromQuery] string? major,
            [FromQuery] string? gender,
            [FromQuery] bool? isActive)
        {
            var list = await _studentBUS.SearchStudentsAsync(keyword, major, gender, isActive);
            return Ok(list);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = AppConstants.Role.Admin)]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var student = await _studentBUS.GetStudentByIDAsync(id);
            if (student == null) throw new KeyNotFoundException($"Không tìm thấy sinh viên: {id}");
            return Ok(student);
        }

        [HttpPost]
        [Authorize(Roles = AppConstants.Role.Admin)]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDTO dto)
        {
            var newId = await _studentBUS.AddStudentAsync(dto);
            return StatusCode(201, new { message = "Thêm sinh viên thành công!", studentId = newId });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = AppConstants.Role.Admin)]
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] StudentUpdateDTO dto)
        {
            await _studentBUS.UpdateStudentAsync(id, dto);
            return Ok(new { message = "Cập nhật thông tin thành công!" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = AppConstants.Role.Admin)]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            await _studentBUS.DeleteStudentAsync(id);
            return Ok(new { message = "Xóa hồ sơ sinh viên thành công!" });
        }
    }
}