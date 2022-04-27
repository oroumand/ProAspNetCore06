using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Framework;

namespace CourseStore.Model.Teachers.Entities;

public class Teacher : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<CourseTeacher> CourseTeachers { get; set; }

}
