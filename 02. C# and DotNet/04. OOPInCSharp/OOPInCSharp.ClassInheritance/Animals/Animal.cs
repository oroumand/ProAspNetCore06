using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInCSharp.ClassInheritance.Animals
{
    public abstract class Animal
    {
        public virtual void Voice()
        {
            Console.WriteLine("My Animal Voice");
        }

        public abstract void Feed();
    }

    public class Cat : Animal
    {
        public override void Feed()
        {
            Console.WriteLine("Milk");
        }

        public override void Voice()
        {
            base.Voice();
            Console.WriteLine("Mio");
        }
    }


    public class Dog : Animal
    {
        public override void Feed()
        {
            Console.WriteLine("Meet");
        }
        public override void Voice()
        {
            Console.WriteLine("Hap");
            base.Voice();
        }
    }


    public class Caw : Animal
    {
        public override void Feed()
        {
            Console.WriteLine("Yonjeh");
        }
    }
}
