using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Handle { get; set; } = null!;

    public bool UseFractions { get; set; }

    public bool UseImperial { get; set; }

    public bool UseDarkMode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual NutritionalFact? NutritionalFact { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual ICollection<UserFollow> UserFollowFollowings { get; set; } = new List<UserFollow>();

    public virtual ICollection<UserFollow> UserFollowUsers { get; set; } = new List<UserFollow>();
}
