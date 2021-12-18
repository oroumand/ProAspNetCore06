using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class MyCustomException:Exception
    {
        public MyCustomException()
        {
        }

        public MyCustomException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public DateOnly MyDate { get; set; }
        public TimeOnly MyTime { get; set; }
    }
}
