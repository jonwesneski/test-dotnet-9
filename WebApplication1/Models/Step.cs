using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Step
{
    public string Id { get; set; } = null!;

    [System.Text.Json.Serialization.JsonIgnore]
    public int DisplayOrder { get; set; }

    public string? Instruction { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public string RecipeId { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Recipe Recipe { get; set; } = null!;
}
