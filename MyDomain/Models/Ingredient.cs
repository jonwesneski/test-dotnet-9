namespace MyDomain.Models;

public partial class Ingredient
{
    public string Id { get; set; } = null!;

    [System.Text.Json.Serialization.JsonIgnore]
    public int DisplayOrder { get; set; }

    public double Amount { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public string StepId { get; set; } = null!;

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Step Step { get; set; } = null!;
}
