using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.ManyToManySamples;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Tag> Tags { get; set; }
}

public class Tag
{
    public int TagId { get; set; }
    public string TagName { get; set; }
    public List<Product> Products { get; set; }
}

public class PTRelationEntity
{
    public int TagId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public Tag Tag { get; set; }
}


public class ManyToManyContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=ManyToManyDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(c =>
        {
            c.HasMany(c => c.Tags).WithMany(t => t.Products).UsingEntity<PTRelationEntity>(
                p => p.HasOne(d => d.Tag).WithMany().HasForeignKey(d => d.TagId),
                t => t.HasOne(d => d.Product).WithMany().HasForeignKey(d => d.ProductId));
        });
    }
}