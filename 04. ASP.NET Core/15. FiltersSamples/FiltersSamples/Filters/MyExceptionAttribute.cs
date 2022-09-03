using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSamples.Filters;

public class MyExceptionAttribute : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        
    }
}
