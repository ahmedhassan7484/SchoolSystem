using System;
using System.Collections.Generic;

namespace SchoolSystem.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public byte? Appraisal { get; set; }

    public int? Salary { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? Gender { get; set; }

    public byte? Experience { get; set; }

    public byte? NotesPeriod { get; set; }

    public string? TelNumper1 { get; set; }

    public string? TelNumper2 { get; set; }

    public bool? IsActive { get; set; }

    public string? Email { get; set; }

    public string? Picture { get; set; }

    public int? Bonus { get; set; }

    public int? TransportId { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Transport? Transport { get; set; }

    public virtual ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
