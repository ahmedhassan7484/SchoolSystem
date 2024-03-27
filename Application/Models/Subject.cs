using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public byte? Units { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
