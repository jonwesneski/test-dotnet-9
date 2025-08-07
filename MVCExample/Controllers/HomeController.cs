using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCExample.Models;
using MyDomain.Data.Repositories;

namespace MVCExample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRecipesRepository _recipesRepository;

    public HomeController(ILogger<HomeController> logger, IRecipesRepository recipesRepository)
    {
        _logger = logger;
        _recipesRepository = recipesRepository;
    }

    public async Task<IActionResult> Index()
    {
        var recipes = await _recipesRepository.GetAllAsync();
        return View(recipes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
