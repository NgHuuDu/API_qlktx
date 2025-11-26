using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IRoomDAO
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<IEnumerable<Room>> GetAllRoomsIncludingInactivesAsync();
        Task<Room?> GetRoomByIDAsync(string id);
        //Lấy danh sách phòng thuộc 1 tòa nhà
        Task<IEnumerable<Room>> GetRoomsByBuildingIDAsync(string buildingId);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(string id);



        //Mới thêm  - Lọc phòng của student 
        Task<IEnumerable<Room>> GetRoomsByFilterAsync(
             string? buildingId,
             int? roomNumber,
             int? capacity,
             decimal? minPrice,
             decimal? maxPrice,
             bool? allowCooking,    
             bool? airConditioner);

        // Hiện thị phòng gồm building
        Task<IEnumerable<Room>> GetAllRoomsWithBuildingAsync();

    }
}