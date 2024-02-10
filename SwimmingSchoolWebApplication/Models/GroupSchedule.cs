using System;
using System.Collections.Generic;

namespace SwimmingSchoolWebApplication.Models;

public partial class GroupSchedule
{
    public short Id { get; set; }

    public short GroupId { get; set; }

    public short DayId { get; set; }

    public TimeOnly TimeOfTrainingStart { get; set; }

    public short TrainingTime { get; set; }

    public virtual Day Day { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;
}
