using System;
using System.Collections.Generic;

namespace Entities;

public partial class WorkExperience
{
    public int Id3 { get; set; }

    public int? TrainerId { get; set; }

    public string? CompanyName { get; set; }

    public string? Role { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? Description { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
