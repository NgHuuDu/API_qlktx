using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Rooms
{
    public class RoomDeleteDTO
    {
        [Required(ErrorMessage = "Room ID is required")]
        [StringLength(10, ErrorMessage = "Room ID cannot exceed 10 chars")]
        public string RoomID { get; set; } = string.Empty;
    }
}