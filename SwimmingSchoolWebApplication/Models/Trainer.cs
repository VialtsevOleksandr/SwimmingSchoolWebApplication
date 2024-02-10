using System;
using System.Collections.Generic;

namespace SwimmingSchoolWebApplication.Models;

public partial class Trainer
{
    public short Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Birthday { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
