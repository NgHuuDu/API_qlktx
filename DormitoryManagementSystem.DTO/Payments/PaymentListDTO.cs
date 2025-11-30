using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Payments
{
    public class PaymentListDTO
    {
        public string PaymentID { get; set; } = string.Empty;

        public int BillMonth { get; set; }

        public decimal PaymentAmount { get; set; }

        public string PaymentStatus { get; set; } = string.Empty;


        public DateTime? PaymentDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
