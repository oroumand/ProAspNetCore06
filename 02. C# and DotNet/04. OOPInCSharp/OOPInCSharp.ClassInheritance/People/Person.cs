using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInCSharp.ClassInheritance.People
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "NoName";
        public string LastName { get; set; } = "NoLastName";
    }

    public sealed class Teacher:Person
    {

    }

    public class Student
    {

    }
}
