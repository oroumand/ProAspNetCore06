using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.OneToManySample;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Comment> Comments { get; set; }
}

public class Comment
{
    public int CommentId { get; set; }
    public int ProductId { get; set; }
    public string CommentText { get; set; }
}




public class OneToManyContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=OneToManyDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(c =>
        {
            c.HasMany(c=>c.Comments).WithOne().HasForeignKey(d=>d.ProductId);
        });
    }
}