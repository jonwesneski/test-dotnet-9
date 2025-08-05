using System.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebApplication1.Entity;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Services;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("PgDbConnection");

void FirstQuery()
{
    using NpgsqlConnection connection = new(connectionString);
    connection.Open();
    // Connection is now open, perform database operations
    var tableName = "steps";//"recipes";
    using NpgsqlCommand command = new($"SELECT * FROM {tableName} LIMIT 0", connection);
    using NpgsqlDataReader reader = command.ExecuteReader();
    DataTable schemaTable = reader.GetSchemaTable() ?? new DataTable();

    foreach (DataRow row in schemaTable.Rows)
    {
        string columnName = row["ColumnName"].ToString();
        Console.WriteLine($"Column Name: {columnName}");
    }
    connection.Close();
}

async void SecondQuery()
{
    using NpgsqlConnection connection = new(connectionString);
    connection.Open();
    using NpgsqlCommand command2 = new($"SELECT id, name FROM recipes", connection);
    using NpgsqlDataReader reader2 = command2.ExecuteReader();

    // Read data from the table
    while (await reader2.ReadAsync())
    {
        var id = reader2.GetFieldValue<string>(reader2.GetOrdinal("id"));
        var name = reader2.GetFieldValue<string>(reader2.GetOrdinal("name"));
        Console.WriteLine($"{id}\t{name}");
    }
    connection.Close();
}

async void InnerJoinQuery()
{
    using NpgsqlConnection connection = new(connectionString);
    connection.Open();
    var queryString =
@"SELECT
    R.id AS recipeid, R.name,
    S.id AS stepid, S.instruction,
    I.id AS ingredientid, I.amount AS amount, I.unit as unit, I.name AS ingredient
FROM
    recipes R
INNER JOIN
    steps S ON R.id = S.""recipeId""
INNER JOIN
    ingredients I ON S.id = I.""stepId""
WHERE
    R.name = 'Tres Leches Cake'
";
    using NpgsqlCommand command2 = new(queryString, connection);
    using NpgsqlDataReader reader2 = command2.ExecuteReader();

    var recipes = new List<RecipeEntity>();
    var previousRecipeId = "";
    var previousStepId = "";
    var previousIngredientId = "";

    // Read data from the table
    while (await reader2.ReadAsync())
    {

        var id = reader2.GetString("recipeid");
        if (id != previousRecipeId)
        {
            Console.WriteLine(id);
            var name = reader2.GetString("name");
            recipes.Add(new RecipeEntity { Id = id, Name = name, Steps = [] });
            previousRecipeId = id;
        }

        var stepId = reader2.GetString("stepId");
        if (stepId != previousStepId)
        {
            var recipe = recipes.Last();
            var instruction = reader2.GetString("instruction");
            recipe.Steps.Add(new StepEntity { Id = stepId, Instruction = instruction, Ingredients = [] });
            previousStepId = stepId;
        }



        var ingredientId = reader2.GetString("ingredientid");
        if (ingredientId != previousIngredientId)
        {
            var amount = reader2.GetDouble("amount");
            var unit = reader2.GetString("unit");
            var ingredient = reader2.GetString("ingredient");
            var step = recipes.Last().Steps.Last();
            step.Ingredients.Add(new IngredientEntity { Id = ingredientId, Amount = amount, Unit = unit, Name = ingredient });
            previousIngredientId = ingredientId;
        }
    }
    connection.Close();


    foreach (var recipe in recipes)
    {
        Console.WriteLine($"Recipe: {recipe.Name}");
        for (int i = 0; i < recipe.Steps.Count; i++)
        {
            var step = recipe.Steps[i];
            Console.WriteLine($"Step {i + 1}:");
            foreach (var ingredient in step.Ingredients)
            {
                Console.WriteLine($"{ingredient.Amount} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine($"Ingredients:\n - {step.Instruction}");
        }
    }
}


FirstQuery();
InnerJoinQuery();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<RecipesDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddScoped<IRecipesRepository, RecipesRepository>();
builder.Services.AddScoped<IMessageProducer, MessageProducer>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Version 1");
    });
}
app.MapControllers();

app.UseHttpsRedirection();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
