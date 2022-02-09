using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.AsyncSamples;
public class Sample02
{
    public async Task Start()
    {
        var taskFinal = FinalResultCaller();
        await taskFinal;
    }
    public async Task FinalResultCaller()
    {
        var resultTask =  FinalResult(2);
        var result = await resultTask;
        Console.WriteLine($"Result is {result}");

    }
    public Task<int> FinalResult(int sleepFor)
    {
        return Task.Run(async () =>
        {
            await Task.Delay(sleepFor * 1000);
            return 10;
        });
    }

    public async Task Print(string message)
    {
        await Task.Delay(3000);
        Console.WriteLine(message);
    }

    public async Task PrintAfter20Sec(string message,CancellationToken cancellationToken)
    {
        await Task.Delay(20000, cancellationToken);
        Console.WriteLine(message);
    }

    public async Task PrintAfter3()
    {
        await Task.Delay(3000);
        Console.WriteLine("Print After 3 Finished");
    }

    public async Task PrintAfter4()
    {
        await Task.Delay(4000);
        Console.WriteLine("Print After 4 Finished");
    }

    public async Task PrintAfter5()
    {
        await Task.Delay(5000);
        Console.WriteLine("Print After 5 Finished");
    }
}
