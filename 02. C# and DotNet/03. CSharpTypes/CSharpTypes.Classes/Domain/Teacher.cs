using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTypes.Classes.Domain
{
    public class Teacher
    {
        public string FiratName { get; set; }
        public string LastName { get; set; }

        public  string GetFullName(Teacher teacher)
        {
            return $"{teacher.FiratName},  {teacher.LastName}";
        }
    }
}
