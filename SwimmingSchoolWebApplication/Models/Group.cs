using System;
using System.Collections.Generic;

namespace SwimmingSchoolWebApplication.Models;

public partial class Group
{
    public short Id { get; set; }

    public string GroupName { get; set; } = null!;

    public short TrainerId { get; set; }

    public virtual ICollection<GroupSchedule> GroupSchedules { get; set; } = new List<GroupSchedule>();

    public virtual ICollection<Pupil> Pupils { get; set; } = new List<Pupil>();

    public virtual Trainer Trainer { get; set; } = null!;
}
