using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IViolationDAO
    {
        public Task<IEnumerable<Violation>> GetAllViolationsAsync();
        public Task<Violation?> GetViolationByIdAsync(string id);
        public Task<IEnumerable<Violation>> GetViolationsByStudentIDAsync(string studentID);
        public Task<IEnumerable<Violation>> GetViolationsByStatusAsync(string status);
        public Task<IEnumerable<Violation>> GetViolationsByRoomIDAsync(string roomID);
        public Task AddNewViolationAsync(Violation violation);
        public Task UpdateViolationAsync(Violation violation);
        public Task DeleteViolationAsync(string id);

        // Mới 
        // Lấy vi phạm theo mã sinh viên có bao gồm phòng
        public Task<IEnumerable<Violation>> GetMyViolations(string studentId);
        Task<IEnumerable<Violation>> GetMyViolationsByStatus(string studentId, string status);

    }
}
