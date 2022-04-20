using CourseStore.DAL.Contexts;
using CourseStore.DAL.Entities;

namespace CourseStore.BusinessLogic;
public class CourseServices
{
    private readonly CourseStoreDbContext _dbContext;

    public CourseServices(CourseStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Course> GetAllCourse()
    {
        return _dbContext.Courses.ToList();
    }
}
