using System;
using System.Collections.Generic;

namespace Fluent_API.Entities;

public partial class Skill
{
    public int Id1 { get; set; }

    public int? TrainerId { get; set; }

    public string? Skills { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
