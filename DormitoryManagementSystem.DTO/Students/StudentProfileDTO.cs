using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Students
{
    public class StudentProfileDTO
    {
        public string StudentID { get; set; } = string.Empty; // MSSV
        public string FullName { get; set; } = string.Empty;  // Họ tên
        public string Major { get; set; } = string.Empty;     // Ngành học (CNTT...)
        public string DateOfBirth { get; set; } = string.Empty; // Ngày sinh (dạng dd/MM/yyyy)
        public string PhoneNumber { get; set; } = string.Empty; // SĐT
        public string Gender { get; set; } = string.Empty;    // Giới tính
        public string Email { get; set; } = string.Empty;     // Email
        public string CCCD { get; set; } = string.Empty;      // CCCD
        public string Address { get; set; } = string.Empty;   // Địa chỉ

        // --- 2. Thông tin Phòng ở (Lấy từ Contract) ---
        public string RoomName { get; set; } = "Chưa có";     // VD: Phòng 101
        public string BuildingName { get; set; } = "---";     // VD: Khu A
        public string ContractStatus { get; set; } = "None";  // Trạng thái hợp đồng (Active/Expired)

        // --- 3. Thông tin Thanh toán (Logic bạn yêu cầu) ---
        // Dòng "Tiền cần thanh toán" trong ảnh
        public decimal AmountToPay { get; set; } = 0;

        // Dòng "Tiền còn nợ" trong ảnh
        public decimal TotalDebt { get; set; } = 0;

        // Trạng thái hiển thị (Để FE hiện chữ "Đã thanh toán" hoặc "Chưa thanh toán")
        public string PaymentStatusDisplay { get; set; } = "Không có dữ liệu";

        // Cờ trạng thái (Để FE tô màu: True = Đỏ/Nợ, False = Xanh/Sạch)
        public bool IsDebt { get; set; } = false;
    }
}
