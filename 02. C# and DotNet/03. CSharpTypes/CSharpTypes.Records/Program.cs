// See https://aka.ms/new-console-template for more information
using CSharpTypes.Records;

Console.WriteLine("Hello, World!");


PersonRecord personRecord01 = new PersonRecord
{
    Id = 1,
    FirstName = "Alireza",
    LastName = "Oroumand"
};

PersonRecord personRecord02 = new PersonRecord
{
    Id = 1,
    FirstName = "Alireza",
    LastName = "Oroumand"
};

PersonClass personClass01 = new PersonClass
{
    Id = 1,
    FirstName = "Alireza",
    LastName = "Oroumand"
};


PersonClass personClass02 = new PersonClass
{
    Id = 1,
    FirstName = "Alireza",
    LastName = "Oroumand"
};


Console.WriteLine($"PersonRecord ToString is: {personRecord01}");

Console.WriteLine($"PersonClass ToString is: {personClass01}");

Console.WriteLine($"PersonRecord reference equal is: {object.ReferenceEquals(personRecord01,personRecord02)}");

Console.WriteLine($"PersonClass reference equal is: {object.ReferenceEquals(personClass01, personClass02)}");


Console.WriteLine($"PersonRecord  equal is: {personRecord01==personRecord02}");

Console.WriteLine($"PersonClass  equal is: {personClass01== personClass02}");


PersonRecord2 personRecord2 = new PersonRecord2(1, "Alireza", "Oroumand");
PersonRecord2 personRecord3 = personRecord2 with { Id = 2 };



Console.ReadLine();