using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class Violation
{
    public string Violationid { get; set; } = null!;

    public string? Studentid { get; set; }

    public string Roomid { get; set; } = null!;

    public string? Reportedbyuserid { get; set; }

    public string Violationtype { get; set; } = null!;

    public DateTime? Violationdate { get; set; }

    public decimal? Penaltyfee { get; set; }

    public string? Status { get; set; }

    public virtual User? Reportedbyuser { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
