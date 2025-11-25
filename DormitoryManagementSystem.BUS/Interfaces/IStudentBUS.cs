using DormitoryManagementSystem.DTO.Students;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IStudentBUS
    {
        Task<IEnumerable<StudentReadDTO>> GetAllStudentsAsync();
        Task<IEnumerable<StudentReadDTO>> GetAllStudentsIncludingInactivesAsync();
        Task<StudentReadDTO?> GetStudentByIDAsync(string id);
        Task<StudentReadDTO?> GetStudentByCCCDAsync(string cccd);
        Task<StudentReadDTO?> GetStudentByEmailAsync(string email);
        Task<string> AddStudentAsync(StudentCreateDTO dto);
        Task UpdateStudentAsync(string id, StudentUpdateDTO dto);
        Task DeleteStudentAsync(string id);
        Task<StudentProfileDTO?> GetStudentProfileAsync(string studentId);

    }
}