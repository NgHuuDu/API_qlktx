using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class User
{
    public string Userid { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public DateTime? Createdat { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual Student? Student { get; set; }

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
