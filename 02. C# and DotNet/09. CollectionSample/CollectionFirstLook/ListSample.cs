using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFirstLook
{
    public class ListSample
    {
        List<string> vs = new List<string>(10);

        public void Start()
        {

            ListSample ls = new ListSample();
            ls.PrintCapacityAndCount();

            Console.ReadKey();
            ls.AddMember("1");
            ls.PrintCapacityAndCount();
            Console.ReadKey();
            ls.AddMember("2");
            ls.PrintCapacityAndCount();
            Console.ReadKey();
            ls.AddMember("3");
            ls.PrintCapacityAndCount();
            Console.ReadKey();
            ls.AddMember("4");
            ls.PrintCapacityAndCount();
            Console.ReadKey();
            ls.AddMember("5");
            ls.PrintCapacityAndCount();
            Console.ReadKey();
            ls.Ensure();
            ls.PrintCapacityAndCount();
            Console.ReadKey();

            for (int i = 0; i < 12; i++)
            {
                ls.AddMember(i.ToString());
            }
            ls.PrintCapacityAndCount();
            Console.ReadKey();
            ls.Trim();
            ls.PrintCapacityAndCount();

            var readOnlyList = ls.GetReadOnly();

        }
        public void PrintCapacityAndCount()
        {           
            Console.WriteLine($"Capacity is :{vs.Capacity}");
            Console.WriteLine($"Count is :{vs.Count}");

        }

        public void PrintCount()=>
             Console.WriteLine($"Capacity is :{vs.Count}");

        public void AddMember(string input)
        {
            vs.Add(input);
            vs.AddRange(new string[] {"1","2","3"});
        }
        public void Remove()
        {
            vs.Remove("1");
            vs.RemoveAll(c=> c.StartsWith("1"));
            vs.RemoveAt(12);
            vs.RemoveRange(2, 4);
            vs.Clear();
        }
        public void Insert()
        {
            vs.Insert(5, "Salam");
        }

        public void Find()
        {
            var result = vs.Find(c=>c.StartsWith("1"));
            var resultList = vs.FindAll(c=>c.StartsWith("2"));
        }
        public void Ensure()
        {
            vs.EnsureCapacity(20);
        }

        public void Trim()
        {
            vs.TrimExcess();
        }

        public IReadOnlyList<string> GetReadOnly()
        {
            return vs.AsReadOnly();
        }
    }
}
