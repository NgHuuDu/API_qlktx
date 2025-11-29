using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.Entity;

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









        //Mới thêm - Student    
        Task<IEnumerable<RoomDetailDTO>> SearchRoomInCardAsync(
                    string? buildingName,
            int? roomNumber,
            int? capacity,
            decimal? minPrice,
            decimal? maxPrice,
            bool? allowCooking,
            bool? airConditioner);
        
        Task<IEnumerable<RoomGridDTO>> SearchRoomInGridAsync(
             string? buildingId,
             int? roomNumber,
             int? capacity,
             decimal? minPrice,
             decimal? maxPrice
         );
      

        Task<RoomDetailDTO?> GetRoomDetailByIDAsync(string id);

        Task<IEnumerable<int>> GetRoomCapacitiesAsync();

        IEnumerable<RoomPriceDTO> GetPriceRanges();

        //ADMIN
        // Lọc theo tên hoặc mã phòng
        Task<IEnumerable<RoomReadDTO>> SearchRoomsAsync(string keyword);

    }
}