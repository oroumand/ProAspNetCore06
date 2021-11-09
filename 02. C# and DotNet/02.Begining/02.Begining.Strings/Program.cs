// See https://aka.ms/new-console-template for more information
using System;
using System.Text;

Console.WriteLine("Hello, World!");
string s1 = "Alireza";
string s2 = "Oroumand";
string s3 = s1 + " " + s2;


StringBuilder stringBuilder= new StringBuilder();
stringBuilder.Append(s1);

Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);

stringBuilder.Append(s2);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);

stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);

stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);
stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);
stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);
stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);
stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);
stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);
stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);
Console.WriteLine(stringBuilder.Length);
stringBuilder.Append(s3);
Console.WriteLine(stringBuilder.Capacity);

Console.WriteLine(stringBuilder.Length);
var result = stringBuilder.ToString();

var message = string.Format("my name is {0}, and my lastname is {1}",  s2, s1);

FormattableString interpolatedMessage = $"interpolated message is :my name is {s1}, and my lastname is {s2}";

Console.WriteLine(interpolatedMessage.GetArgument(0).ToString());


Console.WriteLine(message);


string original = "My string message";

var substring = original[..4];


Console.WriteLine(original);
Console.WriteLine(substring);


//Console.WriteLine(interpolatedMessage);
Console.ReadLine();