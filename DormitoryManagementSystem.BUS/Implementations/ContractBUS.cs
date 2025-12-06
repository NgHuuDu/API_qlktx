using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Contracts;
using DormitoryManagementSystem.DTO.SearchCriteria; 
using DormitoryManagementSystem.Entity;
using DormitoryManagementSystem.Utils;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class ContractBUS : IContractBUS
    {
        private readonly IContractDAO _contractDAO;
        private readonly IStudentDAO _studentDAO;
        private readonly IRoomDAO _roomDAO;
        private readonly IMapper _mapper;

        public ContractBUS(IContractDAO contractDAO, IStudentDAO studentDAO, IRoomDAO roomDAO, IMapper mapper)
        {
            _contractDAO = contractDAO;
            _studentDAO = studentDAO;
            _roomDAO = roomDAO;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ContractReadDTO>> GetAllContractsAsync()
        {
            var list = await _contractDAO.SearchContractsAsync(new ContractSearchCriteria());
            return _mapper.Map<IEnumerable<ContractReadDTO>>(list);
        }

        public async Task<ContractReadDTO?> GetContractByIDAsync(string id)
        {
            var contract = await _contractDAO.GetContractByIDAsync(id);
            return contract == null ? null : _mapper.Map<ContractReadDTO>(contract);
        }

        public async Task<IEnumerable<ContractReadDTO>> GetContractsByStudentIDAsync(string studentId)
        {
            var list = await _contractDAO.SearchContractsAsync(new ContractSearchCriteria { StudentID = studentId });
            return _mapper.Map<IEnumerable<ContractReadDTO>>(list);
        }

        public async Task<IEnumerable<ContractReadDTO>> GetContractsAsync(string searchTerm)
        {
            var list = await _contractDAO.SearchContractsAsync(new ContractSearchCriteria { SearchTerm = searchTerm });
            return _mapper.Map<IEnumerable<ContractReadDTO>>(list);
        }

        public async Task<IEnumerable<ContractReadDTO>> GetContractsByMultiConditionAsync(ContractFilterDTO filter)
        {
            // swap ngày nếu bị ngược
            if (filter.FromDate.HasValue && filter.ToDate.HasValue && filter.FromDate > filter.ToDate)
                (filter.FromDate, filter.ToDate) = (filter.ToDate, filter.FromDate);

            var criteria = new ContractSearchCriteria
            {
                BuildingID = filter.BuildingID,
                Status = filter.Status,
                FromDate = filter.FromDate,
                ToDate = filter.ToDate
            };

            var list = await _contractDAO.SearchContractsAsync(criteria);
            return _mapper.Map<IEnumerable<ContractReadDTO>>(list);
        }

        public async Task<ContractDetailDTO?> GetContractFullDetailAsync(string studentId)
        {
            var contract = await _contractDAO.GetContractDetailAsync(studentId);
            if (contract == null) return null;

            return new ContractDetailDTO
            {
                ContractID = contract.Contractid,
                StartTime = contract.Starttime.ToDateTime(TimeOnly.MinValue),
                EndTime = contract.Endtime.ToDateTime(TimeOnly.MinValue),
                Status = contract.Status ?? "N/A",
                StudentID = contract.Studentid,
                StudentName = contract.Student?.Fullname ?? "N/A",
                Gender = contract.Student?.Gender ?? "N/A",
                Major = contract.Student?.Major ?? "N/A",
                PhoneNumber = contract.Student?.Phonenumber ?? "N/A",
                Email = contract.Student?.Email ?? "N/A",
                CCCD = contract.Student?.Idcard ?? "N/A",
                Address = contract.Student?.Address ?? "N/A",
                RoomID = contract.Roomid,
                RoomNumber = contract.Room?.Roomnumber ?? 0,
                BuildingName = contract.Room?.Building?.Buildingname ?? "Unknown"
            };
        }


        public async Task<string> RegisterContractAsync(string studentId, ContractRegisterDTO dto)
        {
            if (dto.EndTime <= dto.StartTime)
                throw new ArgumentException("Ngày kết thúc phải sau ngày bắt đầu.");

            var student = await _studentDAO.GetStudentByIDAsync(studentId);
            if (student == null) throw new KeyNotFoundException("Sinh viên không tồn tại.");

            var activeContract = await _contractDAO.GetActiveContractByStudentIDAsync(studentId);
            if (activeContract != null)
                throw new InvalidOperationException($"Bạn đã có hợp đồng tại phòng {activeContract.Roomid}.");

            var room = await _roomDAO.GetRoomByIDAsync(dto.RoomID);
            if (room == null) throw new KeyNotFoundException("Phòng không tồn tại.");
            if (room.Status != AppConstants.RoomStatus.Active) throw new InvalidOperationException("Phòng đang bảo trì.");

            if ((room.Currentoccupancy ?? 0) >= room.Capacity)
                throw new InvalidOperationException("Phòng đã hết chỗ.");

            var newContract = new Contract
            {
                Contractid = $"CTR_{DateTime.Now:yyMMdd}_{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}",
                Studentid = studentId,
                Roomid = dto.RoomID,
                Starttime = DateOnly.FromDateTime(dto.StartTime),
                Endtime = DateOnly.FromDateTime(dto.EndTime),
                Status = AppConstants.ContractStatus.Pending,
                Createddate = DateTime.Now
            };

            await _contractDAO.AddContractAsync(newContract);

            room.Currentoccupancy = (room.Currentoccupancy ?? 0) + 1;
            await _roomDAO.UpdateRoomAsync(room);

            return newContract.Contractid;
        }

        public async Task<string> AddContractAsync(ContractCreateDTO dto, string staffUserID)
        {
            if (dto.EndTime <= dto.StartTime)
                throw new ArgumentException("Ngày kết thúc phải sau ngày bắt đầu.");

            if (await _contractDAO.GetContractByIDAsync(dto.ContractID) != null)
                throw new InvalidOperationException($"Hợp đồng {dto.ContractID} đã tồn tại.");

            var activeContract = await _contractDAO.GetActiveContractByStudentIDAsync(dto.StudentID);
            if (activeContract != null) throw new InvalidOperationException("Sinh viên đã có hợp đồng.");

            var room = await _roomDAO.GetRoomByIDAsync(dto.RoomID);
            if (room == null) throw new KeyNotFoundException($"Phòng {dto.RoomID} không tồn tại.");
            if (room.Status != AppConstants.RoomStatus.Active) throw new InvalidOperationException("Phòng bảo trì.");

            bool willOccupy = (dto.Status == AppConstants.ContractStatus.Active || dto.Status == AppConstants.ContractStatus.Pending);

            if (willOccupy)
            {
                if ((room.Currentoccupancy ?? 0) >= room.Capacity)
                    throw new InvalidOperationException("Phòng đã đầy.");
            }

            var contract = _mapper.Map<Contract>(dto);
            contract.Createddate = DateTime.Now;
            contract.Staffuserid = staffUserID;

            await _contractDAO.AddContractAsync(contract);

            if (willOccupy)
            {
                room.Currentoccupancy = (room.Currentoccupancy ?? 0) + 1;
                await _roomDAO.UpdateRoomAsync(room);
            }

            return contract.Contractid;
        }

        public async Task UpdateContractAsync(string id, ContractUpdateDTO dto)
        {
            if (dto.EndTime <= dto.StartTime)
                throw new ArgumentException("Ngày kết thúc phải sau ngày bắt đầu.");

            var contract = await _contractDAO.GetContractByIDAsync(id);
            if (contract == null) throw new KeyNotFoundException("Hợp đồng không tồn tại.");

            bool isRoomChanged = contract.Roomid != dto.RoomID;
            bool isStatusChanged = contract.Status != dto.Status;

            // ĐỔI PHÒNG
            if (isRoomChanged)
            {
                // Trả phòng cũ (Nếu đang chiếm chỗ: Active/Pending)
                bool wasOccupying = (contract.Status == AppConstants.ContractStatus.Active || contract.Status == AppConstants.ContractStatus.Pending);
                if (wasOccupying)
                {
                    var oldRoom = await _roomDAO.GetRoomByIDAsync(contract.Roomid);
                    if (oldRoom != null && (oldRoom.Currentoccupancy ?? 0) > 0)
                    {
                        oldRoom.Currentoccupancy--;
                        await _roomDAO.UpdateRoomAsync(oldRoom);
                    }
                }

                // Nhận phòng mới (Nếu trạng thái mới cần chiếm chỗ)
                bool willOccupy = (dto.Status == AppConstants.ContractStatus.Active || dto.Status == AppConstants.ContractStatus.Pending);
                if (willOccupy)
                {
                    var newRoom = await _roomDAO.GetRoomByIDAsync(dto.RoomID);
                    if (newRoom == null) throw new KeyNotFoundException($"Phòng mới {dto.RoomID} không tồn tại.");
                    if (newRoom.Status != AppConstants.RoomStatus.Active) throw new InvalidOperationException("Phòng mới đang bảo trì.");

                    if ((newRoom.Currentoccupancy ?? 0) >= newRoom.Capacity)
                        throw new InvalidOperationException("Phòng mới đã đầy.");

                    newRoom.Currentoccupancy = (newRoom.Currentoccupancy ?? 0) + 1;
                    await _roomDAO.UpdateRoomAsync(newRoom);
                }

                // Cập nhật mã phòng
                contract.Roomid = dto.RoomID;
            }

            // ĐỔI TRẠNG THÁI (CÙNG PHÒNG)
            else if (isStatusChanged)
            {
                var room = await _roomDAO.GetRoomByIDAsync(contract.Roomid);
                if (room == null) throw new KeyNotFoundException("Phòng không tồn tại.");

                bool wasOccupying = (contract.Status == AppConstants.ContractStatus.Active || contract.Status == AppConstants.ContractStatus.Pending);
                bool willOccupy = (dto.Status == AppConstants.ContractStatus.Active || dto.Status == AppConstants.ContractStatus.Pending);

                // Dùng để hủy  hoặc từ chối hợp đồng
                if (wasOccupying && !willOccupy)
                {
                    if ((room.Currentoccupancy ?? 0) > 0)
                    {
                        room.Currentoccupancy--;
                        await _roomDAO.UpdateRoomAsync(room);
                    }
                }
                // KHÔI PHỤC (Chưa giữ chỗ -> Giữ chỗ)
                else if (!wasOccupying && willOccupy)
                {
                    if ((room.Currentoccupancy ?? 0) >= room.Capacity)
                        throw new InvalidOperationException("Phòng đã đầy, không thể kích hoạt lại.");

                    room.Currentoccupancy++;
                    await _roomDAO.UpdateRoomAsync(room);
                }
               
            }

            contract.Starttime = dto.StartTime; 
            contract.Endtime = dto.EndTime;     
            contract.Status = dto.Status;

            await _contractDAO.UpdateContractAsync(contract);
        }

        public async Task DeleteContractAsync(string id)
        {
            var contract = await _contractDAO.GetContractByIDAsync(id);
            if (contract == null) throw new KeyNotFoundException("Hợp đồng không tồn tại.");

            // Trả slot trước khi xóa
            bool isOccupying = (contract.Status == AppConstants.ContractStatus.Active || contract.Status == AppConstants.ContractStatus.Pending);

            if (isOccupying)
            {
                var room = await _roomDAO.GetRoomByIDAsync(contract.Roomid);
                if (room != null && (room.Currentoccupancy ?? 0) > 0)
                {
                    room.Currentoccupancy--;
                    await _roomDAO.UpdateRoomAsync(room);
                }
            }

            await _contractDAO.DeleteContractAsync(id);
        }


    }
}