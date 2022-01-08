using AttributeSamples.CustomAttributes;
using System.Diagnostics;

namespace AttributeSample.Domain;

public class PersonPrinter
{
    private readonly Person _person;

    public PersonPrinter(Person person)
    {
        _person = person;
    }

    public void Print()
    {
        ShowDebugData();
        ShowDeveloperName();
        PrintFullName();
        PrintAge();
    }
    [Conditional("ALIREZA")]
    private void ShowDeveloperName()
    {
        Console.WriteLine("Developer name is Alireza");
    }

    [Conditional("DEBUG")]
    private void ShowDebugData()
    {
        Console.WriteLine("This application compiled in debug mode");
    }

    //[Obsolete(message: "PrintAge() will remove ...",error:true)]
    public void PrintAge()
    {
        Console.WriteLine($"Age: {_person.Age}");
    }

    private void PrintFullName()
    {
        Console.WriteLine($"FullName: {_person.FirstName}, {_person.LastName}");
    }
}
