using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Students
{
    public class StudentDeleteDTO
    {
        [Required(ErrorMessage = "Student id required")]
        [StringLength(10, ErrorMessage = "")]
        public string StudentID { get; set; } = string.Empty;
    }
}
