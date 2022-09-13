using AAASamples.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AAASamples.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserManager<CostumIdentityUser> _userManager;

        public EditModel(UserManager<CostumIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Family { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
        public async Task OnGet(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            Name = user.Name;
            Family = user.Family;
            UserName = user.UserName;
            Email = user.Email;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(Id);
                user.Name = Name;
                user.Family = Family;
                user.UserName = UserName;
                user.Email = Email;
                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded && !string.IsNullOrEmpty(Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    result = await _userManager.AddPasswordAsync(user, Password);
                }
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
