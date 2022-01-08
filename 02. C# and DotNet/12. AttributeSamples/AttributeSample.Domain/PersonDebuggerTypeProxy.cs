namespace AttributeSample.Domain;

public class PersonDebuggerTypeProxy
{
    private readonly Person _person;

    public PersonDebuggerTypeProxy(Person person)
    {
        _person = person;
    }

    public string FullName => $"{_person.FirstName}, {_person.LastName}";
    public int Age => _person.Age;
}