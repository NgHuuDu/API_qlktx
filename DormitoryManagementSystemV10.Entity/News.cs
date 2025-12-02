using System;
using System.Collections.Generic;

namespace DormitoryManagementSystem.Entity;

public partial class News
{
    public string Newsid { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Category { get; set; }

    public DateTime? Publisheddate { get; set; }

    public int? Priority { get; set; }

    public bool? Isvisible { get; set; }

    public string? Authorid { get; set; }

    public virtual User? Author { get; set; }
}
