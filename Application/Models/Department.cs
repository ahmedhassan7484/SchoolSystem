using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
