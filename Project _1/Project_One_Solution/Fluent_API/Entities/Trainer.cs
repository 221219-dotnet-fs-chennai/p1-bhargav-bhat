using System;
using System.Collections.Generic;

namespace Fluent_API.Entities;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? AboutMe { get; set; }

    public virtual ICollection<AdditionalDetail> AdditionalDetails { get; } = new List<AdditionalDetail>();

    public virtual ICollection<Education> Educations { get; } = new List<Education>();

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();

    public virtual ICollection<WorkExperience> WorkExperiences { get; } = new List<WorkExperience>();
}
