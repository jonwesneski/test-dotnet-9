using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class NutritionalFact
{
    public string Id { get; set; } = null!;

    public int? Servings { get; set; }

    public int? ServingAmount { get; set; }

    public int? CaloriesInKcal { get; set; }

    public int? TotalFatInG { get; set; }

    public int? SaturatedFatInG { get; set; }

    public int? TransFatInG { get; set; }

    public int? CholesterolInMg { get; set; }

    public int? SodiumInMg { get; set; }

    public int? CarbohydratesInG { get; set; }

    public int? FiberInG { get; set; }

    public int? SugarInG { get; set; }

    public int? ProteinInG { get; set; }

    public int? VitaminAinIu { get; set; }

    public int? VitaminCinMg { get; set; }

    public int? VitaminDinIu { get; set; }

    public int? VitaminB6inMg { get; set; }

    public int? VitaminB12inMg { get; set; }

    public int? CalciumInMg { get; set; }

    public int? IronInMg { get; set; }

    public int? MagnesiumInMg { get; set; }

    public int? PotassiumInMg { get; set; }

    public int? FolateInMcg { get; set; }

    public int? ThiaminInMg { get; set; }

    public int? RiboflavinInMg { get; set; }

    public int? NiacinInMg { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? RecipeId { get; set; }

    public string? UserId { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
