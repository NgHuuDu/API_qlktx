using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.News
{
    public class NewsSummaryDTO
    {
        public string NewsID { get; set; } = string.Empty; // Cần ID để khi bấm vào biết là xem tin nào
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
    }
}
