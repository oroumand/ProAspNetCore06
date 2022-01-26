using EfSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSample.Dal;
public class CourseStoreRepository
{
    private readonly CourseStoreDbContext _courseStoreDbContext;

    public CourseStoreRepository(CourseStoreDbContext courseStoreDbContext)
    {
        _courseStoreDbContext = courseStoreDbContext;
    }

    public void PrintCourseAndTeachersEager()
    {
        Console.WriteLine("".PadLeft(100,'*'));
        var result = _courseStoreDbContext.Courses.Include(c=>c.CourseTeachers).ThenInclude(c=>c.Teacher).ToList();
        foreach (var course in result)
        {
            Console.WriteLine($"Course: {course.Name}");
            foreach (var teacher in course.CourseTeachers)
            {
                Console.WriteLine($"\t\t {teacher.Teacher.FirstName}, {teacher.Teacher.LastName}");
            }
        }
        Console.WriteLine("".PadLeft(100, '*'));
    }


    public void PrintCourseAndTeachersAndTagsEager()
    {
        Console.WriteLine("".PadLeft(100, '*'));
        var result = 
            _courseStoreDbContext.Courses
            .Include(c => c.CourseTeachers.OrderBy(c=>c.SortOrder)).ThenInclude(c => c.Teacher)
            .Include(c => c.Tags.Take(2))
            .ToList();
        foreach (var course in result)
        {
            Console.WriteLine($"Course: {course.Name}");
            foreach (var teacher in course.CourseTeachers)
            {
                Console.WriteLine($"\t\t {teacher.Teacher.FirstName}, {teacher.Teacher.LastName}");
            }

            foreach (var item in course.Tags)
            {
                Console.WriteLine($"Tag: {item.Name}");
            }
        }
        Console.WriteLine("".PadLeft(100, '*'));
    }


    public void PrintCourseAndTeachersExplicit()
    {
        Console.WriteLine("".PadLeft(100, '*'));
        var result = _courseStoreDbContext.Courses.ToList();
        foreach (var course in result)
        {
            Console.WriteLine($"Course: {course.Name}");
            if (DateTime.Now.Hour == 10)
            {
                _courseStoreDbContext.Entry(course).Collection(c => c.CourseTeachers).Load();

                foreach (var courseTeacher in course.CourseTeachers)
                {
                    _courseStoreDbContext.Entry(courseTeacher).Reference(c => c.Teacher).Load();
                    Console.WriteLine($"\t\t {courseTeacher.Teacher.FirstName}, {courseTeacher.Teacher.LastName}");
                }
            }
        }
        Console.WriteLine("".PadLeft(100, '*'));
    }


    public void CourseShortInfoDtoSelectLoading()
    {
        Console.WriteLine("".PadLeft(100, '*'));
        var result = _courseStoreDbContext.Courses
            .Select(c => new CourseShortInfoDto
            {
                Name = c.Name,
                Id = c.CourseId
            });
        foreach (var course in result)
        {
            Console.WriteLine($"Course: {course.Name}");
        }
        Console.WriteLine("".PadLeft(100, '*'));
    }

    public void CourseClienVsServer()
    {
        Console.WriteLine("".PadLeft(100, '*'));
        var result = _courseStoreDbContext.Courses.Include(c => c.Tags).
            Select(c => new
            {
                c.CourseId,
                c.Name,
                c.StartDateTime,
                Tags = string.Join(',', c.Tags)
            });

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name}:{ item.Tags}");
        }


    }

    public void PrintOrderdTags()
    {
        var tagsOrderBy = _courseStoreDbContext.Tags.OrderBy(c=>c.Name).ToList();
        foreach (var item in tagsOrderBy)
        {
            Console.WriteLine($"{item.TagId}: {item.Name}");
        }


        var tagsOrderByDesc = _courseStoreDbContext.Tags.OrderByDescending(c => c.Name).ToList();
        foreach (var item in tagsOrderByDesc)
        {
            Console.WriteLine($"{item.TagId}: {item.Name}");
        }

    }


    public void PrintTagsLike()
    {
        var tagsOrderBy = _courseStoreDbContext.Tags.Where(c=> EF.Functions.Like(c.Name,"P__ .NET %")).ToList();
        foreach (var item in tagsOrderBy)
        {
            Console.WriteLine($"{item.TagId}: {item.Name}");
        }




    }

    public void Paging()
    {
        var pagedData = _courseStoreDbContext.Tags.Skip(2).Take(2).ToList();
        foreach (var item in pagedData)
        {
            Console.WriteLine($"{item.TagId}: {item.Name}");
        }




    }
}
