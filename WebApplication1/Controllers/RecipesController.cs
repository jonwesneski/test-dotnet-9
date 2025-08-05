using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesDbContext _context;
        private readonly IRecipesRepository _recipesRepository;
        private readonly IMessageProducer _messageProducer;

        public RecipesController(
            RecipesDbContext context,
            IRecipesRepository recipesRepository,
            IMessageProducer messageProducer)
        {
            _context = context;
            _recipesRepository = recipesRepository;
            _messageProducer = messageProducer;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(string id)
        {
            var recipe = await _recipesRepository.GetByIdAsync(id);
            // _context.Recipes.Include(r => r.Steps).ThenInclude(s => s.Ingredients).FirstOrDefaultAsync(r => r.Id == id);
            await _messageProducer.SendMessage<Recipe>(recipe);
            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(string id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecipeExists(recipe.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(string id)
        {
            var recipeEntity = await _context.Recipes.FindAsync(id);
            if (recipeEntity == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipeEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeExists(string id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
