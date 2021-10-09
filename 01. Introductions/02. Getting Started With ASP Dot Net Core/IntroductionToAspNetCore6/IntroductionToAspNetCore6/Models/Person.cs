using Microsoft.EntityFrameworkCore;

namespace IntroductionToAspNetCore6.Models
{
    public class Person
    {
        public int Id {  get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }


    }

    public class PersonContext:DbContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

    }
}
