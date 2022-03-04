using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextSamples;
public class SampleSources
{
    private readonly MyDbContext myDbContext;

    public SampleSources(MyDbContext myDbContext)
    {
        this.myDbContext = myDbContext;
    }

    public void SetEntityState(int id,string firstName,string lastName)
    {
        myDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        Person person = new Person
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        };

        Console.WriteLine($"person state is {myDbContext.Entry(person).State}");

        myDbContext.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        myDbContext.Entry(person).Property(c => c.FirstName).IsModified = false;
        Console.WriteLine($"person state is {myDbContext.Entry(person).State}");

        myDbContext.SaveChanges();
        Console.WriteLine($"person state is {myDbContext.Entry(person).State}");



    }

    public void ContextIdSample()
    {
        MyDbContext ctx1 = new();
        MyDbContext ctx2 = new();

        Console.WriteLine($"Context 1 Id is {ctx1.ContextId}");
        Console.WriteLine($"Context 2 Id is {ctx2.ContextId}");
    }

    public void UpdateTeacher(int id, string firstName,string lastName)
    {
        var teacher = myDbContext.Teachers.FirstOrDefault(teacher => teacher.Id == id);
        if(teacher != null)
        {
            teacher.FirstName = firstName;
            teacher.LastName = lastName;
            myDbContext.SaveChanges();
        }
    }

    public void ShowChangeTrackerDebugView()
    {
        Console.WriteLine("--------------------------- Short View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.ShortView);
        Console.WriteLine("--------------------------- Long View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.LongView);

        var teachers = myDbContext.Teachers.ToList();

        Console.WriteLine("--------------------------- Short View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.ShortView);
        Console.WriteLine("--------------------------- Long View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.LongView);

        var person = new Person
        {
            FirstName = "Alireza",
            LastName = "Oroumand"
        };
        myDbContext.People.Add(person);

        Console.WriteLine("--------------------------- Short View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.ShortView);
        Console.WriteLine("--------------------------- Long View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.LongView);

        teachers[0].FirstName = "Alireza";

        Console.WriteLine("--------------------------- Short View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.ShortView);
        Console.WriteLine("--------------------------- Long View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.LongView);


    }

    public void FromSqlSample()
    {
        string name = "Edited";
        var people = myDbContext.People.FromSqlInterpolated($"Select * from People where FirstName = {name}").OrderBy(c=>c.LastName).ToList();

        foreach (var person in people)
        {
            Console.WriteLine($"{person.Id}\t {person.FirstName}\t{person.LastName}");
        }

        Console.WriteLine("--------------------------- Short View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.ShortView);
        Console.WriteLine("--------------------------- Long View ---------------------------");
        Console.WriteLine(myDbContext.ChangeTracker.DebugView.LongView);

        //people[0].FirstName = "Edited";
        //myDbContext.SaveChanges();
    }

    public void InsertPersonRaw()
    {
        myDbContext.Database.ExecuteSqlRaw("Insert into People(FirstName,LastName) values('Hamid','Saberi')");
    }

    public void FromSqlQueryNews()
    {
        var newsSummary = myDbContext.Summaries.ToList();
        foreach (var item in newsSummary)
        {
            Console.WriteLine($"{item.Id}\t{item.Title}");
        }

    }

    public void ChangeConnectionString()
    {
        var person = new Person
        {
            FirstName = "Mohammad",
            LastName = "Lotfi",

        };

        var person2 = new Person
        {
            FirstName = "Fardi",
            LastName = "Taheri",

        };
       // var ctx2 = new MyDbContext();
        //ctx2.Database.SetConnectionString("Server=.; Initial Catalog=SampleDbContext2; User Id=sa; Password=1qaz!QAZ");

        myDbContext.People.Add(person);
        myDbContext.SaveChanges();
        myDbContext.Database.SetConnectionString("Server=.; Initial Catalog=SampleDbContext2; User Id=sa; Password=1qaz!QAZ");
        myDbContext.People.Add(person2);
        myDbContext.SaveChanges();
    }

    public void ExecuteTagedQuery()
    {
        var people = myDbContext.People.TagWith("My Tag").ToList();
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Id}\t {person.FirstName}\t{person.LastName}");
        }
    }

    public void AddStudnet(string name)
    {
        var student = new Student
        {
            Name = name
        };

        myDbContext.Students.Add(student);
        myDbContext.SaveChanges();
    }
}

