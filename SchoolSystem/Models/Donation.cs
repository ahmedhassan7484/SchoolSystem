using System;
using System.Collections.Generic;

namespace SchoolSystem.Models;

public partial class Donation
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Donor { get; set; }

    public long Price { get; set; }

    public string? BaymantWay { get; set; }

    public string? DonorAddress { get; set; }

    public string? TelNumper1 { get; set; }

    public string? TelNumper2 { get; set; }

    public string? Email { get; set; }
}
