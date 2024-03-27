using System;
using System.Collections.Generic;

namespace SchoolSystem.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? TotalAtendances { get; set; }

    public virtual ICollection<Department> Depts { get; set; } = new List<Department>();

    public virtual ICollection<EventSpeaker> EventSpeakers { get; set; } = new List<EventSpeaker>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
