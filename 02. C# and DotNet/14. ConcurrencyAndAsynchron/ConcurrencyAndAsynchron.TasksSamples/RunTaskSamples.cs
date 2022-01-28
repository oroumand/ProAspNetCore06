using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.TasksSamples;
public class RunTaskSamples
{
    public void Start()
    {
        Task result = Task.Run(() => PrintName());
        Console.WriteLine("---- Finished ----");
        Console.WriteLine($"Task Satatus= {result.Status}");
        result.Wait();
        Console.WriteLine($"Task Satatus After wait= {result.Status}");
    }

    public void StartLongRunning()
    {
        Task result = Task.Factory.StartNew(() => PrintName(),TaskCreationOptions.LongRunning);
        Console.WriteLine("---- Finished ----");
        Console.WriteLine($"Task Satatus= {result.Status}");
        result.Wait();
        Console.WriteLine($"Task Satatus After wait= {result.Status}");
    }
    public void StartColdTask()
    {
        Task result = new Task(PrintName);
        Console.WriteLine($"Task Satatus befor start= {result.Status}");
        result.Start();
        Console.WriteLine("---- Finished ----");
        Console.WriteLine($"Task Satatus= {result.Status}");
        result.Wait();
        Console.WriteLine($"Task Satatus After wait= {result.Status}");
    }
    public void PrintName()
    {
        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
        Console.WriteLine(Thread.CurrentThread.IsBackground);
        Thread.Sleep(3000);
        Console.WriteLine("Alireza Oroumand");        
    }
}
