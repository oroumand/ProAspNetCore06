using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTypes.Tupples
{
    public class TestTuple
    {
        public void TupleSamle()
        {
            (int Id, string FirstName, string LastName) person = (1, "Alireza", "Oroumand");


            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);


        }



        public (int Id, string FirstName, string LastName) ReturnTuple()
        {
            return (1, "Alireza", "Oroumand");
        }

        public void CallReturnTuple()
        {
            var person = ReturnTuple();


            
        }


        public void CallReturnTupleDecons()
        {
            (int Id, string FirstName, string LastName) = ReturnTuple();


            Console.WriteLine(Id);
            Console.WriteLine(FirstName);
        }

    }
}
