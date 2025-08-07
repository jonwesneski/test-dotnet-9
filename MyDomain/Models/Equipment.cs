namespace MyDomain.Models;

public partial class Equipment
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string RecipeId { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
