using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsSample
{
    public class Car
    {
        public int Id { get; set; }
    }
    public class GenericConcate<TInput>
    {

        public string Concat(TInput right, TInput left)
        {
            var defaultValue = default(TInput);


            var stringRight = right.ToString();
            var stringLeft = left.ToString();
            var result = $"Right string is: {stringRight}, Left string is; {stringLeft}";
            return result;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"FirstName: {FirstName}, LastName:{LastName}";
        }
    }


    public class Student : Person
    {
        public string StudentNumber { get; set; }
    }
    public class Teacher : Person
    {
        public string TeacherNumber { get; set; }
    }


    public class PersonPrinter<TInput> where TInput : Person, new()
    {
        public void Print(TInput input)
        {
            TInput input1 = new TInput();

            Console.WriteLine($"{input.FirstName}, {input.LastName}");
        }
    }


    public class Parent<TInput01, TInput02>
    {

    }

    public class Child01 : Parent<int, string>
    {

    }
    public class Child01<TInput02> : Parent<int, TInput02>
    {

    }
    public class Child03<TInput01, TInput02> : Parent<TInput01, TInput02>
    {

    }


    public class StaticParam<T>
    {
        public static int Counter;
    }

    public class Simple
    {
        public string Print<TInput>(TInput input)
        {
            return input.ToString();
        }
    }

}
