using Microsoft.EntityFrameworkCore;

namespace ControllersWithViewSamples.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class PeopleContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public PeopleContext(DbContextOptions options) : base(options)
    {
    }
}