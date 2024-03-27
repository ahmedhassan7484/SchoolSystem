using System;
using System.Collections.Generic;

namespace SchoolSystem.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string Barcode { get; set; } = null!;

    public string? Name { get; set; }

    public int EquNumper { get; set; }

    public int? RoomId { get; set; }

    public virtual Room? Room { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
