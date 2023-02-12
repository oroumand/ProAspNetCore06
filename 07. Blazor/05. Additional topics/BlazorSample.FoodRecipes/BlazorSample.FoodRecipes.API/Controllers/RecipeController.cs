using BlazorSample.FoodRecipes.DAL;
using BlazorSample.FoodRecipes.DAL.Entities;
using BlazorSample.FoodRecipes.Shared.Features.ManageRecipes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

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
    [HttpGet] 
    public async Task<IActionResult> GetAll()
    {
        var ingridients = await _dbContext.Recipes.Include(c=>c.Ingridients).ToListAsync();
        return Ok(ingridients);
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

    [HttpPost("{id}")]
    public async Task<IActionResult> AddImage(int id)
    {

        var file = Request.Form.Files[0];
        if(file.Length == 0)
        {
            return BadRequest();
        }

        Recipe recipe = _dbContext.Recipes.FirstOrDefault(c=> c.Id == id);
        if(recipe == null)
        {
            return BadRequest();
        }
        var filename = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

        var resizeOption = new ResizeOptions
        {
            Mode = ResizeMode.Pad,
            Size = new SixLabors.ImageSharp.Size(800, 600)
        };

        using var image = Image.Load(file.OpenReadStream());
        image.Mutate(c=>c.Resize(resizeOption));
        await image.SaveAsJpegAsync(saveLocation);
        recipe.ImageUrl = filename;
        await _dbContext.SaveChangesAsync();
        return Ok();

    }
}
