using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class Building
{
    public string Buildingid { get; set; } = null!;

    public string Buildingname { get; set; } = null!;

    public int Numberofroom { get; set; }

    public int? Currentoccupancy { get; set; }

    public string? Gendertype { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
