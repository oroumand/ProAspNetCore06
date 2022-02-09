using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.TPTSamples;
public class Person
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
public class TpTContext : DbContext
{
    public DbSet<Person> People { get; set; }
    //public DbSet<Student> Students { get; set; }
    //public DbSet<Teacher> Teachers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=TpTDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().ToTable("Teachers");
        modelBuilder.Entity<Student>().ToTable("Students");
    }
}