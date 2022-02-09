using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfIntro.Models;
public class Repository
{
    public void AddPerson(string FirstName, string LastName)
    {
        Person p = new()
        {
            FirstName = FirstName,
            LastName = LastName
        };
        EfIntroDbContext _efIntroDb = new EfIntroDbContext();
        _efIntroDb.People.Add(p);
        _efIntroDb.SaveChanges();
    }

    public void UpdatePerson(int id, string firstName, string lastName)
    {
        EfIntroDbContext _efIntroDb = new EfIntroDbContext();
        Person person = _efIntroDb.People.Find(id);
        if (person != null)
        {
            person.FirstName = firstName;
            person.LastName = lastName;
            _efIntroDb.SaveChanges();
        }
    }

    public void PrintPeople()
    {
        EfIntroDbContext _efIntroDb = new EfIntroDbContext();
        var people = _efIntroDb.People.AsNoTracking().ToList();
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Id} \t {person.FirstName},{person.LastName}");
        }
    }

    public void Delete(int id)
    {
        EfIntroDbContext _efIntroDb = new EfIntroDbContext();
        Person person = _efIntroDb.People.Find(id);
        if (person != null)
        {
            _efIntroDb.People.Remove(person);
            _efIntroDb.SaveChanges();
        }
    }
}
