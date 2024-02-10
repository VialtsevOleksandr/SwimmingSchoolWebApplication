using System;
using System.Collections.Generic;

namespace SwimmingSchoolWebApplication.Models;

public partial class Event
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public short MaxPupilsAmount { get; set; }

    public string? Description { get; set; }

    public string? Decree { get; set; }

    public virtual ICollection<PupilsEvent> PupilsEvents { get; set; } = new List<PupilsEvent>();
}
