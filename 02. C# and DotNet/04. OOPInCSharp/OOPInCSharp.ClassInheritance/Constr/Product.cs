using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInCSharp.ClassInheritance.Constr
{
    public class Product
    {
        //public Product()
        //{
        //    Console.WriteLine("new instance of Product Created");
        //}
        public Product(string model)
        {
            Console.WriteLine($"new instance of Product model {model} Created");
        }
    }

    public class Mobile:Product
    {
        public Mobile():base("DefaultModel")
        {
            Console.WriteLine("new instance of Mobile Created");
        }

        public Mobile(string model):base(model)
        {
            Console.WriteLine($"new instance of Mobile model {model} Created");
        }
    }
}
