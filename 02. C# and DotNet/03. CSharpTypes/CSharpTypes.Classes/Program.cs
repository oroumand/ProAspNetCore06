// See https://aka.ms/new-console-template for more information
using CSharpTypes.Classes;
using CSharpTypes.Classes.Domain;
using CSharpTypes.Classes.Extentions;
Console.WriteLine("Hello, World!");
var person = new Person(12)
{
    FirstName = "Alireza",
    LastName = "Oroumand",
    FatherName ="FatherName"
};

var personSummary = new
{
    person.FirstName,
    person.FatherName
};


person.FirstName = "Hassan";


int count = Person.GetCount();
Console.WriteLine(count);

var fullName = person.GetFullName();
Console.WriteLine(fullName);


person.PrintNumbers(height: 3,width: 2) ;

person.OptionalSample(1, 2,b:4);

//person.ParamsTest(1,2,3,4,5,6,7,9,0,10);

//person.OptionalSample(1, 2, 2);

var teacher = new Teacher
{
    FiratName = "Alireza",
    LastName = "Oroumand"
};



var student = new
{
    FirstName = "Alireza",
    LastName = "Oroumand",
    Number = "12345"
};
var student2 = new
{
    FirstName = "Mohammad",
    LastName = "Oroumand",
    Number = "12345"
};

student = student2;

Console.WriteLine(student.FirstName);
Console.WriteLine(student.LastName);
Console.WriteLine(student.Number);

