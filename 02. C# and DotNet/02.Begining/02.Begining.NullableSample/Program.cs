// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//int age = 0;

//Nullable<int> ageNullable = null;

//if(ageNullable.HasValue)
//{
//    Console.WriteLine(ageNullable.Value);
//}

//int? newSyntax = null;

string? firstName = null;

if(!string.IsNullOrEmpty(firstName))
    Console.Write(firstName.ToUpper());

Console.Write(firstName.ToUpper());
