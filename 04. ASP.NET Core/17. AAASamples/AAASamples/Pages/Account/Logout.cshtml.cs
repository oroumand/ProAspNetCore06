using AAASamples.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAASamples.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<CostumIdentityUser> _signInManager;

        public LogoutModel(SignInManager<CostumIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
