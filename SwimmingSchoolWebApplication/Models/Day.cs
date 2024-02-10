using System;
using System.Collections.Generic;

namespace SwimmingSchoolWebApplication.Models;

public partial class Day
{
    public short Id { get; set; }

    public string NameOfDay { get; set; } = null!;

    public virtual ICollection<GroupSchedule> GroupSchedules { get; set; } = new List<GroupSchedule>();
}
