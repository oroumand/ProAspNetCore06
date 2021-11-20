using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTypes.Structs
{
   // public record struct MyStructRecord(int Id, int FirstName, int LastName);
    public  struct PersonOld
    {

        public PersonOld()
        {
            age = 1;
            Id = 1;
            FirstName = "Alireza";
            LastName = "Oroumand";

        }

        public  int age;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public readonly struct Person7_2
    {
        public readonly int age;
        public int Id { get; init; }
        public string FirstName { get; }
        public string LastName { get; }
    }

    public struct Person8
    {
        public int age;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public readonly string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }

}
