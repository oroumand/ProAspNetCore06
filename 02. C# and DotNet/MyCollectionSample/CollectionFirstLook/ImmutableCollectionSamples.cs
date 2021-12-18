using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
namespace CollectionFirstLook
{
    public class ImmutableCollectionSamples
    {
        public void Test()
        {

            ImmutableList<string> list = ImmutableList.Create<string>();
            Console.WriteLine(list.Count);
            var result = list.Add("hi").Add("hi").Add("hi");
            Console.WriteLine(list.Count);
            Console.WriteLine(result.Count);
            Console.ReadLine();

        }
    }
}
