using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public DateTime? JoiningDate { get; set; }

    public DateTime? BirthDate { get; set; }

    public byte? Appraisal { get; set; }

    public string? Address { get; set; }

    public string? TelNumper1 { get; set; }

    public string? TelNumper2 { get; set; }

    public int? Degree { get; set; }

    public int? AbsenceDays { get; set; }

    public int? AttendanceDays { get; set; }

    public string? Email { get; set; }

    public int? TotDegree { get; set; }

    public byte? Age { get; set; }

    public string? Picture { get; set; }

    public bool? IsActive { get; set; }

    public int? TransportId { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Transport? Transport { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
