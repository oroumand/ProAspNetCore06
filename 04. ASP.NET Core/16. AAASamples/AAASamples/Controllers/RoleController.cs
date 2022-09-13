using AAASamples.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AAASamples.Controllers;
public class RoleController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    public IActionResult List()
    {
        var roles = _roleManager.Roles.ToList();
        return View(roles);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var identityRole = new IdentityRole(model.Name);
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return RedirectToAction("List");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string Name)
    {
        var role = await _roleManager.FindByNameAsync(Name);
        if (role != null)
        {
            var result =
                 await _roleManager.DeleteAsync(role);
            //if(!result.Succeeded)
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError("", item.Description);
            //    }
            //}
        }

        return RedirectToAction("List");
    }


    public async Task<IActionResult> Edit(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        return View(role);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(IdentityRole model)
    {
        if (ModelState.IsValid)
        {
            var identityRole = await _roleManager.FindByIdAsync(model.Id);
            if (identityRole != null)
            {
                identityRole.Name = model.Name;
                var result = await _roleManager.UpdateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }

        return View(model);
    }
}
