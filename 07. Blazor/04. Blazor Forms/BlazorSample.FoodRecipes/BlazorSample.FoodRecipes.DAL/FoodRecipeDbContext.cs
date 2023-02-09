using BlazorSample.FoodRecipes.DAL.Configurations;
using BlazorSample.FoodRecipes.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorSample.FoodRecipes.DAL;
public class FoodRecipeDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingridient> Ingridients{ get; set; }
    public FoodRecipeDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RecipeConfig());
        modelBuilder.ApplyConfiguration(new IngridientConfig());
    }
}
