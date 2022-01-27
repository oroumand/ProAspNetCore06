using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.ThreadSample;
public class SharedAndLocalState
{
    bool allowWrite = true;
    private readonly static object _locker = new object();
    public void Start()
    {
        Thread first = new Thread(safeCheckSharedState);
        Thread seccond = new Thread(safeCheckSharedState);
        first.Name = "First";
        seccond.Name = "Seccond";
        seccond.Start();
        first.Start();

        Console.Read();
    }

    public void PrintStar()
    {
        int counter = 10;
        for (int i = 0; i < counter; i++)
        {
            Console.Write("*");
        }
    }

    public void checkSharedSate()
    {
        if(allowWrite)
        {            
            Console.WriteLine("This is My message");
            allowWrite = false;
        }
    }
    public void safeCheckSharedState()
    {
        lock (_locker)
        {
            
            Console.WriteLine($"Befor Locker Thread name is {Thread.CurrentThread.Name}");
            if (allowWrite)
            {
                Console.WriteLine($"Locker Thread name is {Thread.CurrentThread.Name}");
                Console.WriteLine("This is My message");
                allowWrite = false;
            }
            Console.WriteLine($"After Locker Thread name is {Thread.CurrentThread.Name}");
        }
        Console.WriteLine(Thread.CurrentThread.Name);
    }
}
