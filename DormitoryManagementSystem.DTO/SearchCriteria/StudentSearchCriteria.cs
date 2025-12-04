using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.SearchCriteria
{
    public class StudentSearchCriteria
    {
        public string? Keyword { get; set; } // Tìm Tên, MSSV, SĐT, CCCD
        public string? Major { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; } // True: Đang hoạt động, False: Đã xóa/ẩn
        public string? RoomID { get; set; } // Tìm sinh viên trong phòng cụ thể
    }
}
