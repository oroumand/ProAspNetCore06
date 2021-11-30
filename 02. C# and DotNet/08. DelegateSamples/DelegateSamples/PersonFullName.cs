namespace DelegateSamples
{
    public class PersonFullName
    {
        public static string GetPersonFullName(Person person)
        {
            Console.WriteLine($"PersonFullName Executed");
           return $"{person.FirstName} {person.LastName}";
        }
            
    }
}
