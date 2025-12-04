using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.SearchCriteria; // StudentSearchCriteria
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

        // ======================== SEARCH & GET ========================

        public async Task<IEnumerable<StudentReadDTO>> SearchStudentsAsync(string? keyword, string? major, string? gender, bool? isActive)
        {
            // Đóng gói tham số vào Criteria
            var criteria = new StudentSearchCriteria
            {
                Keyword = keyword,
                Major = major,
                Gender = gender,
                IsActive = isActive // Nếu null thì DAO sẽ mặc định lấy Active=true
            };

            var students = await _studentDAO.SearchStudentsAsync(criteria);
            return _mapper.Map<IEnumerable<StudentReadDTO>>(students);
        }

        public async Task<StudentReadDTO?> GetStudentByIDAsync(string id)
        {
            var student = await _studentDAO.GetStudentByIDAsync(id);
            return student == null ? null : _mapper.Map<StudentReadDTO>(student);
        }

        // ======================== TRANSACTIONS ========================

        public async Task<string> AddStudentAsync(StudentCreateDTO dto)
        {
            // Validate Logic: Check trùng ID, CCCD, Email
            if (await _studentDAO.GetStudentByIDAsync(dto.StudentID) != null)
                throw new InvalidOperationException($"Mã sinh viên {dto.StudentID} đã tồn tại.");

            if (await _studentDAO.GetStudentByCCCDAsync(dto.CCCD) != null)
                throw new InvalidOperationException($"CCCD {dto.CCCD} đã tồn tại trong hệ thống.");

            if (!string.IsNullOrEmpty(dto.Email) && await _studentDAO.GetStudentByEmailAsync(dto.Email) != null)
                throw new InvalidOperationException($"Email {dto.Email} đã được sử dụng.");

            // Kiểm tra UserID liên kết (nếu cần thiết phải có User trước)
            // Tùy logic DB, nếu Student.UserID là FK bắt buộc
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

            // Check trùng CCCD nếu có thay đổi
            if (dto.CCCD != student.Idcard && await _studentDAO.GetStudentByCCCDAsync(dto.CCCD) != null)
                throw new InvalidOperationException($"CCCD {dto.CCCD} đã được sử dụng bởi người khác.");

            // Check trùng Email nếu có thay đổi
            if (!string.IsNullOrEmpty(dto.Email) && dto.Email != student.Email && await _studentDAO.GetStudentByEmailAsync(dto.Email) != null)
                throw new InvalidOperationException($"Email {dto.Email} đã được sử dụng.");

            _mapper.Map(dto, student);
            student.Studentid = id; // Đảm bảo ID không bị đổi

            await _studentDAO.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(string id)
        {
            var student = await _studentDAO.GetStudentByIDAsync(id)
                          ?? throw new KeyNotFoundException($"Sinh viên {id} không tồn tại.");

            // Logic nghiệp vụ: Không được xóa nếu đang ở KTX
            var activeContract = await _contractDAO.GetActiveContractByStudentIDAsync(id);
            if (activeContract != null)
                throw new InvalidOperationException($"Sinh viên đang có hợp đồng tại phòng {activeContract.Roomid}. Vui lòng thanh lý hợp đồng trước.");

            // Soft Delete: Ẩn User -> Ẩn Student (do query DAO lọc theo User.IsActive)
            await _userDAO.DeleteUserAsync(student.Userid);
        }

        public async Task UpdateContactInfoAsync(string studentId, StudentContactUpdateDTO dto)
        {
            var student = await _studentDAO.GetStudentByIDAsync(studentId)
                          ?? throw new KeyNotFoundException($"Sinh viên {studentId} không tìm thấy.");

            // Check email trùng (trừ chính mình)
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

        // ======================== STUDENT PROFILE LOGIC ========================

        public async Task<StudentProfileDTO?> GetStudentProfileAsync(string studentId)
        {
            var student = await _studentDAO.GetStudentByIDAsync(studentId);
            if (student == null) return null;

            // 1. Map thông tin cơ bản
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

            // 2. Lấy thông tin Hợp đồng & Phòng ở
            var activeContract = await _contractDAO.GetContractDetailAsync(studentId);

            if (activeContract != null)
            {
                profile.RoomName = activeContract.Room?.Roomnumber.ToString() ?? "Unknown";
                profile.BuildingName = activeContract.Room?.Building?.Buildingname ?? "Unknown";
                profile.ContractStatus = activeContract.Status ?? "N/A";

                // 3. Tính toán công nợ (Sử dụng hàm SearchPayment của DAO)
                // Lấy tất cả hóa đơn của hợp đồng này
                var payments = await _paymentDAO.SearchPaymentsAsync(new PaymentSearchCriteria
                {
                    ContractID = activeContract.Contractid
                });

                // Lọc hóa đơn chưa trả hoặc trễ
                var debtPayments = payments.Where(p => p.Paymentstatus == AppConstants.PaymentStatus.Unpaid
                                                    || p.Paymentstatus == AppConstants.PaymentStatus.Late).ToList();

                profile.TotalDebt = debtPayments.Sum(p => p.Paymentamount - p.Paidamount);
                profile.AmountToPay = profile.TotalDebt; // Logic hiển thị FE
                profile.IsDebt = profile.TotalDebt > 0;

                // Set trạng thái hiển thị
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