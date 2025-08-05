using System;

namespace WebApplication1.Entity;

public class IngredientEntity
{
    public required string Id { get; set; }
    public double Amount { get; set; }
    public required string Unit { get; set; }
    public required string Name { get; set; }
}
