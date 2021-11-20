// See https://aka.ms/new-console-template for more information
using CSharpTypes.Structs;

Console.WriteLine("Hello, World!");
PersonOld personOld = new PersonOld
{
    Id = 1,
    FirstName = "Alireza",
    LastName = "Oroumand"
};

PersonOld personOld1 = personOld with { FirstName = "Mohammad" };