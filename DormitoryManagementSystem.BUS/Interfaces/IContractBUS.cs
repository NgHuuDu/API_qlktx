using DormitoryManagementSystem.DTO.Contracts;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IContractBUS
    {
        Task<IEnumerable<ContractReadDTO>> GetAllContractsAsync();
        Task<IEnumerable<ContractReadDTO>> GetAllContractsIncludingInactivesAsync();
        Task<ContractReadDTO?> GetContractByIDAsync(string id);
        Task<IEnumerable<ContractReadDTO>> GetContractsByStudentIDAsync(string studentId);
        Task<ContractReadDTO?> GetActiveContractByStudentIDAsync(string studentId);
        Task<string> AddContractAsync(ContractCreateDTO dto);
        Task UpdateContractAsync(string id, ContractUpdateDTO dto);
        Task DeleteContractAsync(string id);
    }
}