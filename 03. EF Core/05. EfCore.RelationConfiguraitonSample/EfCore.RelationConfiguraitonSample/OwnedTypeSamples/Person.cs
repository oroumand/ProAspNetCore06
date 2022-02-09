using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.OwnedTypeSamples;
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public Car Car { get; set; }
    public List<Money> Money { get; set; }
}

public class Money
{
    public int MoneyId { get; set; }
    public int Value { get; set; }
}

public class Car
{
    public string CarName { get; set; }
}
public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}

public class OwnedDbContext : DbContext
{
    public DbSet<Person> People { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=OwnedDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(person =>
        {
            person.OwnsOne(person => person.Address);
            person.OwnsOne(c => c.Car).ToTable("Cars");
            person.OwnsMany(c => c.Money).ToTable("MyMoney");
        });
    }
}
