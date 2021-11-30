// See https://aka.ms/new-console-template for more information
using DelegateSamples;

Console.WriteLine("Hello, World!");
TestFunctions testFunctions = new TestFunctions();

//testFunctions.TestClosure();

Teacher techer = new("Alireza", "Oroumand");

TeacherChangeNameLogger tl = new TeacherChangeNameLogger();
TeacherChangeNameLogger2 tl2 = new TeacherChangeNameLogger2();

techer.TeacherNameChanged += tl.Log;
techer.TeacherNameChanged += tl2.Log;

techer.SetName("Mohammadreza");