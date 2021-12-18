using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFirstLook
{
    public class SetSample
    {
        HashSet<string> set = new HashSet<string>();

        public void Start()
        {
            SetSample ss = new SetSample();
            ss.Add("01");
            ss.Add("02");
            ss.Add("03");
            ss.Print();
            Console.ReadLine();
            ss.Add("02");
            ss.Add("03");
            ss.Print();
            Console.ReadLine();
        }
        public void Add(string input)
        {            
            set.Add(input);
        }

        public void Print()
        {
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }

        public void Operators()
        {
            HashSet<string> newSet = new HashSet<string>();
            newSet.Add("01");

            newSet.ExceptWith(set);

            newSet.Union(set);

            newSet.IsSubsetOf(set);

            newSet.IsSubsetOf(set);




        }
    }
}
