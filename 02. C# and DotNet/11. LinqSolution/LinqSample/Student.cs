using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSample
{

    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudnetId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public static List<StudentCourse> GetStudentCourses() =>
            new List<StudentCourse>
            {
                new StudentCourse{ Id = 1, StudnetId = 1, Name ="ASP.NET Core", Score=20 },
                new StudentCourse{ Id = 2, StudnetId = 1, Name ="SQL Server", Score=18 },
                new StudentCourse{ Id = 3, StudnetId = 2, Name ="ASP.NET Core", Score=15 },
                new StudentCourse{ Id = 4, StudnetId = 2, Name ="EF core", Score=20 },
                new StudentCourse{ Id = 5, StudnetId = 3, Name ="ASP.NET Core", Score=16 },

            };
    }
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }

        public static List<Student> GetStudents() =>
            new List<Student>
            {
                new Student{Id=1, FirstName="Arash",LastName="Azhdari",Grade=20},
                new Student{Id=2, FirstName="Alireza",LastName="Vatani",Grade=20},
                new Student{Id=3, FirstName="Mahdi",LastName="Hosseini",Grade=19},
                new Student{Id=4, FirstName="Hassan",LastName="Mohammadi",Grade=15},
                new Student{Id=5, FirstName="Hossein",LastName="Almasi",Grade=19},
                new Student{Id=6, FirstName="Mohammad",LastName="Abbasi",Grade=10},
                new Student{Id=7, FirstName="Mohammad",LastName="Rezaei",Grade=11},
                new Student{Id=8, FirstName="Farid",LastName="Taheri",Grade=14},
            };

        public static void PrintStudents(List<Student> students)
        {
            Console.WriteLine("".PadLeft(100, '-'));
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id}:{student.FirstName},{student.LastName} = {student.Grade}");
            }
            Console.WriteLine("".PadLeft(100, '-'));
        }


    }
}
