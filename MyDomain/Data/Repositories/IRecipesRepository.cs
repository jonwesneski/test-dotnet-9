using MyDomain.Models;

namespace MyDomain.Data.Repositories;

public interface IRecipesRepository
{
    Task<Recipe> GetByIdAsync(string id);
    Task<IEnumerable<Recipe>> GetAllAsync();
    // Task AddAsync(Recipe item);
    // Task UpdateAsync(Recipe item);
    // Task DeleteAsync(int id);
}
