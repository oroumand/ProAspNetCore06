using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.OneToOneSample;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Discount Discount { get; set; }
}

public class Discount
{
    public int Id { get; set; }
    public int ProductId { get; set; }
}


public class OneToOneContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=OneToOneDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(c =>
        {
            c.HasOne(c=>c.Discount).WithOne().HasForeignKey<Discount>(discount=>discount.ProductId);
        });
    }
}