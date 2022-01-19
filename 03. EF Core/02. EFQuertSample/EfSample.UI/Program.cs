using EfSample.Dal;
using Microsoft.EntityFrameworkCore;
using EfSample.UI;


var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();
optionBuilder.UseSqlServer("Server=.;Database=CourseDb;User Id=sa; Password=1qaz!QAZ");
//optionBuilder.LogTo(Console.WriteLine);
using CourseStoreDbContext ctx = new CourseStoreDbContext(optionBuilder.Options);
CourseStoreCommandRepository  repository = new CourseStoreCommandRepository(ctx);

repository.DeleteTag(2006);

Console.ReadKey();



