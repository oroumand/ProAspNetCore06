using Microsoft.EntityFrameworkCore;

namespace ViewComponentSamples.Models;

public class News
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }
}

public class NewsDbContext:DbContext
{
    public DbSet<News> News { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=News; User Id=sa; Password=1qaz!QAZ");
    }
}
