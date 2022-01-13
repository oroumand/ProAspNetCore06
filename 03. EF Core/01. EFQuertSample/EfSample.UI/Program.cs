using EfSample.Dal;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();
optionBuilder.UseSqlServer("Server=.;Database=CourseDb;User Id=sa; Password=1qaz!QAZ");
//optionBuilder.LogTo(Console.WriteLine);
using CourseStoreDbContext ctx = new CourseStoreDbContext(optionBuilder.Options);
CourseStoreRepository repository = new CourseStoreRepository(ctx);

repository.Paging();




Console.ReadKey();



