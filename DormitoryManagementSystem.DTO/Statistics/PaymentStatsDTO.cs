using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Statistics
{
    public class PaymentStatsDTO
    {
        public int PaidCount { get; set; }
        public decimal PaidTotalAmount { get; set; }

        public int UnpaidCount { get; set; }
        public decimal UnpaidTotalAmount { get; set; }

        public int LateCount { get; set; }
        public decimal LateTotalAmount { get; set; }
    }
}
