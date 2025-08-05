using System;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories;

public interface IRecipesRepository
{
    Task<Recipe> GetByIdAsync(string id);
    Task<IEnumerable<Recipe>> GetAllAsync();
    // Task AddAsync(Recipe item);
    // Task UpdateAsync(Recipe item);
    // Task DeleteAsync(int id);
}
