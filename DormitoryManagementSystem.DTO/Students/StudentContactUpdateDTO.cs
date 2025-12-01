using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Students
{
    public class StudentContactUpdateDTO
    {
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Định dạng số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(250, ErrorMessage = "Địa chỉ không được vượt quá 250 ký tự")]
        public string Address { get; set; } = string.Empty;

    }
}
