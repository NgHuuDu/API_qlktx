using DormitoryManagementSystem.Entity;
using DormitoryManagementSystem.DTO.SearchCriteria; 

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IViolationDAO
    {
        // CRUD
        Task<Violation?> GetViolationByIdAsync(string id);
        Task AddNewViolationAsync(Violation violation);
        Task UpdateViolationAsync(Violation violation);
        Task DeleteViolationAsync(string id);

        // Tìm kiếm
        Task<IEnumerable<Violation>> SearchViolationsAsync(ViolationSearchCriteria criteria);
    }
}