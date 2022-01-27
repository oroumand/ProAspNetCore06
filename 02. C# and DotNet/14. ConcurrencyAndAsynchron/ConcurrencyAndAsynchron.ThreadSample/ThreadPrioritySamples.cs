using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.ThreadSample;
public class ThreadPrioritySamples
{
    public void Start()
    {
        Thread T1 = new(() => ThreadPrinter("*"));
        T1.Priority = ThreadPriority.Highest;
        Thread T2 = new(() => ThreadPrinter("-"));
        Thread T3 = new(() => ThreadPrinter("="));
        T3.Priority = ThreadPriority.Lowest;
        T1.Start();
        T2.Start();
        T3.Start();

    }

    public void ThreadPrinter(string input)
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.Write(input);
        }
    }
}
