namespace DependencyInjectionSample.TightCoupling;
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class PersonRepository : IPersonRepository
{
    public void Add(Person person)
    {
        //Save To SQL Server
    }
}

public class CreatePersonHandler
{
    public void Hanle(string firstName, string lastName)
    {
        Person person = new()
        {
            FirstName = firstName,
            LastName = lastName
        };
        IPersonRepository personRepository = PersonRepositoryFactory.Instance();
        personRepository.Add(person);
    }
}

public class PersonRepositoryFactory
{
    public static PersonRepository Instance()
    {
        return new PersonRepository();
    }
}