using DependencyInjectionSample.DI;

namespace DependencyInjectionSample.SampleMiddleware;

public class TestMiddleware
{
    private readonly RequestDelegate _next;

    public TestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IScopeDependency scopeDependency)
    {
        int a = 123;
    }
}


public class TestMiddlewareWithInjectino:IMiddleware
{
    private readonly IScopeDependency _scopeDependency;

    public TestMiddlewareWithInjectino(IScopeDependency scopeDependency)
    {
        _scopeDependency = scopeDependency;
    }



    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        int a = 123;

    }
}
