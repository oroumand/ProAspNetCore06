using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ModelBindingSamples.Models;

public class Product
{
    [BindNever]
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
}
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Temp AAA { get; set; } = new Temp
    {
        Id = 1,
        Name = "Test"
    };
}
public class Temp
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Test
{
    public Temp Temp { get; set; }
}

public class MyModelBindingContext:DbContext
{
    public MyModelBindingContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

}