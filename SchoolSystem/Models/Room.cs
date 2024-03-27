using System;
using System.Collections.Generic;

namespace SchoolSystem.Models;

public partial class Room
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public byte? Rate { get; set; }

    public int? Area { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Department> Depts { get; set; } = new List<Department>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
