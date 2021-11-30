using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class ForRename02
    {

    }
    internal class OperatorSample
    {
        public void CompoundOperators()
        {
            int a = 0;

            Console.WriteLine(a++);
            Console.WriteLine(++a);
        }

        public void PritnName()
        {
            Console.WriteLine(nameof(ForRename02));
        }


        public void NullOperator01()
        {
            int? a = null;

            int b = a == null ? 0 : a.Value;


            int c = a ?? 0;
        }

        public void NullOperator02(Person person)
        {
            Console.WriteLine(person?.FirstName);
        }
        public string ConditionalExpression(int input)
        {
            //if(input == 0)
            //{
            //    return "Zero";
            //}
            //else
            //{
            //    return "Not Zero";
            //}
            //var result = input == 0 ? "Zero" : "Not Zero";
            return input == 0 ? "Zero" : "Not Zero";

        }


        public void SizeOf()
        {
            Console.WriteLine(sizeof(byte));
            Console.WriteLine(sizeof(short));
            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(long));

        }
        public void Checked()
        {

            byte b = byte.MaxValue;
            Console.WriteLine(b);
            //b = checked(b++);
            unchecked
            {
                b++;
            }
            Console.WriteLine(b);

        }

        public void Typeof()
        {
            var type = typeof(Person);

            Console.WriteLine(type.AssemblyQualifiedName);
            Console.WriteLine(type.Namespace);
            Console.WriteLine(type.FullName);
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine(prop.Name);
            }
        }
        public void CheckIs(object input)
        {
            Console.WriteLine(input is Person);
        }

        public void CheckAs(object input)
        {
            var person = input as Person;
            if (person != null)
            {
                Console.WriteLine("Is Person");
            }
            else
            {
                Console.WriteLine("Is not  person");
            }
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Student : Person
    {
        public string StudentNumber { get; set; }
    }


    public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
