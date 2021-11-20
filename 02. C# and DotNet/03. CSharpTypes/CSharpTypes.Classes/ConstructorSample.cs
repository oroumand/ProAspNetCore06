using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTypes.Classes
{
    public class ConstructorSample
    {
        private readonly int age;
        private readonly string name;

        public static int Counter;
        public ConstructorSample():this(5)
        {
            name = "Alireza";
        }

        public ConstructorSample(int age)
        {
            this.age = age;
        }

        static ConstructorSample()
        {
            Counter = 10;
        }



    }
}
