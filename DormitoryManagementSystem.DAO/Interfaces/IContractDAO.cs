using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IContractDAO
    {
        Task<IEnumerable<Contract>> GetAllContractsAsync();
        Task<IEnumerable<Contract>> GetAllContractsIncludingInactivesAsync();
        Task<Contract?> GetContractByIDAsync(string id);

        // Tìm tất cả hợp đồng của 1 sinh viên (để xem lịch sử)
        Task<IEnumerable<Contract>> GetContractsByStudentIDAsync(string studentId);

        // Tìm hợp đồng đang Active của sinh viên (để check logic không cho thuê 2 phòng)
        Task<Contract?> GetActiveContractByStudentIDAsync(string studentId);

        Task AddContractAsync(Contract contract);
        Task UpdateContractAsync(Contract contract);
        Task DeleteContractAsync(string id);


        //Mới thêm - lấy chi tiết hợp đồng - Student - Hồ sơ sinh viên
        Task<Contract?> GetContractDetailAsync(string studentId);

    }
}