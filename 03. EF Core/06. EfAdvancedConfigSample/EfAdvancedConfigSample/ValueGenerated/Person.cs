using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAdvancedConfigSample.ValueGenerated;
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public DateTime RegisterDate { get; set; }

    public int Age { get; set; }

}


public class PersonDbContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=PersonDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().Property(c => c.FullName).ValueGeneratedOnAdd();

        //modelBuilder.Entity<Person>().Property(c => c.Age).HasDefaultValue(100);

        //modelBuilder.Entity<Person>().Property(c => c.RegisterDate).HasDefaultValueSql("getdate()");
    }


}
