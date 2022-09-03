using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersSamples.Filters;

public class FilterOrderAttribute:ActionFilterAttribute
{
    public string Name { get; set; }
    public FilterOrderAttribute(string name)
    {
        Name = name;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine(Name + "Executing");
    }
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine(Name + "Executed");
    }
}
public class ActionTimerAttribute : ActionFilterAttribute
{
    private readonly Stopwatch _stopWatch = new();
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(context.ActionArguments.ContainsKey("temp"))
        {
            Console.WriteLine(context.ActionArguments["temp"]);
        }

        _stopWatch.Start();
        Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} Start executeing");
    }
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        
    }

    public override void OnResultExecuted(ResultExecutedContext context)
    {
        _stopWatch.Stop();
        Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} Start executed. time: {_stopWatch.ElapsedMilliseconds} ms");
    }

}
