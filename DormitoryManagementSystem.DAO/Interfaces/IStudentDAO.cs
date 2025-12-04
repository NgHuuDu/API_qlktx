using DormitoryManagementSystem.Entity;
using DormitoryManagementSystem.DTO.SearchCriteria;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IStudentDAO
    {
        Task<Student?> GetStudentByIDAsync(string id);
        Task<Student?> GetStudentByCCCDAsync(string cccd);
        Task<Student?> GetStudentByEmailAsync(string email);
        Task<Student?> GetStudentByUserIDAsync(string userID);

        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);

        //tìm kiếm
        Task<IEnumerable<Student>> SearchStudentsAsync(StudentSearchCriteria criteria);
    }
}