using DormitoryManagementSystem.DTO.Buildings;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IBuildingBUS
    {
        Task<IEnumerable<BuildingReadDTO>> GetAllBuildingAsync();
        Task<IEnumerable<BuildingReadDTO>> GetAllBuildingIncludingInactivesAsync();
        Task<BuildingReadDTO?> GetByIDAsync(string id);
        Task<string> AddBuildingAsync(BuildingCreateDTO dto);
        Task UpdateBuildingAsync(string id, BuildingUpdateDTO dto);
        Task DeleteBuildingAsync(string id);
        Task<IEnumerable<BuildingLookupDTO>> GetBuildingLookupAsync();

    }
}