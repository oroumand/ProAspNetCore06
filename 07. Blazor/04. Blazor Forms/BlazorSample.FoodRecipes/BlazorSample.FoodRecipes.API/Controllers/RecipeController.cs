using BlazorSample.FoodRecipes.DAL;
using BlazorSample.FoodRecipes.DAL.Entities;
using BlazorSample.FoodRecipes.Shared.Features.ManageRecipes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSample.FoodRecipes.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly FoodRecipeDbContext _dbContext;
    private readonly ILogger<RecipeController> _logger;

    public RecipeController(FoodRecipeDbContext dbContext, ILogger<RecipeController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    [HttpPost]
    public async Task<IActionResult> Add(RecipeDto model)
    {
        try
        {
            Recipe recipe = new Recipe
            {
                Name = model.Name,
                Description = model.Description,
                Originality = model.Originality,
                Price = model.Price,
                TimeInMinuts = model.TimeInMinuts,
                ImageUrl = "not set",
                Ingridients = model.Ingridients.Select(c => new Ingridient
                {
                    Name = c.Name,
                }).ToList()

            };
            await _dbContext.Recipes.AddAsync(recipe);
            await _dbContext.SaveChangesAsync();
            return Ok(recipe.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Badness");
            return BadRequest(-1);
        }

    }
}
