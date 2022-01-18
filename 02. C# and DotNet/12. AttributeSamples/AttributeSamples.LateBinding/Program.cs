using System.Reflection;

var assembly = Assembly.LoadFrom(@"E:\Source\ProAspNetCore06\02. C# and DotNet\12. AttributeSamples\AttributeSample.Domain\bin\Debug\net6.0\AttributeSample.Domain.dll");
var personType = assembly.GetType("AttributeSample.Domain.Person");

var person = Activator.CreateInstance(personType);
Console.WriteLine($"My object Type is {person}");
//var peronMethods = personType.GetMethods();

//foreach (var method in peronMethods)
//{
//    Console.WriteLine(method.Name);
//}    

var printMethod = personType.GetMethod("Print");

printMethod.Invoke(person, null);


var inputPrinterMethod = personType.GetMethod("InputPrinter");
inputPrinterMethod.Invoke(person,new object[] {"This is input parameter"});

Console.ReadKey();
