using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFirstLook
{
    public class DictionarySample
    {
        Dictionary<string,string> dictionary = new Dictionary<string, string>();

        SortedDictionary<string, string> sorted = new SortedDictionary<string, string>();
        public void Add(string key,string value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary[key] = value;       
            
            if(sorted.ContainsKey(key))
                sorted[key] = value;
        }

        public string Get(string key)=> dictionary[key];

        public void PrintAll()
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Value of {item.Key} is {item.Value}");
            }
        }
    }
}
