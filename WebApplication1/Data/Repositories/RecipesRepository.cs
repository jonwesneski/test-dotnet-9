using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories;

public class RecipesRepository : IRecipesRepository
{
    private readonly RecipesDbContext _context;

    public RecipesRepository(RecipesDbContext context)
    {
        _context = context;
    }
    public Task<IEnumerable<Recipe>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Recipe> GetByIdAsync(string id)
    {
        return _context.Recipes
                .Include(r => r.Steps.OrderBy(s => s.DisplayOrder))
                .ThenInclude(s => s.Ingredients.OrderBy(i => i.DisplayOrder))
                .FirstAsync(r => r.Id == id);
    }
}
