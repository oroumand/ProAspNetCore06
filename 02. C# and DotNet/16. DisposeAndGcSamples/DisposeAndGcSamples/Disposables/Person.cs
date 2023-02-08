using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeAndGcSamples.Disposables;
public class Person : IDisposable
{
    private string _firstName;

    public void SetName(string firstName)
    {
        _firstName = firstName;
    }
    public string GetName()
        => _firstName;
    public void Dispose()
    {
        int a = 123;
        //Close Db Connection
        //Memory
        //File
    }
}

public class PersonService
{
    public void UsePerson()
    {
        //Scope
        //using Person person = new Person();

        using (Person person = new Person())
        {
            person.SetName("Alireza");
            var name = person.GetName();
            Console.WriteLine($"Person name is: {name}");
        }

        //After Compile
        //Person person = new Person();
        //try
        //{
        //    person.SetName("Alireza");
        //    var name = person.GetName();
        //    Console.WriteLine($"Person name is: {name}");
        //}
        //finally
        //{
        //    person.Dispose();
        //}
    }
}
