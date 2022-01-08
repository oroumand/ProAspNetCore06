using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSample
{
    public class LinqOperators
    {
        public void PrintNamesWithoutLinq()
        {
            List<string> names = new List<string>
            {
                "Alireza Oroumand",
                "Farid Taheri",
                "Hamid Saberi",
                "Arash Azhdari",
                "Mohammad Abbasi",
                "Abbas Masoumi"
            };

            List<string> result = new();
            foreach (string name in names)
            {
                if (name.StartsWith("A"))
                    result.Add(name);
            }

            result.Sort();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintNamesWithLinqQuery()
        {
            List<string> names = new List<string>
            {
                "Alireza Oroumand",
                "Farid Taheri",
                "Hamid Saberi",
                "Arash Azhdari",
                "Mohammad Abbasi",
                "Abbas Masoumi"
            };

            var result = from name in names
                         where name.StartsWith("A")
                         orderby name
                         select name;
            var typename = result.GetType().FullName;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintNamesWithLinqMethod()
        {
            List<string> names = new List<string>
            {
                "Alireza Oroumand",
                "Farid Taheri",
                "Hamid Saberi",
                "Arash Azhdari",
                "Mohammad Abbasi",
                "Abbas Masoumi"
            };
            
            var result = names.Where(c => c.StartsWith("A")).OrderBy(c => c);
            var typename = result.GetType().FullName;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintNumbersDiferred()
        {
            List<int> Numbers = new List<int> { 1, 2, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            var lessThan10 = from num in Numbers where num < 10 select num;

            foreach (var num in lessThan10)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("************************");
            Numbers.Add(3);
            Numbers.Add(5);
            foreach (var num in lessThan10)
            {
                Console.WriteLine(num);
            }
        }
        public void PrintNumbersImmediat()
        {
            List<int> Numbers = new List<int> { 1, 2, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            var lessThan10 = (from num in Numbers where num < 10 select num).ToList();

            foreach (var num in lessThan10)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("************************");
            Numbers.Add(3);
            Numbers.Add(5);
            foreach (var num in lessThan10)
            {
                Console.WriteLine(num);
            }
        }

        public void FilterStudentsQuery()
        {
            var students = Student.GetStudents();

            var result = (from s in students where s.Grade > 15 select s).ToList();
            Student.PrintStudents(result);
        }


        public void FilterStudentsMethod()
        {
            var students = Student.GetStudents();
            var result = students.Where((c, index) => c.Grade > 15 || c.Grade > index).ToList();
            Student.PrintStudents(result);

        }

        public void FilterByType()
        {
            List<object> list = new List<object> { 1, 2, "Alireza", "Hossein", false, 123 };
            var numbers = list.OfType<int>().ToList();

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }

        public void SortStudents()
        {
            var students = Student.GetStudents().ToList();

            var sortedStudent = students.OrderBy(c => c.FirstName).ToList();
            Student.PrintStudents(sortedStudent);
        }
        public void SortGradeAndNameStudents()
        {
            var students = Student.GetStudents().ToList();

            var sortedStudent = students.OrderBy(c => c.Grade).ThenBy(c => c.FirstName).ToList();
            Student.PrintStudents(sortedStudent);
        }
        public void SortDescStudents()
        {
            var students = Student.GetStudents().ToList();

            var sortedStudent = students.OrderByDescending(c => c.FirstName).ToList();
            Student.PrintStudents(sortedStudent);
        }

        public void GroupStudents()
        {
            var students = Student.GetStudents();
            var groupByGrade = students.GroupBy(c => c.Grade);

            foreach (var item in groupByGrade)
            {
                Console.WriteLine(item.Key);
                foreach (var student in item)
                {
                    Console.WriteLine($"{student.Id} {student.FirstName} {student.LastName}");
                }
                Console.WriteLine("".PadLeft(50, '*'));
            }
        }

        public void InnerJoin()
        {
            var students = Student.GetStudents();
            var course = StudentCourse.GetStudentCourses();

            var result = students.Join(course, s => s.Id, c => c.StudnetId, (s, c) =>
                       new
                       {
                           StudentId = s.Id,
                           CourseId = c.Id,
                           s.FirstName,
                           s.LastName,
                           c.Name,
                           c.Score
                       });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.StudentId}: {item.FirstName},{item.LastName} {item.Name}={item.Score}");
            }
        }

        public void GroupJoin()
        {
            var students = Student.GetStudents();
            var course = StudentCourse.GetStudentCourses();
            var groupJoin = students.GroupJoin(course, s => s.Id, c => c.StudnetId, (s, c) =>
                new
                {
                    s.Id,
                    s.FirstName,
                    s.LastName,
                    StudentCourse = c,
                }).ToList();

            foreach (var item in groupJoin)
            {
                Console.WriteLine($"{item.Id},{item.FirstName} {item.LastName}: {item.StudentCourse?.Count()}");
            }

        }

        public void LeftJoin()
        {
            var students = Student.GetStudents();
            var course = StudentCourse.GetStudentCourses();

            var groupJoin = students.GroupJoin(course, s => s.Id, c => c.StudnetId, (s, c) =>
                new
                {
                    s.Id,
                    s.FirstName,
                    s.LastName,
                    StudentCourse = c,
                }).SelectMany(c => c.StudentCourse.DefaultIfEmpty(), (s, c) =>
                {
                    return new
                    {
                        s.Id,
                        s.FirstName,
                        s.LastName,
                        course = c?.Name ?? "---"
                    };
                }).ToList();

            foreach (var item in groupJoin)
            {
                Console.WriteLine($"{item.Id},{item.FirstName} {item.LastName}: {item.course}");
            }

        }

        public void Distinct()
        {
            List<int> ints  = new List<int> { 1, 2, 3, 4, 5,4,5,1 };
            var distinct = ints.Distinct();
            foreach (var item in distinct)
            {
                Console.WriteLine(item);
            }
        }

        public void Union()
        {
            List<int> int01 = new List<int> { 1, 2, 3, 4, 5, 4, 5, 1 };
            List<int> int02 = new List<int> { 4,5,6,7,8 };

            var union =int01.Union(int02);
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
        }
        public void Except()
        {
            List<int> int01 = new List<int> { 1, 2, 3, 4, 5, 4, 5, 1 };
            List<int> int02 = new List<int> { 4, 5, 6, 7, 8 };

            var except = int01.Except(int02);
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
        }

        public void Intersect()
        {
            List<int> int01 = new List<int> { 1, 2, 3, 4, 5, 4, 5, 1 };
            List<int> int02 = new List<int> { 4, 5, 6, 7, 8 };

            var intersect = int01.Intersect(int02);
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
        }


        public void UnionBy()
        {
            List<StudentCourse> sc01 = new List<StudentCourse>
            {
                new StudentCourse{Id = 1},
                new StudentCourse{Id = 2},
                new StudentCourse{Id = 3},
                new StudentCourse{Id = 3},

            };

            List<StudentCourse> sc02 = new List<StudentCourse>
            {
                new StudentCourse{Id = 2},
                new StudentCourse{Id = 4},
                new StudentCourse{Id = 5},
                new StudentCourse{Id = 6},

            };

            var result = sc01.UnionBy(sc02,c=>c.Id);

            var result2 = sc01.Union(sc02);
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }
        }


        public void DistinctBy()
        {
            List<StudentCourse> sc01 = new List<StudentCourse>
            {
                new StudentCourse{Id = 1},
                new StudentCourse{Id = 2},
                new StudentCourse{Id = 3},
                new StudentCourse{Id = 3},

            };

            var result = sc01.DistinctBy(c=>c.Id);
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }
        }

        public void IntersectBy()
        {
            List<StudentCourse> sc01 = new List<StudentCourse>
            {
                new StudentCourse{Id = 1},
                new StudentCourse{Id = 2},
                new StudentCourse{Id = 3},
                new StudentCourse{Id = 3},

            };

            List<StudentCourse> sc02 = new List<StudentCourse>
            {
                new StudentCourse{Id = 2},
                new StudentCourse{Id = 4},
                new StudentCourse{Id = 5},
                new StudentCourse{Id = 6},

            };

            var result = sc01.IntersectBy(new int[] {1,3}, c => c.Id);
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }
        }


        public void ExceptBy()
        {
            List<StudentCourse> sc01 = new List<StudentCourse>
            {
                new StudentCourse{Id = 1},
                new StudentCourse{Id = 2},
                new StudentCourse{Id = 3},
                new StudentCourse{Id = 3},

            };

            List<StudentCourse> sc02 = new List<StudentCourse>
            {
                new StudentCourse{Id = 2},
                new StudentCourse{Id = 4},
                new StudentCourse{Id = 5},
                new StudentCourse{Id = 6},

            };

            var result = sc01.ExceptBy(new int[] {1,3}, sc => sc.Id);
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }
        }

        public void Zip()
        {
            List<int> int01 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> int02 = new List<int> { 6, 7, 8,9,10 };
            List<int> int03 = new List<int> { 11, 12, 13 };

            var result = int01.Zip(int02, int03);
        }

        public void Pagination(int pageIndex = 0, int pageCount=3)
        {
            List<int> int01 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15 };
            
            var result = int01.Skip(pageCount * pageIndex).Take(pageCount);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void Chunk(int chuncSize=3)
        {
            List<int> int01 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var result = int01.Chunk(chuncSize);
        }

        public void AggregateFunctions()
        {
            var students = Student.GetStudents();
            
            var m = students.MinBy(c=>c.Grade);
            var totalCount = students.Count();
            var minValue = students.Min(c=>c.Grade);
            var maxValue = students.Max(c=>c.Grade);
            var avg = students.Average(c=>c.Grade);
            var sum = students.Sum(c=>c.Grade);

            Console.WriteLine($"Total Count:{totalCount}, Min Grade:{minValue},Max Grade:{maxValue},Avg Grade:{avg},Sum Grade:{sum}");
        }

        public void Generators()
        {
            var numberRange = Enumerable.Range(0, 100).ToList();

            var emptyNumber = Enumerable.Empty<int>().ToList();

            var repeat = Enumerable.Repeat<int>(1,100).ToList();    

        }
    }
}
