using System;
using System.Collections.Generic;

namespace Entities;

public partial class AdditionalDetail
{
    public int Id4 { get; set; }

    public int? TrainerId { get; set; }

    public string? Title { get; set; }

    public string? Achievements { get; set; }

    public string? Publications { get; set; }

    public string? VolunteeringExperiences { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
