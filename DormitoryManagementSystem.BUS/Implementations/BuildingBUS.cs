using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Buildings;
using DormitoryManagementSystem.DTO.SearchCriteria; 
using DormitoryManagementSystem.Utils;          
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class BuildingBUS : IBuildingBUS
    {
        private readonly IBuildingDAO _dao;
        private readonly IRoomDAO _daoRoom;
        private readonly IMapper _mapper;

        public BuildingBUS(IBuildingDAO dao, IRoomDAO daoRoom, IMapper mapper)
        {
            _dao = dao;
            _daoRoom = daoRoom;
            _mapper = mapper;
        }


        public async Task<IEnumerable<BuildingReadDTO>> GetAllBuildingAsync() =>
            _mapper.Map<IEnumerable<BuildingReadDTO>>(await _dao.GetAllBuildingAsync());

        public async Task<IEnumerable<BuildingReadDTO>> GetAllBuildingIncludingInactivesAsync() =>
            _mapper.Map<IEnumerable<BuildingReadDTO>>(await _dao.GetAllBuildingIncludingInactivesAsync());

        public async Task<BuildingReadDTO?> GetByIDAsync(string id)
        {
            var building = await _dao.GetByIDAsync(id);
            return building == null ? null : _mapper.Map<BuildingReadDTO>(building);
        }

        public async Task<IEnumerable<BuildingLookupDTO>> GetBuildingLookupAsync()
        {
            var buildings = await _dao.GetAllBuildingAsync();
            return buildings.Select(b => new BuildingLookupDTO
            {
                BuildingID = b.Buildingid,
                BuildingName = b.Buildingname
            });
        }


        public async Task<string> AddBuildingAsync(BuildingCreateDTO dto)
        {
            if (await _dao.GetByIDAsync(dto.BuildingID) != null)
                throw new InvalidOperationException($"Tòa nhà {dto.BuildingID} đã tồn tại.");

            var building = _mapper.Map<Building>(dto);
            await _dao.AddBuildingAsync(building);

            return building.Buildingid;
        }

        public async Task UpdateBuildingAsync(string id, BuildingUpdateDTO dto)
        {
            var building = await _dao.GetByIDAsync(id)
                           ?? throw new KeyNotFoundException($"Tòa nhà {id} không tồn tại.");

            //  Không đổi giới tính khi đang có người ở
            if (building.Currentoccupancy > 0 && building.Gendertype != dto.Gender)
                throw new InvalidOperationException($"Không thể đổi loại giới tính khi đang có {building.Currentoccupancy} sinh viên ở.");

            //  Số phòng mới không được nhỏ hơn số phòng thực tế đang có trong DB
            var actualRooms = await _daoRoom.SearchRoomsAsync(new RoomSearchCriteria { BuildingID = id });

            if (dto.NumberOfRooms < actualRooms.Count())
                throw new InvalidOperationException($"Số phòng mới ({dto.NumberOfRooms}) không thể nhỏ hơn số lượng phòng thực tế ({actualRooms.Count()}).");

            _mapper.Map(dto, building);
            building.Buildingid = id;

            await _dao.UpdateBuildingAsync(building);
        }

        public async Task DeleteBuildingAsync(string id)
        {

            var building = await _dao.GetByIDAsync(id);
            if (building == null) throw new KeyNotFoundException($"Tòa nhà {id} không tồn tại.");

            if (building.Currentoccupancy > 0)
                throw new InvalidOperationException($"Không thể xóa tòa nhà {id} vì đang có {building.Currentoccupancy} sinh viên cư trú.");

            var rooms = await _daoRoom.SearchRoomsAsync(new RoomSearchCriteria { BuildingID = id });

          
            foreach (var room in rooms)
            {
                await _daoRoom.DeleteRoomAsync(room.Roomid);
            }

            await _dao.DeleteBuildingAsync(id);
        }
    }
}