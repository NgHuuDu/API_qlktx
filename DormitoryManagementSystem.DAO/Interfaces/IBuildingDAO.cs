using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IBuildingDAO
    {
        public Task<IEnumerable<Building>> GetAllBuildingAsync();
        public Task<IEnumerable<Building>> GetAllBuildingIncludingInactivesAsync();
        Task<Building?> GetByIDAsync(string id);
        Task AddBuildingAsync(Building building);
        Task UpdateBuildingAsync(Building building);
        Task DeleteBuildingAsync(string id);
    }
}
