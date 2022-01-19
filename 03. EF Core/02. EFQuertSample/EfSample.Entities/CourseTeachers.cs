namespace EfSample.Entities;

public class CourseTeachers
{
    public int CourseTeachersId { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public int SortOrder { get; set; }
}
