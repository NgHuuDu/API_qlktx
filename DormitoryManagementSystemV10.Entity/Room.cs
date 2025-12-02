using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class Room
{
    public string Roomid { get; set; } = null!;

    public int Roomnumber { get; set; }

    public string Buildingid { get; set; } = null!;

    public int Capacity { get; set; }

    public int? Currentoccupancy { get; set; }

    public string? Status { get; set; }

    public bool? Allowcooking { get; set; }

    public bool? Airconditioner { get; set; }

    public decimal Price { get; set; }

    public virtual Building Building { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
