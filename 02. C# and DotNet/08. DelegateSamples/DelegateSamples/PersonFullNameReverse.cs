namespace DelegateSamples
{
    public class PersonFullNameReverse
    {
        public static string GetPersonFullName(Person person)
        {
            Console.WriteLine($"PersonFullNameReverse Executed");
            return $"{person.LastName} {person.FirstName} ";
        }
    }
}
