using Microsoft.EntityFrameworkCore;
using SimpleEfConficurationSamples.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEfConficurationSamples.Models;

//[EntityTypeConfiguration(typeof(PersonConfig))]
public class Person
{
    public Person(string firstName)
    {
        FirstName = firstName;
    }
    public int PersonId { get; set; }
    public string FirstName { get; private set; }
    public string? LastName { get; set; }
    public bool? IsActive { get; set; }
    public int Age { get; set; }
    public string GetStringAge { get;}
    
    public List<Contact> Contacts { get; set; }

}
