using System;
using System.Collections.Generic;

namespace SchoolSystem.Models;

public partial class Transport
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? VicelName { get; set; }

    public byte? Rate { get; set; }

    public long? DistanceInMonth { get; set; }

    public long? DistanceInYear { get; set; }

    public DateTime? ArriveTime { get; set; }

    public DateTime? LeaveTime { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
