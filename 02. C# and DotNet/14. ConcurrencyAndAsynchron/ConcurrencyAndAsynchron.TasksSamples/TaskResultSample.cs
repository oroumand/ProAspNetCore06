using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.TasksSamples;
public class TaskResultSample
{
    public void Start()
    {
        Task<int> result = Task.Run(() => Add(100, 200));
        Console.WriteLine(result.Status);
        var sum = result.Result;
        Console.WriteLine(result.Status);
        Console.WriteLine(sum.ToString());
        Console.WriteLine("Finished");
    }

    public int Add(int num01,int num02)
    {
        Thread.Sleep(2000);
        return num01 + num02;
    }
}
