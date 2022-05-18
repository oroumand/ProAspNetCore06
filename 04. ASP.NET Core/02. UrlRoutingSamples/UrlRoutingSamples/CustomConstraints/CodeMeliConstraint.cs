namespace UrlRoutingSamples.CustomConstraints;

public class CodeMeliConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, 
        RouteValueDictionary values, RouteDirection routeDirection)
    {
        var value = values[routeKey].ToString();
        if(!string.IsNullOrEmpty(value) && value.Length == 10)
            return true;

        return false;
    }
}
