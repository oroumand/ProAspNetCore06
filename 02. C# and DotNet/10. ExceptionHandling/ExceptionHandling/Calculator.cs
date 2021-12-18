using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class Calculator
    {
        public void Add(int number01, int number02)
        {
            if (number01 < 1)
                throw new ArgumentException();
            if (number02 < 1)
                throw new InvalidOperationException();

            int result = number01 + number02;
            Console.WriteLine(result);
        }
    }
}
