using DormitoryManagementSystem.DTO.Students;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IStudentBUS
    {
        // --- SEARCH & READ ---
        // Hàm Search đa năng cho Admin (thay thế GetAll)
        Task<IEnumerable<StudentReadDTO>> SearchStudentsAsync(string? keyword, string? major, string? gender, bool? isActive);

        // Lấy chi tiết
        Task<StudentReadDTO?> GetStudentByIDAsync(string id);

        // --- TRANSACTIONS ---
        Task<string> AddStudentAsync(StudentCreateDTO dto);
        Task UpdateStudentAsync(string id, StudentUpdateDTO dto);
        Task DeleteStudentAsync(string id); // Soft Delete thông qua User

        // --- STUDENT FEATURES ---
        // Lấy hồ sơ chi tiết (kèm nợ, phòng ở) cho trang Profile
        Task<StudentProfileDTO?> GetStudentProfileAsync(string studentId);

        // Sinh viên tự cập nhật thông tin liên lạc
        Task UpdateContactInfoAsync(string studentId, StudentContactUpdateDTO dto);
    }
}