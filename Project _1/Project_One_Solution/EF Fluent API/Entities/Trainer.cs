using System;
using System.Collections.Generic;

namespace EF_Fluent_API.Entities;

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
}
