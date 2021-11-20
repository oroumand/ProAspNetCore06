// See https://aka.ms/new-console-template for more information
using OOPInCSharp.AccessModifiers;
using OOPInCSharp.ClassInheritance.Animals;
using OOPInCSharp.ClassInheritance.Constr;
using OOPInCSharp.ClassInheritance.MyClasses;
using OOPInCSharp.ClassInheritance.People;


//Parent parent = new();

//FirstChild firstChild = new();
//Console.WriteLine(parent.GetClassName());
//Console.WriteLine(firstChild.GetClassName());
//Console.WriteLine(firstChild.GetChidlClassName());

//Animal animal = new();
//Console.WriteLine($"Animal Voice Is:");
//animal.Voice();
//List<Animal> animals = new List<Animal>();
//Animal cat01 = new Cat();
//Animal dog01 = new Dog();
//Animal caw01 = new Caw();
//animals.Add(cat01);
//animals.Add(dog01);
//animals.Add(caw01);

//foreach (var animal in animals)
//{
//    animal.Feed();
//}

//Dog dog = new();
//Console.WriteLine($"Dog Voice Is:");
//dog.Voice();


//Cat cat = new();
//Console.WriteLine($"Cat Voice Is:");
//cat.Voice();



//Caw caw= new();
//Console.WriteLine($"Caw Voice Is:");
//caw.Voice();
Mobile mobile = new("POCO");

Mobile mobile2 = new();

Console.ReadLine();


PublicSample publicSample = new PublicSample();

ProtectedSample protectedSample = new ProtectedSample();
PrivateSample privateSample = new PrivateSample();

using (MyDisposable temp = new MyDisposable())
{

}

MyFirstInterfaceImpl myFirstInterfaceImpl = new MyFirstInterfaceImpl();


MyFirstInterface myFirstInterface = myFirstInterfaceImpl;


MyFirstInterface2 myFirstInterface2 = myFirstInterfaceImpl;



