using Microsoft.EntityFrameworkCore;

namespace EfAdvancedConfigSample.ComputedColumn;

public class PersonDbContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=PersonDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().Property(c => c.FullName).HasComputedColumnSql("FirstName + ' ' + LastName", true);

        modelBuilder.Entity<Person>().Property(c => c.Age).HasDefaultValue(100);

        modelBuilder.Entity<Person>().Property(c => c.RegisterDate).HasDefaultValueSql("getdate()");
    }


}
