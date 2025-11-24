using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class Contract
{
    public string Contractid { get; set; } = null!;

    public string Studentid { get; set; } = null!;

    public string Roomid { get; set; } = null!;

    public string? Staffuserid { get; set; }

    public DateOnly Starttime { get; set; }

    public DateOnly Endtime { get; set; }

    public string? Status { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room Room { get; set; } = null!;

    public virtual User? Staffuser { get; set; }

    public virtual Student Student { get; set; } = null!;
}
