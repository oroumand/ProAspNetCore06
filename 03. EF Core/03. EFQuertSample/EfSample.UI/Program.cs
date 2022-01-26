using EfSample.Dal;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();
optionBuilder.UseSqlServer("Server=.;Database=CourseDb;User Id=sa; Password=1qaz!QAZ");
//optionBuilder.LogTo(Console.WriteLine);
using CourseStoreDbContext ctx = new CourseStoreDbContext(optionBuilder.Options);
//var courses = ctx.Courses.AsNoTrackingWithIdentityResolution().Include(c=>c.CourseTeachers).ThenInclude(c=>c.Teacher).ToList();

//var t1c1 = courses.Where(c=>c.CourseId == 1).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
//var t1c2 = courses.Where(c=>c.CourseId == 2).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
//var t1c3 = courses.Where(c=>c.CourseId == 3).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
//Console.WriteLine(Object.ReferenceEquals(t1c1,t1c2));
//Console.WriteLine(Object.ReferenceEquals(t1c1, t1c3));
//Console.WriteLine(Object.ReferenceEquals(t1c2, t1c3));

var repo = new TipsAndTricksSamples(ctx);
repo.AddNewCourse("Sample", "Sample Description");
Console.ReadKey();



