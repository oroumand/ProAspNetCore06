using EfSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSample.Dal;
public class TipsAndTricksSamples
{
    private readonly CourseStoreDbContext _ctx;

    public TipsAndTricksSamples(CourseStoreDbContext ctx)
    {
        _ctx = ctx;
    }
    public void AsNoTrackingSample()
    {
        var courses = _ctx.Courses.AsNoTracking().Include(c => c.CourseTeachers).ThenInclude(c => c.Teacher).ToList();

        var t1c1 = courses.Where(c => c.CourseId == 1).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
        var t1c2 = courses.Where(c => c.CourseId == 2).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
        var t1c3 = courses.Where(c => c.CourseId == 3).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
        Console.WriteLine(Object.ReferenceEquals(t1c1, t1c2));
        Console.WriteLine(Object.ReferenceEquals(t1c1, t1c3));
        Console.WriteLine(Object.ReferenceEquals(t1c2, t1c3));
    }
    public void AsNoTrackingWithIdentityResolutionSample()
    {
        var courses = _ctx.Courses.AsNoTrackingWithIdentityResolution().Include(c => c.CourseTeachers).ThenInclude(c => c.Teacher).ToList();

        var t1c1 = courses.Where(c => c.CourseId == 1).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
        var t1c2 = courses.Where(c => c.CourseId == 2).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
        var t1c3 = courses.Where(c => c.CourseId == 3).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
        Console.WriteLine(Object.ReferenceEquals(t1c1, t1c2));
        Console.WriteLine(Object.ReferenceEquals(t1c1, t1c3));
        Console.WriteLine(Object.ReferenceEquals(t1c2, t1c3));
    }

    public void AddNewCourse(string name, string description)
    {
        var teacher = _ctx.Teachers.FirstOrDefault();
        var courseTeacher = new CourseTeachers
        {
            Teacher = teacher
        };
        var course = new Course
        {
            Name = name,
            Description = description,
            CourseTeachers = new List<CourseTeachers>()
            {
                courseTeacher
            },
            Price = 1000
        };
        Console.WriteLine(_ctx.Entry(course).Property(c=>c.CourseId).CurrentValue);
        _ctx.Courses.Add(course);
        Console.WriteLine(_ctx.Entry(course).Property(c => c.CourseId).CurrentValue);
        _ctx.SaveChanges();
        Console.WriteLine(_ctx.Entry(course).Property(c => c.CourseId).CurrentValue);
        Console.WriteLine("Finish");

    }
}
