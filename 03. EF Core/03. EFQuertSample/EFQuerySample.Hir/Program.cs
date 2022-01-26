using EFQuerySample.Hir;
using Microsoft.EntityFrameworkCore;

var context = new EmpContext();

//var emploies = context.Employes.Include(c=>c.Children).ToList().Where(c=>!c.ParentId.HasValue).FirstOrDefault();
//var types = context.Type01s.AsSplitQuery().Include(c => c.Type02s).ThenInclude(c => c.Type03s).ToList();

var person = context.People.Include(c=>c.Addresses).ToList();
context.ChangeTracker.Clear();
Console.ReadLine();