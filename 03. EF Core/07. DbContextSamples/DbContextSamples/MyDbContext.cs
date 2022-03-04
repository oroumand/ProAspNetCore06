using DbContextSamples.Interceptors;
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
    public DbSet<Course> Courses { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<NewsSummary> Summaries { get; set; }
    public DbSet<Student> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial Catalog=SampleDbContext; User Id=sa; Password=1qaz!QAZ")
        .AddInterceptors(new AddAuditDataInterceptor());

        //.AddInterceptors(new CancelTagedQuery());
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);

        modelBuilder.Entity<Course>().HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications);
        modelBuilder.Entity<NewsSummary>().ToSqlQuery("Select Id,Title from News");
    }
    //public override int SaveChanges()
    //{
    //    ChangeTracker.AutoDetectChangesEnabled = false;
    //    AddAuditData();
    //    var result = base.SaveChanges();
    //    ChangeTracker.AutoDetectChangesEnabled = true;
    //    return result;
    //}

    private void AddAuditData()
    {
        ChangeTracker.DetectChanges();
        var added = ChangeTracker.Entries<IAuditable>().Where(c => c.State == EntityState.Added).ToList();

        foreach (var item in added)
        {
            item.Property(c => c.InsertDate).CurrentValue = DateTime.Now;
        }
        var modified = ChangeTracker.Entries<IAuditable>().Where(c => c.State == EntityState.Modified).ToList();

        foreach (var item in modified)
        {
            item.Property(c => c.UpdateDate).CurrentValue = DateTime.Now;
        }
    }
}
