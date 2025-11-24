using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Users
{
    public class UserUpdateDTO
    {
        // Nếu user muốn đổi mật khẩu thì nhập vào đây, không thì để null
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string? Password { get; set; }

        // Chỉ Admin mới được quyền đổi Role của người khác
        [RegularExpression("^(Admin|Student)$", ErrorMessage = "Role must be 'Admin' or 'Student'")]
        public string? Role { get; set; }

        public bool? IsActive { get; set; }
    }
}