using BlazorSample.FoodRecipes.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSample.FoodRecipes.DAL.Configurations;
public class RecipeConfig : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(c => c.ImageUrl).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.Originality).IsRequired().HasMaxLength(200);
    }
}

