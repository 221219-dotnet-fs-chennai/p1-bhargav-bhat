using System;
using System.Collections.Generic;

namespace Fluent_API.Entities;

public partial class Education
{
    public int Id2 { get; set; }

    public int? TrainerId { get; set; }

    public string? CollegeUniversity { get; set; }

    public string? Degree { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? Description { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
