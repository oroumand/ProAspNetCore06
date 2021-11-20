using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTypes.Records
{
    public record PersonRecord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public record PersonRecord2(int Id, string FirstName, string LastName)
    {
        public string GetFullName()
        {
            return $"{FirstName}, {LastName}";
        }
    };

    public class PersonClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
