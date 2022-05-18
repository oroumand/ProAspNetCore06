namespace UrlRoutingSamples.Middleware;

public class MavadeLazem
{
    private readonly RequestDelegate _next;

    public MavadeLazem(RequestDelegate next)
    {
        _next = next;
    }
    public MavadeLazem()
    {

    }
    public async Task InvokeAsync(HttpContext context)
    {
        //www.eeee.com/mv/Nimroo
        //www.eeee.com/mv/Omlet
        //www.eeee.com/mv/NoonPanir
        //var path = context.Request.Path.ToString();
       // var pathSegments = path.Split('/',StringSplitOptions.RemoveEmptyEntries);
        string mavadeLazem = string.Empty;
        //if(pathSegments.Length == 2 && pathSegments[0] == "mv")
        //{
        var name = context.Request.RouteValues["name"]; 
            //switch (pathSegments[1])
            switch (name)
            {
                case "Nimroo":
                    mavadeLazem = "Roghan, Namak, Tokhme Morgh";
                    break;
                case "Omlet":
                    mavadeLazem = "Roghan, Namak, Tokhme Morgh, Goje";
                    break;
                case "NoonPanir":
                    mavadeLazem = "Noon, Panir";
                    break;
            }
            if(!string.IsNullOrEmpty(mavadeLazem))
            {
                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(mavadeLazem);
            }
       // }
        if(_next != null)
            await _next(context);
    }
}


public class CheckEndpoint
{
    private readonly RequestDelegate _next;

    public CheckEndpoint(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        if(endpoint != null)
        {
            await context.Response.WriteAsync(endpoint.DisplayName);
        }
        if (_next != null)
            await _next(context);
    }
}

