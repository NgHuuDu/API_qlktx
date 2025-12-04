using DormitoryManagementSystem.DTO.SearchCriteria; // ContractSearchCriteria
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IContractDAO
    {
        Task<Contract?> GetContractByIDAsync(string id);
        Task AddContractAsync(Contract contract);
        Task UpdateContractAsync(Contract contract);
        Task DeleteContractAsync(string id);

        // Check logic 
        Task<Contract?> GetActiveContractByStudentIDAsync(string studentId);
        Task<Contract?> GetContractDetailAsync(string studentId); 

        // tìm kiếm

        Task<IEnumerable<Contract>> SearchContractsAsync(ContractSearchCriteria criteria);
    }
}