using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IStudentDAO
    {
        public Task<IEnumerable<Student>> GetAllStudentsAsync();
        public Task<IEnumerable<Student>> GetAllStudentsIncludingInactivesAsync();
        public Task<Student?> GetStudentByIDAsync(string id);
        public Task<Student?> GetStudentByCCCDAsync(string cccd);
        public Task<Student?> GetStudentByEmailAsync(string email);
        public Task<Student?> GetStudentByUserIDAsync(string userID);
        public Task AddStudentAsync(Student student);
        public Task UpdateStudentAsync(Student student);
        //public Task DeleteStudentAsync(string id);
    }
}
