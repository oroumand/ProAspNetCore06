using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.AsyncSamples;
public class CancelationSample
{
    public async void CancelSampel()
    {
        var sample02 = new Sample02();
        CancellationTokenSource cts = new CancellationTokenSource();
        var task = sample02.PrintAfter20Sec("My Message", cts.Token);

        Console.WriteLine("If you want to cancel the task press c");
        string cancelResult = Console.ReadLine();
        if (cancelResult == "c")
        {
            cts.Cancel();
        }

        try
        {
            await task;
        }
        catch (TaskCanceledException ex)
        {
            var status = task.Status;
            var isCanceld = task.IsCanceled;
            Console.WriteLine($"Is Cancel :{isCanceld} and status is :{status}");
            Console.WriteLine(ex.Message);
        }
    }
}
