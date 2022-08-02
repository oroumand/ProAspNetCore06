using ControllersWithViewSamples.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControllersWithViewSamples.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PeopleContext _peopleContext;
        public List<Person> People { get; set; }
        public IndexModel(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }
        public void OnGet(int count = 1)
        {
            People = _peopleContext.People.Take(count).ToList();
        }

        public string GetDateTimeAsString() => DateTime.Now.ToLongTimeString();
    }
}
