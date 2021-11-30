// See https://aka.ms/new-console-template for more information
using GenericsSample;

//Console.WriteLine("Hello, World!");

//GenericConcate<int> genricConcateInt = new GenericConcate<int>();
//var result = genricConcateInt.Concat(1, 2);
//Console.WriteLine(result);
//GenericConcate<string> genricConcateString = new GenericConcate<string>();

// result = genricConcateString.Concat("Alireza", "Oroumand");


//var genericPerson = new GenericConcate<Person>();

//result = genericPerson.Concat(new Person { FirstName = "Alireza", LastName = "Oroumand" }, new Person { FirstName = "Arash", LastName = "Ajdari" });

//Console.WriteLine(result);

//Teacher teacher = new Teacher
//{
//    FirstName = "A",
//    LastName = "B",
//    TeacherNumber = "123"
//};

//Student student = new Student
//{
//    FirstName = "c",
//    LastName = "d",
//    StudentNumber = "123"
//};


//var teacherPrinter = new PersonPrinter<Teacher>();
//teacherPrinter.Print(teacher);

//var studentPrinter = new PersonPrinter<Student>();
//studentPrinter.Print(student);

//var carPrinter = new PersonPrinter<Car>();
//carPrinter.Print(new Car
//{
//    Id = 1
//});


StaticParam<int>.Counter = 12;
StaticParam<string>.Counter = 15;
StaticParam<bool>.Counter = 1;

Console.WriteLine(StaticParam<int>.Counter);
Console.WriteLine(StaticParam<string>.Counter);
Console.WriteLine(StaticParam<bool>.Counter);
StaticParam<int>.Counter = 13;

Console.WriteLine(StaticParam<int>.Counter);
Console.WriteLine(StaticParam<string>.Counter);
Console.WriteLine(StaticParam<bool>.Counter);


var simple = new Simple();
simple.Print<int>(1);
simple.Print<string>("string");
Console.ReadLine();