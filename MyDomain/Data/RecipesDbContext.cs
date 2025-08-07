using Microsoft.EntityFrameworkCore;
using MyDomain.Models;

namespace MyDomain.Data;

public partial class RecipesDbContext : DbContext
{
    public RecipesDbContext()
    {
    }

    public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<NutritionalFact> NutritionalFacts { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFollow> UserFollows { get; set; }

    //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //     {

    //         optionsBuilder.UseNpgsql("Server=localhost;Database=recipes-db;Port=5432;User Id=user;Password=password;");
    //     }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("MeasurementUnit", new[] { "whole", "pinches", "cups", "fluidOunces", "tablespoons", "teaspoons", "pints", "quarts", "gallons", "pounds", "ounces", "liters", "milliliters", "kilograms", "grams" });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("equipments_pkey");

            entity.ToTable("equipments");

            entity.HasIndex(e => e.Name, "equipments_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.RecipeId).HasColumnName("recipeId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("equipments_recipeId_fkey");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ingredients_pkey");

            entity.ToTable("ingredients");

            entity.HasIndex(e => new { e.StepId, e.DisplayOrder }, "ingredients_stepId_displayOrder_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DisplayOrder).HasColumnName("displayOrder");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.StepId).HasColumnName("stepId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Step).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.StepId)
                .HasConstraintName("ingredients_stepId_fkey");
        });

        modelBuilder.Entity<NutritionalFact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("nutritional_facts_pkey");

            entity.ToTable("nutritional_facts");

            entity.HasIndex(e => e.RecipeId, "nutritional_facts_recipeId_key").IsUnique();

            entity.HasIndex(e => e.UserId, "nutritional_facts_userId_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CalciumInMg).HasColumnName("calciumInMg");
            entity.Property(e => e.CaloriesInKcal).HasColumnName("caloriesInKcal");
            entity.Property(e => e.CarbohydratesInG).HasColumnName("carbohydratesInG");
            entity.Property(e => e.CholesterolInMg).HasColumnName("cholesterolInMg");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.FiberInG).HasColumnName("fiberInG");
            entity.Property(e => e.FolateInMcg).HasColumnName("folateInMcg");
            entity.Property(e => e.IronInMg).HasColumnName("ironInMg");
            entity.Property(e => e.MagnesiumInMg).HasColumnName("magnesiumInMg");
            entity.Property(e => e.NiacinInMg).HasColumnName("niacinInMg");
            entity.Property(e => e.PotassiumInMg).HasColumnName("potassiumInMg");
            entity.Property(e => e.ProteinInG).HasColumnName("proteinInG");
            entity.Property(e => e.RecipeId).HasColumnName("recipeId");
            entity.Property(e => e.RiboflavinInMg).HasColumnName("riboflavinInMg");
            entity.Property(e => e.SaturatedFatInG).HasColumnName("saturatedFatInG");
            entity.Property(e => e.ServingAmount).HasColumnName("servingAmount");
            entity.Property(e => e.Servings).HasColumnName("servings");
            entity.Property(e => e.SodiumInMg).HasColumnName("sodiumInMg");
            entity.Property(e => e.SugarInG).HasColumnName("sugarInG");
            entity.Property(e => e.ThiaminInMg).HasColumnName("thiaminInMg");
            entity.Property(e => e.TotalFatInG).HasColumnName("totalFatInG");
            entity.Property(e => e.TransFatInG).HasColumnName("transFatInG");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.VitaminAinIu).HasColumnName("vitaminAInIU");
            entity.Property(e => e.VitaminB12inMg).HasColumnName("vitaminB12InMg");
            entity.Property(e => e.VitaminB6inMg).HasColumnName("vitaminB6InMg");
            entity.Property(e => e.VitaminCinMg).HasColumnName("vitaminCInMg");
            entity.Property(e => e.VitaminDinIu).HasColumnName("vitaminDInIU");

            entity.HasOne(d => d.Recipe).WithOne(p => p.NutritionalFact)
                .HasForeignKey<NutritionalFact>(d => d.RecipeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("nutritional_facts_recipeId_fkey");

            entity.HasOne(d => d.User).WithOne(p => p.NutritionalFact)
                .HasForeignKey<NutritionalFact>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("nutritional_facts_userId_fkey");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipes_pkey");

            entity.ToTable("recipes");

            entity.HasIndex(e => new { e.UserId, e.Name }, "recipes_userId_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CookingTimeInMinutes).HasColumnName("cookingTimeInMinutes");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");
            entity.Property(e => e.IsPublic).HasColumnName("isPublic");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PreparationTimeInMinutes).HasColumnName("preparationTimeInMinutes");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("recipes_userId_fkey");

            entity.HasMany(d => d.Tags).WithMany(p => p.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "RecipeTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("recipe_tags_tagId_fkey"),
                    l => l.HasOne<Recipe>().WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("recipe_tags_recipeId_fkey"),
                    j =>
                    {
                        j.HasKey("RecipeId", "TagId").HasName("recipe_tags_pkey");
                        j.ToTable("recipe_tags");
                        j.IndexerProperty<string>("RecipeId").HasColumnName("recipeId");
                        j.IndexerProperty<string>("TagId").HasColumnName("tagId");
                    });
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("steps_pkey");

            entity.ToTable("steps");

            entity.HasIndex(e => new { e.RecipeId, e.DisplayOrder }, "steps_recipeId_displayOrder_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DisplayOrder).HasColumnName("displayOrder");
            entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");
            entity.Property(e => e.Instruction).HasColumnName("instruction");
            entity.Property(e => e.RecipeId).HasColumnName("recipeId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Steps)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("steps_recipeId_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.HasIndex(e => e.Name, "tags_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Handle, "users_handle_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Handle).HasColumnName("handle");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UseDarkMode)
                .HasDefaultValue(false)
                .HasColumnName("useDarkMode");
            entity.Property(e => e.UseFractions)
                .HasDefaultValue(false)
                .HasColumnName("useFractions");
            entity.Property(e => e.UseImperial)
                .HasDefaultValue(false)
                .HasColumnName("useImperial");
        });

        modelBuilder.Entity<UserFollow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_follows_pkey");

            entity.ToTable("user_follows");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.FollowingId).HasColumnName("followingId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Following).WithMany(p => p.UserFollowFollowings)
                .HasForeignKey(d => d.FollowingId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("user_follows_followingId_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserFollowUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("user_follows_userId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
