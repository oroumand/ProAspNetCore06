using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.TPHSamples;
public abstract class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Student:Person
{
    public string StudentNumebr { get; set; }
}

public class Teacher : Person
{
    public string TeacherNumber { get; set; }
}
public class TphContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=TphDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(c =>
        {
            c.HasDiscriminator<int>("Disc").HasValue<Person>(1).HasValue<Student>(2).HasValue<Teacher>(3);
        });
    }
}