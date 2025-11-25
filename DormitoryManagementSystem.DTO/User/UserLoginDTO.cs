using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Users
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        //Thêm role để phân biệt user đăng nhập là admin hay student
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}