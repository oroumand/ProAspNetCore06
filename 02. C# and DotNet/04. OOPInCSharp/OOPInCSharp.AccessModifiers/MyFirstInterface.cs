using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInCSharp.AccessModifiers
{
    public interface MyFirstInterface
    {
        public void Test();
        void Temp();
    }
    public interface MyFirstInterface2
    {
        void sample();
        void Temp();
    }
    public class MyFirstInterfaceImpl : MyFirstInterface, MyFirstInterface2
    {
        public void sample()
        {
            throw new NotImplementedException();
        }

        public void Temp()
        {
            Console.WriteLine("Temp01");
        }

        void MyFirstInterface.Test()
        {
            Console.WriteLine("Test01");
        }

        void MyFirstInterface2.Temp()
        {

        }

    }
}
