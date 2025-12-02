using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class Student
{
    public string Studentid { get; set; } = null!;

    public string Userid { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string? Major { get; set; }

    public string? Department { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Dateofbirth { get; set; }

    public string Idcard { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
