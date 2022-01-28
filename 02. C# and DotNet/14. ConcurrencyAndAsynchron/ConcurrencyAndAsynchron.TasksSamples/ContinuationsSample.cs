using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.TasksSamples;
public class ContinuationsSample
{
    public void Start()
    {
        Task<int> sumResult = Task.Run(() => Sum(100, 200));
        var awaiter = sumResult.GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            var result = awaiter.GetResult();
            Console.WriteLine($"Sum result is: {result}");
        });
        Console.WriteLine("Finished!");
        Console.ReadLine();

    }

    public void Start2()
    {
        Task<int> sumResult = Task.Run(() => Sum(100, 200));
        sumResult.ContinueWith(t => Console.WriteLine("After sum result"));
        Console.ReadLine();
    }


    public int Sum(int num1, int num2)
    {
        Console.WriteLine("Sum");
        Thread.Sleep(3000);
 
        return num1 + num2;
    }
}
