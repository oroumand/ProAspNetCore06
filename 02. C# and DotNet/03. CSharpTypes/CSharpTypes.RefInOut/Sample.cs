using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTypes.RefInOut
{
    public class Sample
    {
        public void Caller01()
        {
            int myValue = 1;
            Console.WriteLine(myValue);
            Callee01(ref myValue);
            Console.WriteLine(myValue);

        }

        public void Callee01(ref int input)
        {
            input++;
        }


        public void Caller02()
        {
            int myValue = 0;
            Console.WriteLine(myValue);
            Callee02(out myValue);
            Console.WriteLine(myValue);

        }


        public void Callee02(out int input)
        {
            input = 3;
        }



        public void Caller03()
        {
            int myValue = 1;
            Console.WriteLine(myValue);
            Callee03(in myValue);
            Console.WriteLine(myValue);

        }

        public void Callee03(in int input)
        {
            
        }
    }
}
