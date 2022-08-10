using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ValidationSamples.Models;

namespace ValidationSamples.Controllers;
public class PersonController : Controller
{
    private readonly ValidationDbContext _dbContext;

    public PersonController(ValidationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        var people = _dbContext.People.ToList();
        return View(people);
    }

    public IActionResult Save()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Save(SavePersonVm model)
    {
        if (ModelState.IsValid)
        {
            _dbContext.People.Add(new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        ModelState.AddModelError("","There is a model level validation");
        return View(model);
    }
    public IActionResult ExplicitSave()
    {
        return View();
    }
    [HttpPost]
    public IActionResult ExplicitSave(SavePersonVm model)
    {
        List<string> validationText = new List<string>();
        if (string.IsNullOrEmpty(model.FirstName))
        {
            validationText.Add("FirstName is required");
        }
        if (string.IsNullOrEmpty(model.LastName))
        {
            validationText.Add("LastName is required");
        }
        if (model.FirstName?.Length > 20)
        {
            validationText.Add("Max Lenght of FirstName is 20");

        }
        if (model.LastName?.Length > 20)
        {
            validationText.Add("Max Lenght of LastName is 20");

        }
        if (!validationText.Any())
        {
            _dbContext.People.Add(new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        TempData["Validation"] = validationText;
        return View(model);
    }

    public bool CheckName(string userName)
    {
        if(userName.Length > 5)
        {
            return true;
        }
        return false;
    }
}
