using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Users
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string UserID { get; set; }
    }
}
