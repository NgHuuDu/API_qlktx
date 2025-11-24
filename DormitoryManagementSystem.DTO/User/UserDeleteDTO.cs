using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Users
{
    public class UserDeleteDTO
    {
        [Required(ErrorMessage = "User ID is required")]
        public string UserID { get; set; } = string.Empty;
    }
}