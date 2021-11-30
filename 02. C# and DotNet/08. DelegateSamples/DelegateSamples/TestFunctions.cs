using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSamples
{
    public class TestFunctions
    {
        public void TestFunction01()
        {

            Person person = new Person
            {
                FirstName = "Alrieza",
                LastName = "Oroumand"
            };

            PersonToString myDelegate = PersonFullName.GetPersonFullName;

            var result = myDelegate.Invoke(person);
            Console.WriteLine(result);
            Console.WriteLine("".PadLeft(100, '_'));

            PersonPrinter PersonPrinter = new PersonPrinter();
            PersonPrinter.Print(PersonFullName.GetPersonFullName, person);
            PersonPrinter.Print(PersonFullNameReverse.GetPersonFullName, person);
            Console.WriteLine("".PadLeft(100, '_'));
            Func<int, int, int, string> func = ForFunc.MyIntToString;
            Console.WriteLine(func(1, 2, 3));
            Console.WriteLine("".PadLeft(100, '_'));

            PersonPrinter.PrintFunc(PersonFullName.GetPersonFullName, person);
            PersonPrinter.PrintFunc(PersonFullNameReverse.GetPersonFullName, person);
        }

        public void TestMulticastDelegate()
        {
            MethodNamePrinter methodNamePrinter = new MethodNamePrinter();

            MethodNamePrinterHolder myDelegate = methodNamePrinter.Method01;
            myDelegate += methodNamePrinter.Method02;
            myDelegate += methodNamePrinter.Method03;

            myDelegate += methodNamePrinter.Method04;
            myDelegate();

        }
        public void TestMulticastDelegateExceptionHandle()
        {
            MethodNamePrinter methodNamePrinter = new MethodNamePrinter();

            MethodNamePrinterHolder myDelegate = methodNamePrinter.Method01;
            myDelegate += methodNamePrinter.Method02;
            myDelegate += methodNamePrinter.Method03;

            myDelegate += methodNamePrinter.Method04;

            var list = myDelegate.GetInvocationList();

            foreach (var item in list)
            {
                try
                {
                    item.DynamicInvoke();
                }
                catch (Exception)
                {


                }
            }
        }
        public void TestMulticastDelegateWithoutput()
        {
            Person person = new Person
            {
                FirstName = "Alrieza",
                LastName = "Oroumand"
            };
            PersonToString myDelegate = PersonFullName.GetPersonFullName;
            myDelegate += PersonFullNameReverse.GetPersonFullName;
            PersonPrinter PersonPrinter = new PersonPrinter();
            PersonPrinter.Print(myDelegate, person);


        }

        public void AnonymousMethodSample()
        {
            Person person = new Person
            {
                FirstName = "Alrieza",
                LastName = "Oroumand"
            };

            PersonToString myDelegate = delegate (Person person)
            {
                return $"{person.FirstName}-{person.LastName}";
            };

            var result = myDelegate(person);
            Console.WriteLine(result);
        }

        public void LambdaTest()
        {
            Func<int, string> func = x => x.ToString();

            Func<int, int, string> func2 = (x, y) => $"{x},{y}";
            
            Func<int, int, string> func3 = (x, y) =>
            {
                if(x> y)
                {
                    return x.ToString();
                }
                else if(x<y)
                {
                    return y.ToString();
                }
                return $"{x},{y}";
            };

            Func<string> funcString = () => "Test Func";


            var result = func(1);
            Console.WriteLine(result);
        }

        public void TestClosure()
        {
            int localVariable = 1;

            Func<int, int> AddWithLocal = x =>
             {
                 var result = x + localVariable;
                 return result;
             };

            localVariable = 100;
            var result = AddWithLocal(1);
            Console.WriteLine(result);
        }
    }
}
