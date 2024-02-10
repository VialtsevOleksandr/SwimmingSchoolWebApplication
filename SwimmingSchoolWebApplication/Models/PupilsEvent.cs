using System;
using System.Collections.Generic;

namespace SwimmingSchoolWebApplication.Models;

public partial class PupilsEvent
{
    public short PupilsId { get; set; }

    public short EventId { get; set; }

    public string? Info { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Pupil Pupils { get; set; } = null!;
}
