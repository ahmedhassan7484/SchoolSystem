using System;
using System.Collections.Generic;

namespace SchoolSystem.Models;

public partial class EventSpeaker
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? TelNumper1 { get; set; }

    public string? TelNumper2 { get; set; }

    public string? Email { get; set; }

    public string? Pictural { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
