using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.OtherConfig;
public class Parent
{
    public int ParentId { get; set; }
    public string Name { get; set; }
    public string ParentCode { get; set; }
    public List<Child> Children { get; set; }
}
public class Child
{
    public int ChildId { get; set; }
    public string ChildName { get; set; }
    public string ParentCode { get; set; }
}

public class OtherDbContext : DbContext
{
    public DbSet<Parent> Parents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parent>(c =>
        {
            //c.HasAlternateKey(c => c.ParentCode);
            c.HasMany(c => c.Children).WithOne().HasPrincipalKey(d => d.ParentCode).HasConstraintName("MyConstraintName");
        });
    }
}