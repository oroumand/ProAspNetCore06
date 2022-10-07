using AAASamples.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AAASamples.Pages.Users
{
    [Authorize(Roles ="Admin")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<CostumIdentityUser> _userManager;

        public CreateModel(UserManager<CostumIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]

        public string Name { get; set; }
        [BindProperty]
        public string Family { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                CostumIdentityUser user = new()
                {
                    UserName = UserName,
                    Email = Email,
                    Name = Name,
                    Family = Family
                };

                IdentityResult result = await _userManager.CreateAsync(user,Password);
                if(result.Succeeded)
                {
                    return RedirectToPage("List");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return Page();
        }
    }
}
