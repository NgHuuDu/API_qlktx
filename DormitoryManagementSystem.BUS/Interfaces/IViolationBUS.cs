using DormitoryManagementSystem.DTO.Violations;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IViolationBUS
    {
        Task<IEnumerable<ViolationReadDTO>> GetAllViolationsAsync();
        Task<ViolationReadDTO?> GetViolationByIDAsync(string id);
        Task<IEnumerable<ViolationReadDTO>> GetViolationsByStudentIDAsync(string studentId);
        Task<IEnumerable<ViolationReadDTO>> GetViolationsByRoomIDAsync(string roomId);
        Task<IEnumerable<ViolationReadDTO>> GetViolationsByStatusAsync(string status);
        Task<string> AddViolationAsync(ViolationCreateDTO dto);
        Task UpdateViolationAsync(string id, ViolationUpdateDTO dto);
        Task DeleteViolationAsync(string id);

        //Mới thêm cho bản sinh viên thấy violation của mình
        Task<IEnumerable<ViolationListDTO>> GetViolationsByStudentID(string studentId);

    }
}