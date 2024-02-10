using System;
using System.Collections.Generic;

namespace SwimmingSchoolWebApplication.Models;

public partial class Pupil
{
    public short Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public DateOnly Birthday { get; set; }

    public string ParentsPhoneNumber { get; set; } = null!;

    public short GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<PupilsEvent> PupilsEvents { get; set; } = new List<PupilsEvent>();
}
