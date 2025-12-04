using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.SearchCriteria; 
using DormitoryManagementSystem.DTO.Students;
using DormitoryManagementSystem.Entity;
using DormitoryManagementSystem.Utils;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class StudentBUS : IStudentBUS
    {
        private readonly IStudentDAO _studentDAO;
        private readonly IContractDAO _contractDAO;
        private readonly IPaymentDAO _paymentDAO;
        private readonly IUserDAO _userDAO;
        private readonly IMapper _mapper;

        public StudentBUS(IStudentDAO studentDAO, IContractDAO contractDAO, IPaymentDAO paymentDAO, IUserDAO userDAO, IMapper mapper)
        {
            _studentDAO = studentDAO;
            _contractDAO = contractDAO;
            _paymentDAO = paymentDAO;
            _userDAO = userDAO;
            _mapper = mapper;
        }


        public async Task<IEnumerable<StudentReadDTO>> SearchStudentsAsync(string? keyword, string? major, string? gender, bool? isActive)
        {
            var criteria = new StudentSearchCriteria
            {
                Keyword = keyword,
                Major = major,
                Gender = gender,
                IsActive = isActive
            };

            var students = await _studentDAO.SearchStudentsAsync(criteria);
            return _mapper.Map<IEnumerable<StudentReadDTO>>(students);
        }

        public async Task<StudentReadDTO?> GetStudentByIDAsync(string id)
        {
            var student = await _studentDAO.GetStudentByIDAsync(id);
            return student == null ? null : _mapper.Map<StudentReadDTO>(student);
        }


        public async Task<string> AddStudentAsync(StudentCreateDTO dto)
        {
            if (await _studentDAO.GetStudentByIDAsync(dto.StudentID) != null)
                throw new InvalidOperationException($"Mã sinh viên {dto.StudentID} đã tồn tại.");

            if (await _studentDAO.GetStudentByCCCDAsync(dto.CCCD) != null)
                throw new InvalidOperationException($"CCCD {dto.CCCD} đã tồn tại trong hệ thống.");

            if (!string.IsNullOrEmpty(dto.Email) && await _studentDAO.GetStudentByEmailAsync(dto.Email) != null)
                throw new InvalidOperationException($"Email {dto.Email} đã được sử dụng.");

            if (await _userDAO.GetUserByIDAsync(dto.UserID) == null)
                throw new KeyNotFoundException($"Tài khoản User {dto.UserID} không tồn tại. Vui lòng tạo User trước.");

            var student = _mapper.Map<Student>(dto);
            await _studentDAO.AddStudentAsync(student);

            return student.Studentid;
        }

        public async Task UpdateStudentAsync(string id, StudentUpdateDTO dto)
        {
            var student = await _studentDAO.GetStudentByIDAsync(id)
                          ?? throw new KeyNotFoundException($"Sinh viên {id} không tồn tại.");

            if (dto.CCCD != student.Idcard && await _studentDAO.GetStudentByCCCDAsync(dto.CCCD) != null)
                throw new InvalidOperationException($"CCCD {dto.CCCD} đã được sử dụng bởi người khác.");

            if (!string.IsNullOrEmpty(dto.Email) && dto.Email != student.Email && await _studentDAO.GetStudentByEmailAsync(dto.Email) != null)
                throw new InvalidOperationException($"Email {dto.Email} đã được sử dụng.");

            _mapper.Map(dto, student);
            student.Studentid = id; 

            await _studentDAO.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(string id)
        {
            var student = await _studentDAO.GetStudentByIDAsync(id)
                          ?? throw new KeyNotFoundException($"Sinh viên {id} không tồn tại.");

            var activeContract = await _contractDAO.GetActiveContractByStudentIDAsync(id);
            if (activeContract != null)
                throw new InvalidOperationException($"Sinh viên đang có hợp đồng tại phòng {activeContract.Roomid}. Vui lòng thanh lý hợp đồng trước.");

            await _userDAO.DeleteUserAsync(student.Userid);
        }

        public async Task UpdateContactInfoAsync(string studentId, StudentContactUpdateDTO dto)
        {
            var student = await _studentDAO.GetStudentByIDAsync(studentId)
                          ?? throw new KeyNotFoundException($"Sinh viên {studentId} không tìm thấy.");

            if (!string.Equals(student.Email, dto.Email, StringComparison.OrdinalIgnoreCase))
            {
                if (await _studentDAO.GetStudentByEmailAsync(dto.Email) != null)
                    throw new InvalidOperationException($"Email '{dto.Email}' đã được sử dụng.");
            }

            student.Phonenumber = dto.PhoneNumber;
            student.Email = dto.Email;
            student.Address = dto.Address;

            await _studentDAO.UpdateStudentAsync(student);
        }


        public async Task<StudentProfileDTO?> GetStudentProfileAsync(string studentId)
        {
            var student = await _studentDAO.GetStudentByIDAsync(studentId);
            if (student == null) return null;

          // thông tin cơ bản
            var profile = new StudentProfileDTO
            {
                StudentID = student.Studentid,
                FullName = student.Fullname,
                Major = student.Major ?? "N/A",
                DateOfBirth = student.Dateofbirth?.ToString("dd/MM/yyyy") ?? "N/A",
                PhoneNumber = student.Phonenumber,
                Gender = student.Gender ?? "N/A",
                Email = student.Email ?? "N/A",
                CCCD = student.Idcard,
                Address = student.Address ?? "N/A"
            };

            //  Hợp đồng & Phòng ở
            var activeContract = await _contractDAO.GetContractDetailAsync(studentId);

            if (activeContract != null)
            {
                profile.RoomName = activeContract.Room?.Roomnumber.ToString() ?? "Unknown";
                profile.BuildingName = activeContract.Room?.Building?.Buildingname ?? "Unknown";
                profile.ContractStatus = activeContract.Status ?? "N/A";

                // Tính toán công nợ 
                // Lấy tất cả hóa đơn của hợp đồng này
                var payments = await _paymentDAO.SearchPaymentsAsync(new PaymentSearchCriteria
                {
                    ContractID = activeContract.Contractid
                });

                // Lọc hóa đơn chưa trả hoặc trễ
                var debtPayments = payments.Where(p => p.Paymentstatus == AppConstants.PaymentStatus.Unpaid
                                                    || p.Paymentstatus == AppConstants.PaymentStatus.Late).ToList();

                profile.TotalDebt = debtPayments.Sum(p => p.Paymentamount - p.Paidamount);
                profile.AmountToPay = profile.TotalDebt;
                profile.IsDebt = profile.TotalDebt > 0;

                // Set trạng thái 
                if (profile.IsDebt)
                    profile.PaymentStatusDisplay = "Chưa thanh toán";
                else
                    profile.PaymentStatusDisplay = payments.Any() ? "Đã thanh toán" : "Chưa có hóa đơn";
            }
            else
            {
                profile.RoomName = "Chưa đăng ký";
                profile.PaymentStatusDisplay = "Chưa đăng ký phòng";
                profile.IsDebt = false;
            }

            return profile;
        }
    }
}