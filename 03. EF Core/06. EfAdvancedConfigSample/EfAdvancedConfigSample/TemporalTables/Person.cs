using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAdvancedConfigSample.TemporalTables;
public class Person
{
    public int Id { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class PersonTemporalRepository
{
    private readonly PersonTemporalContext ctx;

    public PersonTemporalRepository(PersonTemporalContext ctx)
    {
        this.ctx = ctx;
    }
    public void AddPerson(string firstName,string lastName)
    {
        Person p = new()
        {
            FirstName = firstName,
            LastName = lastName
        };
        ctx.People.Add(p);
        ctx.SaveChanges();
    }
    public void EditPerson(int id,string firstName,string lastName)
    {
        var p = ctx.People.Find(id);
        p.FirstName = firstName;
        p.LastName = lastName;
        ctx.SaveChanges();
    }

    public void DeletePerson(int id)
    {
        var person = ctx.People.Find(id);
        ctx.People.Remove(person);
        ctx.SaveChanges();
           
    }

    public void PrintAllWithHistory()
    {
        var people = ctx.People.TemporalAll().Select(c => new
        {
            c.FirstName,
            c.LastName,
            c.Id,
            Start = EF.Property<DateTime>(c, "PeriodStart"),
            End = EF.Property<DateTime>(c, "PeriodEnd")
        });
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Id}\t{person.FirstName}\t{person.LastName}\t{person.Start}\t{person.End}");
        }
    }
}

public class PersonTemporalContext:DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=PersonTemporalDb; User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable(t =>
        {
            t.IsTemporal();
        });
    }

}
