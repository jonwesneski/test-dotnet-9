using Microsoft.EntityFrameworkCore;
using MyDomain.Models;

namespace MyDomain.Data.Repositories;

public class RecipesRepository : IRecipesRepository
{
    private readonly RecipesDbContext _context;

    public RecipesRepository(RecipesDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await _context.Recipes.Include(r => r.Steps.OrderBy(s => s.DisplayOrder))
                .ThenInclude(s => s.Ingredients.OrderBy(i => i.DisplayOrder))
                .ToListAsync();
    }

    public Task<Recipe> GetByIdAsync(string id)
    {
        return _context.Recipes
                .Include(r => r.Steps.OrderBy(s => s.DisplayOrder))
                .ThenInclude(s => s.Ingredients.OrderBy(i => i.DisplayOrder))
                .FirstAsync(r => r.Id == id);
    }
}
