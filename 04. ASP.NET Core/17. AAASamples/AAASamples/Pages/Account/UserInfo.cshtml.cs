using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAASamples.Pages.Account
{
    [Authorize]
    public class UserInfoModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
