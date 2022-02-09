using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.TableSplittingSamples;
public class NewsSummry
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string imageUrl { get; set; }
    public NewsDetail? NewsDetail { get; set; }

}

public class NewsDetail
{
    public int Id { get; set; }
    public string Body { get; set; }
}

public class NewsContext : DbContext
{
    public DbSet<NewsSummry> NewsSummries { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=NewsDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NewsSummry>(c => {
            c.HasOne(c => c.NewsDetail).WithOne().HasForeignKey<NewsDetail>(c => c.Id);
            c.ToTable("News");

            }) ;
        modelBuilder.Entity<NewsDetail>().ToTable("News");
    }
}
