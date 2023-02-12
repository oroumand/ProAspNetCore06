using BlazorSample.FoodRecipes.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSample.FoodRecipes.DAL.Configurations;

public class IngridientConfig : IEntityTypeConfiguration<Ingridient>
{
    public void Configure(EntityTypeBuilder<Ingridient> builder)
    {
        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
    }
}

