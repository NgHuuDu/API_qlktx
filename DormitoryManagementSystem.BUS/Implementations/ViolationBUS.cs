using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Violations;
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class ViolationBUS : IViolationBUS
    {
        private readonly IViolationDAO _violationDAO;
        private readonly IRoomDAO _roomDAO;
        private readonly IStudentDAO _studentDAO;
        private readonly IUserDAO _userDAO;    
        private readonly IMapper _mapper;

        public ViolationBUS(
            IViolationDAO violationDAO,
            IRoomDAO roomDAO,
            IStudentDAO studentDAO,
            IUserDAO userDAO,
            IMapper mapper)
        {
            _violationDAO = violationDAO;
            _roomDAO = roomDAO;
            _studentDAO = studentDAO;
            _userDAO = userDAO;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViolationReadDTO>> GetAllViolationsAsync()
        {
            IEnumerable<Violation> violations = await _violationDAO.GetAllViolationsAsync();
            return _mapper.Map<IEnumerable<ViolationReadDTO>>(violations);
        }

        public async Task<ViolationReadDTO?> GetViolationByIDAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Violation ID cannot be empty");

            Violation? violation = await _violationDAO.GetViolationByIdAsync(id);
            if (violation == null) return null;

            return _mapper.Map<ViolationReadDTO>(violation);
        }

        public async Task<IEnumerable<ViolationReadDTO>> GetViolationsByStudentIDAsync(string studentId)
        {
            var violations = await _violationDAO.GetViolationsByStudentIDAsync(studentId);

             return _mapper.Map<IEnumerable<ViolationReadDTO>>(violations);

        }

        public async Task<IEnumerable<ViolationReadDTO>> GetViolationsByRoomIDAsync(string roomId)
        {
            if (string.IsNullOrWhiteSpace(roomId))
                throw new ArgumentException("Room ID cannot be empty");

            Room? room = await _roomDAO.GetRoomByIDAsync(roomId);
            if (room == null)
                throw new KeyNotFoundException($"Room with ID {roomId} not found.");

            IEnumerable<Violation> violations = await _violationDAO.GetViolationsByRoomIDAsync(roomId);
            return _mapper.Map<IEnumerable<ViolationReadDTO>>(violations);
        }

        public async Task<IEnumerable<ViolationReadDTO>> GetViolationsByStatusAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status cannot be empty");

            IEnumerable<Violation> violations = await _violationDAO.GetViolationsByStatusAsync(status);
            return _mapper.Map<IEnumerable<ViolationReadDTO>>(violations);
        }

        public async Task<string> AddViolationAsync(ViolationCreateDTO dto)
        {
            Violation? existing = await _violationDAO.GetViolationByIdAsync(dto.ViolationID);
            if (existing != null)
                throw new InvalidOperationException($"Violation with ID {dto.ViolationID} already exists.");

            Room? room = await _roomDAO.GetRoomByIDAsync(dto.RoomID);
            if (room == null)
                throw new KeyNotFoundException($"Room with ID {dto.RoomID} not found.");

            if (!string.IsNullOrEmpty(dto.StudentID))
            {
                Student? student = await _studentDAO.GetStudentByIDAsync(dto.StudentID);
                if (student == null)
                    throw new KeyNotFoundException($"Student with ID {dto.StudentID} not found.");
            }

            if (!string.IsNullOrEmpty(dto.ReportedByUserID))
            {
                User? user = await _userDAO.GetUserByIDAsync(dto.ReportedByUserID);
                if (user == null)
                    throw new KeyNotFoundException($"User (Reporter) with ID {dto.ReportedByUserID} not found.");

                if (!user.IsActive)
                    throw new InvalidOperationException($"Reporter account {dto.ReportedByUserID} is inactive.");
            }

            Violation violationEntity = _mapper.Map<Violation>(dto);

            if (violationEntity.Violationdate == null)
                violationEntity.Violationdate = DateTime.Now;

            await _violationDAO.AddNewViolationAsync(violationEntity);

            return violationEntity.Violationid;
        }

        public async Task UpdateViolationAsync(string id, ViolationUpdateDTO dto)
        {
            Violation? violationEntity = await _violationDAO.GetViolationByIdAsync(id);
            if (violationEntity == null)
                throw new KeyNotFoundException($"Violation with ID {id} not found.");

            if (!string.IsNullOrEmpty(dto.StudentID) && dto.StudentID != violationEntity.Studentid)
            {
                Student? student = await _studentDAO.GetStudentByIDAsync(dto.StudentID);
                if (student == null)
                    throw new KeyNotFoundException($"Student with ID {dto.StudentID} not found.");
            }

            // If Status is Paid, verify Penalty logic (Optional)
            if (dto.Status == "Paid" && dto.PenaltyFee > 0 && dto.PenaltyFee < violationEntity.Penaltyfee)
            {
                // Example logic: You might want to warn if they pay less than the original fee, 
                // but usually update overrides everything, so we assume Admin knows what they are doing.
            }

            _mapper.Map(dto, violationEntity);
            violationEntity.Violationid = id;

            await _violationDAO.UpdateViolationAsync(violationEntity);
        }

        public async Task DeleteViolationAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Violation ID cannot be empty");

            Violation? violation = await _violationDAO.GetViolationByIdAsync(id);
            if (violation == null)
                throw new KeyNotFoundException($"Violation with ID {id} not found.");

            // Perform Hard Delete (As decided for Violations table)
            await _violationDAO.DeleteViolationAsync(id);
        }






        //Student
        //Mới trong bản student 
        // Lấy danh sách vi phạm của học sinh đó

        public async Task<IEnumerable<ViolationGridDTO>> GetViolationsWithFilterAsync(string? status, string? studentId)
        {
            var violations = await _violationDAO.GetViolationsWithFilterAsync(status, studentId);

            var result = violations.Select(v => new ViolationGridDTO
            {
                ViolationID = v.Violationid,


                RoomNumber = v.Room.Roomnumber,

                Status = v.Status ?? "Unknown",

                StartTime = v.Violationdate ?? DateTime.MinValue,

                ViolationType = v.Violationtype ?? "General",

                PenaltyFee = v.Penaltyfee ?? 0
            });

            return result;
        }



        //Admin
        // Mới trong bản admin
        // Lấy danh sách vi phạm với các bộ lọc nâng cao

        public async Task<IEnumerable<ViolationAdminDTO>> GetViolationsForAdminAsync(
    string? search, string? status, string? roomId)
        {
            var violations = await _violationDAO.GetViolationsForAdminAsync(search, status, roomId);

            return violations.Select(v => new ViolationAdminDTO
            {
                ViolationID = v.Violationid,
                StudentID = v.Studentid,
                StudentName = v.Student?.Fullname ?? "Unknown",
                RoomID = v.Roomid,
                ViolationType = v.Violationtype,
                ViolationDate = v.Violationdate ?? DateTime.Now,
                PenaltyFee = v.Penaltyfee ?? 0,
                Status = v.Status
            });
        }


    }
}

