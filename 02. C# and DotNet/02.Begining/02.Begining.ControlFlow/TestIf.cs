using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Begining.ControlFlow
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }
    public class SwithTest
    {
        public void PerintColor(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    Console.WriteLine("Red");
                    break;
                case Color.Green:
                    Console.WriteLine("Green");
                    break;
                case Color.Blue:
                    Console.WriteLine("Blue");
                    break;
                default:
                    Console.WriteLine("No Color");
                    break;
            }


        }

        public string ReturnColor(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return "Red";
                case Color.Green:
                    return "Green";

                case Color.Blue:
                    return "Blue";
                default:
                    return "No Color";
            }

        }

        public string ReturnColorExp(Color color) => color switch
        {
            Color.Red => "red",
            Color.Green => "Greed",
            Color.Blue => "Blue",
            _ => "No color"
        };
    }
    internal class TestIf
    {

        public void PrintIfPerson(object obj)
        {
            if (obj.GetType() == typeof(Person))
            {
                Console.WriteLine("Is a person");
            }
            else
            {
                Console.WriteLine("Is not a person");
            }
        }


        public void PrintIfPerson2(object obj)
        {
            if (obj is Person person)
            {
                Console.WriteLine($"Is a person {person.Id} {person.Name}");
            }
            else
            {
                Console.WriteLine("Is not a person");
            }
        }
    }
}
