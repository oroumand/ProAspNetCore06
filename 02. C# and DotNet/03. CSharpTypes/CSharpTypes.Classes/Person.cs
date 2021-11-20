namespace CSharpTypes.Classes;
public class Person
{
    private readonly int _age = 1;

    private string _firstName;

    public string FirstName
    {
        get
        {

            return _firstName;
        }
        set
        {
            _firstName = value;
        }
    }

    public string LastName { get; set; }

    public string FatherName { get; init; }

    public Person(int age)
    {
        _age = age;
    }

    public void PeritFullName()
    {
        Console.WriteLine($"{FirstName} {LastName}");
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public string GetFullNameExp() => $"{FirstName} {LastName}";

    public int Add2Numbers(int number1, int number2)
    {
        return number1 + number2;
    }


    public static int GetCount()
    {
        return 0;
    }


    public void Print(string textForPrint)
    {
        Console.WriteLine(textForPrint);
    }
    public void Print(string textForPrint, string textForPrint2)
    {
        Console.WriteLine(textForPrint);
        Console.WriteLine(textForPrint2);
    }
    public void Print(int numberForPrint)
    {
        Console.WriteLine(numberForPrint);
    }


    public void PrintNumbers(int width, int height)
    {
        Console.WriteLine($"x is: {width}, y is: {height}");
    }


    public void OptionalSample(int x, int y, int z = 4, int b = 2)
    {
        Console.WriteLine($"x is: {x}, y is: {y}, z is: {z}");
    }

    public void ParamsTest(string firstName,params int[] myNumber)
    {
        foreach (var item in myNumber)
        {
            Console.WriteLine(item);
        }
    }

    public void ParamsTest(string firstName,int myNumber)
    {

    }

    public void ParamsTest(string firstName, int myNumber, int myNumber2)
    {

    }

    public void PrintFullName()
    {

        string fullName = getFullName(FirstName, LastName);
        Console.WriteLine(fullName);

        static string getFullName(string firstName, string lastName)
        {
            return $"{firstName},  {lastName}";
        }


    }
}

