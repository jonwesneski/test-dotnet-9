using Moq;
using WebApplication1.Controllers;
using MyDomain.Data;
using MyDomain.Data.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Test;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        var mockDbContext = new Mock<RecipesDbContext>();
        var mockRepository = new Mock<IRecipesRepository>();
        var mockMessageProducer = new Mock<IMessageProducer>();
        var recipeController = new RecipesController(
            mockDbContext.Object,
            mockRepository.Object,
            mockMessageProducer.Object
        );
        var response = await recipeController.GetRecipe("123");
        mockRepository.Verify(m => m.GetByIdAsync("123"), Times.Once);
    }
}
