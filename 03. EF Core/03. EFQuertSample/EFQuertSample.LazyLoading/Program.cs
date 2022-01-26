
using EFQuertSample.LazyLoading;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<LazyDbContext>();
optionBuilder.UseSqlServer("Server=.;Database=LazyLoadingDb;User Id=sa; Password=1qaz!QAZ;MultipleActiveResultSets=true");
optionBuilder.UseLazyLoadingProxies();
optionBuilder.LogTo(Console.WriteLine);
using LazyDbContext ctx = new LazyDbContext(optionBuilder.Options);

var people = ctx.People;

foreach (var person in people)
{
    Console.WriteLine("".PadLeft(100,'*'));
    Console.WriteLine($"{person.Id},{person.Name}");
    foreach (var address in person.Addresses)
    {
        Console.WriteLine($"{address.Id},{address.City}");
    }

    Console.WriteLine("".PadLeft(100, '='));
}
