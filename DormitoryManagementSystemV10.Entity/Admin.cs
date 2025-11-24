using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class Admin
{
    public string Adminid { get; set; } = null!;

    public string Userid { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Idcard { get; set; } = null!;

    public string? Gender { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public virtual User User { get; set; } = null!;
}
