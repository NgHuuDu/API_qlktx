using DormitoryManagementSystem.Entity;
using DormitoryManagementSystem.DTO.SearchCriteria;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IStudentDAO
    {
        // Các hàm Get Single (Giữ nguyên)
        Task<Student?> GetStudentByIDAsync(string id);
        Task<Student?> GetStudentByCCCDAsync(string cccd);
        Task<Student?> GetStudentByEmailAsync(string email);
        Task<Student?> GetStudentByUserIDAsync(string userID);

        // CRUD (Giữ nguyên)
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);

        // HÀM SEARCH GỘP (Thay thế GetAll)
        Task<IEnumerable<Student>> SearchStudentsAsync(StudentSearchCriteria criteria);
    }
}