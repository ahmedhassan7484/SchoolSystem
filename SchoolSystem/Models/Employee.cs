using System;
using System.Collections.Generic;

namespace SchoolSystem.Models;

public partial class Employee
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

    public byte? Age { get; set; }

    public string? JopName { get; set; }

    public int? Bonus { get; set; }

    public string? Email { get; set; }

    public int? TransportId { get; set; }

    public virtual Transport? Transport { get; set; }
}
