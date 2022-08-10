using Microsoft.EntityFrameworkCore;

namespace ValidationSamples.Models;

public class ValidationDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public ValidationDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(20);
    }
}