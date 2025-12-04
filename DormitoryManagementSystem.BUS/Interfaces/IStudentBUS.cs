using DormitoryManagementSystem.DTO.Students;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IStudentBUS
    {
       
        Task<IEnumerable<StudentReadDTO>> SearchStudentsAsync(string? keyword, string? major, string? gender, bool? isActive);

        Task<StudentReadDTO?> GetStudentByIDAsync(string id);

        Task<string> AddStudentAsync(StudentCreateDTO dto);
        Task UpdateStudentAsync(string id, StudentUpdateDTO dto);
        Task DeleteStudentAsync(string id); 

        Task<StudentProfileDTO?> GetStudentProfileAsync(string studentId);

        Task UpdateContactInfoAsync(string studentId, StudentContactUpdateDTO dto);
    }
}