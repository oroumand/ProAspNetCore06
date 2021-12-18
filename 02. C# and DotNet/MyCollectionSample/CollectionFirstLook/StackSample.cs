using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFirstLook
{
    public class StackSample
    {
        Stack<string> stack = new Stack<string>();

        public static void Start()
        {
            var stack = new StackSample();
            stack.Add("1");
            stack.Add("2"); 
            stack.Add("3");
            Console.WriteLine(stack.Get());
            Console.WriteLine(stack.Get());
            Console.WriteLine(stack.Get());
            Console.ReadLine();
        }
        public void Add(string input)
        {
            stack.Push(input);
        }

        public string Get()
        {
            return stack.Pop();
        }
    }
}
