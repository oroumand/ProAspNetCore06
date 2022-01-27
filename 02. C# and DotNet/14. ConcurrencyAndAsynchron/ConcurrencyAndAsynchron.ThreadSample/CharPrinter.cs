using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.ThreadSample;
public class CharPrinter
{

    public void PrintStar()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("*");
            Thread.Yield();
        }
    }

    public void PrintDash()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("-");
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }      
    }
}
