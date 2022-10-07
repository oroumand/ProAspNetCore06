using AAASamples.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AAASamples.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<CostumIdentityUser> _signInManager;

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string? ReturnUrl { get; set; }
        public LoginModel(SignInManager<CostumIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserName, Password, false, false);
                if(result.Succeeded)
                {
                    return Redirect(ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Invalid user name or password");
            }
            return Page();
        }
    }
}
