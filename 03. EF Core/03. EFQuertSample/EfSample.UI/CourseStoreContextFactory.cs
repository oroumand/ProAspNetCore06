using EfSample.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfSample.UI;
public class CourseStoreContextFactory : IDesignTimeDbContextFactory<CourseStoreDbContext>
{
    public CourseStoreDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();
        optionBuilder.UseSqlServer("Server=.;Database=CourseDb;User Id=sa; Password=1qaz!QAZ");

        CourseStoreDbContext ctx = new CourseStoreDbContext(optionBuilder.Options);
        return ctx;
    }
}
