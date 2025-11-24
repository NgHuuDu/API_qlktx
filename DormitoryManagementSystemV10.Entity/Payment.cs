using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class Payment
{
    public string Paymentid { get; set; } = null!;

    public string Contractid { get; set; } = null!;

    public int Billmonth { get; set; }

    public decimal Paymentamount { get; set; }

    public decimal Paidamount { get; set; }

    public DateTime? Paymentdate { get; set; }

    public string? Paymentmethod { get; set; }

    public string? Paymentstatus { get; set; }

    public string? Description { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
