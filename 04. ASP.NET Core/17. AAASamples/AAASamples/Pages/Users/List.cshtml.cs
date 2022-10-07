using AAASamples.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace AAASamples.Pages.Users
{
    public class ListModel : PageModel
    {
        private readonly UserManager<CostumIdentityUser> _userManager;
        public IEnumerable<CostumIdentityUser> Users { get; set; } = Enumerable.Empty<CostumIdentityUser>();
        public ListModel(UserManager<CostumIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
            Users = _userManager.Users.ToList();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToPage();
        }
    }
}
