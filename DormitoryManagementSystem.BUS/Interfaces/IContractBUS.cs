using DormitoryManagementSystem.DTO.Contracts;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IContractBUS
    {
        Task<IEnumerable<ContractReadDTO>> GetAllContractsAsync();
        Task<ContractReadDTO?> GetContractByIDAsync(string id);

        // Search & Filter 
        Task<IEnumerable<ContractReadDTO>> GetContractsByStudentIDAsync(string studentId);
        Task<IEnumerable<ContractReadDTO>> GetContractsAsync(string searchTerm);
        Task<IEnumerable<ContractReadDTO>> GetContractsByMultiConditionAsync(ContractFilterDTO filter);


        Task<ContractDetailDTO?> GetContractFullDetailAsync(string studentId);
        Task<string> RegisterContractAsync(string studentId, ContractRegisterDTO dto);


        Task<string> AddContractAsync(ContractCreateDTO dto, string staffUserID);
        Task UpdateContractAsync(string id, ContractUpdateDTO dto);
        Task DeleteContractAsync(string id);
    }
}