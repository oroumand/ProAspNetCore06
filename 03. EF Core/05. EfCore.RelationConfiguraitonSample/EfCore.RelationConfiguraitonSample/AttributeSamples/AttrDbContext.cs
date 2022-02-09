using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.AttributeSamples;
public class AttrDbContext:DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Addresses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=AttrDb;User Id=sa; Password=1qaz!QAZ");
    }
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Address
{
    public int Id { get; set; }
    public string Citry { get; set; }
   
    public Person Person { get; set; }

    [ForeignKey("Person")]
    public int FkPersonSampleAttributeId { get; set; }

}
