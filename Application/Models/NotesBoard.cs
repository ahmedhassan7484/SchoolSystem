﻿using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class NotesBoard
{
    public int Id { get; set; }

    public string Note { get; set; } = null!;

    public byte? RateOfSchool { get; set; }
}
