namespace UrlRoutingSamples.Middleware;

public class TarzeTahie
{
    private readonly RequestDelegate _next;

    public TarzeTahie(RequestDelegate next)
    {
        _next = next;
    }
    public TarzeTahie()
    {

    }
    public async Task InvokeAsync(HttpContext context)
    {
        //www.eeee.com/mv/Nimroo
        //www.eeee.com/mv/Omlet
        //www.eeee.com/mv/NoonPanir
        //var path = context.Request.Path.ToString();
        //var pathSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        string mavadeLazem = string.Empty;
        //if (pathSegments.Length == 2 && pathSegments[0] == "tt")
        //{
        // switch (pathSegments[1])
        var name = context.Request.RouteValues["name"].ToString();    
        switch (name)
            {
                case "Nimroo":
                    mavadeLazem = "Roghan+Namak+Tokhme Morgh";
                    break;
                case "Omlet":
                    mavadeLazem = "Roghan+Namak+Tokhme Morgh+Goje";
                    break;
                case "NoonPanir":
                    mavadeLazem = "Noon+Panir";
                    break;
                case "Kotlet":
                LinkGenerator? generator = context.RequestServices.GetService<LinkGenerator>();
                string? url = generator?.GetPathByRouteValues(context,
                "mv", new { name = "Nimroo" });


                context.Response.Redirect(url);
                    return;
            }
            if (!string.IsNullOrEmpty(mavadeLazem))
            {
                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(mavadeLazem);
            }
        //}
        if (_next != null)
            await _next(context);
    }
}
