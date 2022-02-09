using Microsoft.EntityFrameworkCore;

namespace EfCore.RelationConfiguraitonSample.SimpleConventionSample;
public class SimpleConventionSampleContext:DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=SimpleConventionDb;User Id=sa; Password=1qaz!QAZ");
    }
}
