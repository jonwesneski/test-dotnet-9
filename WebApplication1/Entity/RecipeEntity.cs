using System;

namespace WebApplication1.Entity;

public class RecipeEntity
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required List<StepEntity> Steps { get; set; }
}
