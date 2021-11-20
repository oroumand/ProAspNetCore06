using CSharpTypes.Classes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTypes.Classes.Extentions
{
    public static class TeacherExtention
    {
        public static string GetFullName(this Teacher teacher)
        {
            return $"{teacher.FiratName},  {teacher.LastName}";
        }
    }
}
