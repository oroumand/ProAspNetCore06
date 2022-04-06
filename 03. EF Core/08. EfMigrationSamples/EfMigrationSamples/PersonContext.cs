using EfMigrationSamples.MyMigrationOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfMigrationSamples;

public class PersonContext:DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Book> Books{ get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial catalog=PersonDb; User Id=sa; Password=1qaz!QAZ", c =>
        {
            c.MigrationsHistoryTable("MyApplicationMigrationHistory");
        });
            //.ReplaceService<IMigrationsSqlGenerator, MySqlMigrationGenerator>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //حذف مدل از فرایند مهاجرت دیتابیس
       // modelBuilder.Entity<Car>().ToTable("Cars", c => c.ExcludeFromMigrations());
    }
}