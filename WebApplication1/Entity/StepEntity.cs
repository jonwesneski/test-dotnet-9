using System;

namespace WebApplication1.Entity;

public class StepEntity
{
    public required string Id { get; set; }
    public required List<IngredientEntity> Ingredients { get; set; }
    public required string Instruction { get; set; }
}
