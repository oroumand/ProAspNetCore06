using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextSamples;
public class MyDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course>  Courses{ get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<NewsSummary> Summaries { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial Catalog=SampleDbContext; User Id=sa; Password=1qaz!QAZ");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);

        modelBuilder.Entity<Course>().HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications);
        modelBuilder.Entity<NewsSummary>().ToSqlQuery("Select Id,Title from News");
    }
}
