using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAASamples.Pages.Account
{
    public class LoginCookieModel : PageModel
    {
        public string CookieValue { get; set; }
        public void OnGet()
        {
            if(Request.Cookies.ContainsKey(".AspNetCore.Identity.Application"))
            {
                CookieValue = Request.Cookies[".AspNetCore.Identity.Application"];
            }
            else
            {
                CookieValue = "There is no cookie";
            }
        }
    }
}
