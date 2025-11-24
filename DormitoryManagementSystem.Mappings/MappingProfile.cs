using AutoMapper;
using DormitoryManagementSystem.Entity;
using DormitoryManagementSystem.DTO.Students;
using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.DTO.Contracts;
using DormitoryManagementSystem.DTO.Buildings;
using DormitoryManagementSystem.DTO.Payments;
using DormitoryManagementSystem.DTO.Violations;
using DormitoryManagementSystem.DTO.Admins;
using DormitoryManagementSystem.DTO.Users;
using DormitoryManagementSystem.DTO.News;

namespace DormitoryManagementSystem.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ==========================================
            // 1. STUDENT MAPPING
            // ==========================================
            CreateMap<Student, StudentReadDTO>();
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<StudentUpdateDTO, Student>()
                .ForMember(dest => dest.Studentid, opt => opt.Ignore()); // Không update ID


            // ==========================================
            // 2. ROOM MAPPING
            // ==========================================
            CreateMap<Room, RoomReadDTO>();
                // Bonus: Nếu DAO có Include(r => r.Building) thì map tên tòa nhà
                //.ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Building != null ? src.Building.BuildingName : string.Empty));

            CreateMap<RoomCreateDTO, Room>();
            CreateMap<RoomUpdateDTO, Room>()
                .ForMember(dest => dest.Roomid, opt => opt.Ignore());


            // ==========================================
            // 3. CONTRACT MAPPING
            // ==========================================
            CreateMap<Contract, ContractReadDTO>()
                 // Bonus: Map tên sinh viên và số phòng cho tiện hiển thị
                 .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student != null ? src.Student.Fullname : string.Empty))
                 .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room != null ? src.Room.Roomnumber.ToString() : string.Empty));

            CreateMap<ContractCreateDTO, Contract>();
            CreateMap<ContractUpdateDTO, Contract>()
                .ForMember(dest => dest.Contractid, opt => opt.Ignore())
                .ForMember(dest => dest.Studentid, opt => opt.Ignore()); // Thường không đổi sinh viên trong hợp đồng


            // ==========================================
            // 4. BUILDING MAPPING
            // ==========================================
            CreateMap<Building, BuildingReadDTO>();
            CreateMap<BuildingCreateDTO, Building>();
            CreateMap<BuildingUpdateDTO, Building>()
                .ForMember(dest => dest.Buildingid, opt => opt.Ignore());


            // ==========================================
            // 5. PAYMENT MAPPING
            // ==========================================
            CreateMap<Payment, PaymentReadDTO>();
            CreateMap<PaymentCreateDTO, Payment>();
            CreateMap<PaymentUpdateDTO, Payment>()
                .ForMember(dest => dest.Paymentid, opt => opt.Ignore())
                .ForMember(dest => dest.Contractid, opt => opt.Ignore()) // Không đổi hợp đồng của hóa đơn
                .ForMember(dest => dest.Billmonth, opt => opt.Ignore())  // Không đổi tháng của hóa đơn
                .ForMember(dest => dest.Paymentamount, opt => opt.Ignore()); // Không đổi số tiền phải đóng (chỉ update PaidAmount)


            // ==========================================
            // 6. VIOLATION MAPPING
            // ==========================================
            CreateMap<Violation, ViolationReadDTO>()
                 .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student != null ? src.Student.Fullname : "Unknown"));

            CreateMap<ViolationCreateDTO, Violation>();
            CreateMap<ViolationUpdateDTO, Violation>()
                .ForMember(dest => dest.Violationid, opt => opt.Ignore())
                .ForMember(dest => dest.Roomid, opt => opt.Ignore()); // Lỗi xảy ra ở phòng nào thì cố định phòng đó


            // ==========================================
            // 7. ADMIN MAPPING
            // ==========================================
            CreateMap<Admin, AdminReadDTO>();
            CreateMap<AdminCreateDTO, Admin>();
            CreateMap<AdminUpdateDTO, Admin>()
                .ForMember(dest => dest.Adminid, opt => opt.Ignore())
                .ForMember(dest => dest.Userid, opt => opt.Ignore()); // Không đổi UserID liên kết


            // ==========================================
            // 8. USER MAPPING
            // ==========================================
            CreateMap<User, UserReadDTO>(); // UserReadDTO không có password nên an toàn

            CreateMap<UserCreateDTO, User>()
                // Lưu ý: Password trong CreateDTO là Raw, cần Hash ở BUS. 
                // Ở đây cứ map tạm, BUS sẽ ghi đè lại sau.
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<UserUpdateDTO, User>()
                .ForMember(dest => dest.Userid, opt => opt.Ignore())
                .ForMember(dest => dest.Username, opt => opt.Ignore()) // Username thường không cho đổi
                                                                       // Nếu Password trong DTO null (không muốn đổi pass) thì giữ nguyên pass cũ
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            // ==========================================
            // 9. NEWS MAPPING
            // ==========================================
            CreateMap<News, NewsReadDTO>();
                // Map tên tác giả từ bảng User (hoặc bảng Admin nếu bạn join sang Admin)
                //.ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : "Unknown"));

            CreateMap<NewsCreateDTO, News>();
            CreateMap<NewsUpdateDTO, News>()
                .ForMember(dest => dest.Newsid, opt => opt.Ignore());
        }
    }
}