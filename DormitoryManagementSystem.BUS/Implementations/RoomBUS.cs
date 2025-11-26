using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class RoomBUS : IRoomBUS
    {
        private readonly IRoomDAO _roomDAO;
        private readonly IBuildingDAO _buildingDAO;
        private readonly IMapper _mapper;

        public RoomBUS(IRoomDAO roomDAO, IBuildingDAO buildingDAO, IMapper mapper)
        {
            _roomDAO = roomDAO;
            _buildingDAO = buildingDAO;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomReadDTO>> GetAllRoomsAsync()
        {
            IEnumerable<Room> rooms = await _roomDAO.GetAllRoomsAsync();
            return _mapper.Map<IEnumerable<RoomReadDTO>>(rooms);
        }

        public async Task<IEnumerable<RoomReadDTO>> GetAllRoomsIncludingInactivesAsync()
        {
            IEnumerable<Room> rooms = await _roomDAO.GetAllRoomsIncludingInactivesAsync();
            return _mapper.Map<IEnumerable<RoomReadDTO>>(rooms);
        }

        public async Task<RoomReadDTO?> GetRoomByIDAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Room ID cannot be empty");

            Room? room = await _roomDAO.GetRoomByIDAsync(id);
            if (room == null) return null;

            return _mapper.Map<RoomReadDTO>(room);
        }

        public async Task<IEnumerable<RoomReadDTO>> GetRoomsByBuildingIDAsync(string buildingId)
        {
            if (string.IsNullOrWhiteSpace(buildingId))
                throw new ArgumentException("Building ID cannot be empty");

            Building? building = await _buildingDAO.GetByIDAsync(buildingId);
            if (building == null)
                throw new KeyNotFoundException($"Building with ID {buildingId} does not exist.");

            IEnumerable<Room> rooms = await _roomDAO.GetRoomsByBuildingIDAsync(buildingId);
            return _mapper.Map<IEnumerable<RoomReadDTO>>(rooms);
        }

        public async Task<string> AddRoomAsync(RoomCreateDTO dto)
        {
            Room? existingRoom = await _roomDAO.GetRoomByIDAsync(dto.RoomID);
            if (existingRoom != null)
                throw new InvalidOperationException($"Room with ID {dto.RoomID} already exists.");

            Building? building = await _buildingDAO.GetByIDAsync(dto.BuildingID);
            if (building == null)
                throw new KeyNotFoundException($"Building with ID {dto.BuildingID} does not exist.");

            Room roomEntity = _mapper.Map<Room>(dto);

            // Mặc định khi tạo mới thì chưa có người ở
            roomEntity.Currentoccupancy = 0;

            await _roomDAO.AddRoomAsync(roomEntity);

            return roomEntity.Roomid;
        }

        public async Task UpdateRoomAsync(string id, RoomUpdateDTO dto)
        {
            Room? roomEntity = await _roomDAO.GetRoomByIDAsync(id);
            if (roomEntity == null)
                throw new KeyNotFoundException($"Room with ID {id} not found.");

            if (dto.BuildingID != roomEntity.Buildingid)
            {
                Building? building = await _buildingDAO.GetByIDAsync(dto.BuildingID);
                if (building == null)
                    throw new KeyNotFoundException($"Building with ID {dto.BuildingID} does not exist.");
            }

            if (dto.Capacity < roomEntity.Currentoccupancy)
            {
                throw new InvalidOperationException($"Cannot reduce capacity to {dto.Capacity} " +
                                                    $"because there are currently {roomEntity.Currentoccupancy} students in this room.");
            }

            //if (dto.Status == "Maintenance" && roomEntity.Currentoccupancy > 0)
            //{
            //    throw new InvalidOperationException("Cannot set status to 'Maintenance' while the room is occupied. " +
            //                                        "Please move students first.");
            //}

            _mapper.Map(dto, roomEntity);
            roomEntity.Roomid = id; 

            // Lưu ý: Không map CurrentOccupancy từ DTO (vì DTO Update không có trường này, và logic này do hệ thống tự tính)

            await _roomDAO.UpdateRoomAsync(roomEntity);
        }

        public async Task DeleteRoomAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Room ID cannot be empty");

            var roomEntity = await _roomDAO.GetRoomByIDAsync(id);
            if (roomEntity == null)
                throw new KeyNotFoundException($"Room with ID {id} not found.");

            if (roomEntity.Currentoccupancy > 0)
            {
                throw new InvalidOperationException($"Cannot delete room {id} because there are {roomEntity.Currentoccupancy} students living in it.");
            }

            await _roomDAO.DeleteRoomAsync(id);
        }


        //student
        //Mới
        public async Task<IEnumerable<RoomDetailDTO>> SearchRoomInCardAsync(
            string? buildingName,
            int? roomNumber,
            int? capacity,
            decimal? minPrice,
            decimal? maxPrice,
            bool? allowCooking,   
            bool? airConditioner)  
        {
            var rooms = await _roomDAO.GetRoomsByFilterAsync(
                buildingName, roomNumber, capacity, minPrice,maxPrice, allowCooking, airConditioner);

            var result = rooms.Select(room => new RoomDetailDTO
            {
                RoomID = room.Roomid,
                RoomNumber = room.Roomnumber,
                BuildingName = room.Building.Buildingname,
                Capacity = room.Capacity,
                CurrentOccupancy = room.Currentoccupancy ?? 0,
                Price = room.Price,
                Status = room.Status ?? "Unknown",
                AllowCooking = room.Allowcooking ?? false,
                AirConditioner = room.Airconditioner ?? false
            });

            return result;
        }

         public async Task<IEnumerable<RoomGridDTO>> SearchRoomInGridAsync(
              string? buildingId,
             int? roomNumber,
             int? capacity,
             decimal? minPrice,
             decimal? maxPrice
             
              )
         {
            var rooms = await _roomDAO.GetRoomsByFilterAsync(
               buildingId, roomNumber, capacity, minPrice,maxPrice,null,null);

            var result = rooms.Select(room => new RoomGridDTO
            {
                RoomID = room.Roomid,
                RoomNumber = room.Roomnumber,
                BuildingName = room.Building.Buildingname,
                Capacity = room.Capacity,
                CurrentOccupancy = room.Currentoccupancy ?? 0,
                Status = room.Status ?? "Unknown",
               
            });
            return result;
        }


        public async Task<IEnumerable<RoomGridDTO>> GetAllActiveRoomsForGridAsync()
        {
            var rooms = await _roomDAO.GetAllRoomsWithBuildingAsync();

            var result = rooms.Select(r => new RoomGridDTO
            {
                RoomID = r.Roomid,
                RoomNumber = r.Roomnumber,

           
                BuildingName = r.Building != null ? r.Building.Buildingname : "Unknown",

                Capacity = r.Capacity,
                CurrentOccupancy = r.Currentoccupancy ?? 0,

                Status = r.Status
            });

            return result;
        }

        public async Task<IEnumerable<RoomDetailDTO>> GetAllActiveRoomsForCardAsync()
        {
            var rooms = await _roomDAO.GetAllRoomsWithBuildingAsync();

            var result = rooms.Select(room => new RoomDetailDTO
            {
                RoomID = room.Roomid,
                RoomNumber = room.Roomnumber,
                BuildingName = room.Building.Buildingname,
                Capacity = room.Capacity,
                CurrentOccupancy = room.Currentoccupancy ?? 0,
                Price = room.Price,
                Status = room.Status ?? "Unknown",
                AllowCooking = room.Allowcooking ?? false,
                AirConditioner = room.Airconditioner ?? false
            });

            return result;
        }

        public async Task<RoomDetailDTO?> GetRoomDetailByIDAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Room ID cannot be empty");

            var room = await _roomDAO.GetRoomDetailByIDAsync(id);

            if (room == null) return null;

            return new RoomDetailDTO
            {
                RoomID = room.Roomid,
                RoomNumber = room.Roomnumber,
                BuildingName = room.Building.Buildingname, 
                Capacity = room.Capacity,
                CurrentOccupancy = room.Currentoccupancy ?? 0, 
                Price = room.Price,
                Status = room.Status ?? "Unknown",
                AllowCooking = room.Allowcooking ?? false,     
                AirConditioner = room.Airconditioner ?? false  
            };
        }



        public async Task<IEnumerable<int>> GetRoomCapacitiesAsync()
        {
            return await _roomDAO.GetDistinctCapacitiesAsync();
        }

        
        public IEnumerable<RoomPriceDTO> GetPriceRanges()
        {
            return new List<RoomPriceDTO>
                {
                    new RoomPriceDTO { DisplayText = "Tất cả", MinPrice = null, MaxPrice = null },
                    new RoomPriceDTO { DisplayText = "Dưới 1 triệu", MinPrice = 0, MaxPrice = 1000000 },
                    new RoomPriceDTO { DisplayText = "1 - 2 triệu", MinPrice = 1000000, MaxPrice = 2000000 },
                    new RoomPriceDTO { DisplayText = "2 - 3 triệu", MinPrice = 2000000, MaxPrice = 3000000 },
                    new RoomPriceDTO { DisplayText = "Trên 3 triệu", MinPrice = 3000000, MaxPrice = null }
                };
        }
    }
}