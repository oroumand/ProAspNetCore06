using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class BinaryOperators
    {
        public  void And()
        {
            int a = 0b011;
            int b = 0b010;
            Console.WriteLine(a);
            Console.WriteLine(b);


            var c = a & b;
            Console.WriteLine(c);
        }


        public void Or()
        {
            int a = 0b011;
            int b = 0b010;
            Console.WriteLine(a);
            Console.WriteLine(b);


            var c = a | b;
            Console.WriteLine(c);
        }
        public void xOr()
        {
            int a = 0b011;
            int b = 0b010;
            Console.WriteLine(a);
            Console.WriteLine(b);


            var c = a ^ b;
            Console.WriteLine(c);
        }
        public void Revers()
        {
            int a = 0b011;
            int b = 0b010;
            Console.WriteLine(a);
            Console.WriteLine(b);


            var c = ~b;
            Console.WriteLine(c);
        }

        public void Shift()
        {
            var a = 0b1;

            Console.WriteLine(a);

            var c = a << 1;
            var d = a << 2;
            var e = a << 3;
            var f = a << 4;

            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);
        }
    }
}
