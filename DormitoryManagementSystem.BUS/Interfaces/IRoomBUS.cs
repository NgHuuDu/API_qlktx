using DormitoryManagementSystem.DTO.Rooms;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IRoomBUS
    {
        Task<IEnumerable<RoomReadDTO>> GetAllRoomsAsync();
        Task<IEnumerable<RoomReadDTO>> GetAllRoomsIncludingInactivesAsync();
        Task<RoomReadDTO?> GetRoomByIDAsync(string id);
        Task<IEnumerable<RoomReadDTO>> GetRoomsByBuildingIDAsync(string buildingId);
        Task<string> AddRoomAsync(RoomCreateDTO dto);
        Task UpdateRoomAsync(string id, RoomUpdateDTO dto);
        Task DeleteRoomAsync(string id);
    }
}