using System.Reflection;

var assembly = Assembly.LoadFrom(@"E:\Source\ProAspNetCore06\02. C# and DotNet\12. AttributeSamples\AttributeSample.Domain\bin\Debug\net6.0\AttributeSample.Domain.dll");

var types = assembly.GetTypes();
Console.WriteLine($"**************{assembly.FullName}**************");
foreach (var type in types)
{
    Console.WriteLine($"{type.Name}");
}

Console.ReadLine();