using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersSamples.Filters;

public class ResultTimer:ResultFilterAttribute
{
    private readonly Stopwatch _stopWatch = new();
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        _stopWatch.Start();
        Console.WriteLine($"Result {context.ActionDescriptor.DisplayName} Start executeing");
    }

    public override void OnResultExecuted(ResultExecutedContext context)
    {
        _stopWatch.Stop();
        Console.WriteLine($"Result {context.ActionDescriptor.DisplayName} Start executed. time: {_stopWatch.ElapsedMilliseconds} ms");
    }
}
