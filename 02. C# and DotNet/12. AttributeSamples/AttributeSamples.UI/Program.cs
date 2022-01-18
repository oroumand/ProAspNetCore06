using AttributeSample.Domain;

Person alireza = new()
{
    FirstName = "Alireza",
    LastName = "Oroumand",
    Age = 900
};

PersonPrinter printer = new(alireza);
printer.Print();
Console.ReadLine();