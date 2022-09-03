using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace FiltersSamples.Filters;

public class MyHttpsAttribute : Attribute,IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        if(!context.HttpContext.Request.IsHttps)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
        }

    }
}
