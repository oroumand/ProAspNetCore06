using EfSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSample.Dal;
public class CourseStoreCommandRepository
{
    private readonly CourseStoreDbContext _context;

    public CourseStoreCommandRepository(CourseStoreDbContext context)
    {
        _context = context;
    }

    public void AddTag(string name)
    {
        Tag tag = new Tag
        {
            Name = name
        };
        Console.WriteLine($"New Tag State is:{_context.Entry(tag).State}");
        _context.Tags.Add(tag);
        Console.WriteLine($"New Tag State is:{_context.Entry(tag).State}");
        _context.SaveChanges();
        Console.WriteLine($"New Tag State is:{_context.Entry(tag).State}");
    }

    public void SaveCourse(CourseShortInfoDto dto)
    {
        var course = _context.Courses.FirstOrDefault(c=>c.CourseId== dto.Id);

        course.Description = dto.Description;
        course.Name = dto.Name;

        _context.SaveChanges();
    }

    public void AddTags(string name)
    {
        Tag tag = new Tag
        {
            Name = name
        };
        Tag tag2 = new Tag
        {
            Name = name + "2"
        };
        Tag tag3 = new Tag
        {
            Name = name + "3"
        };
        _context.Tags.Add(tag);
        _context.Tags.Add(tag2);
        _context.Tags.Add(tag3);

        _context.SaveChanges();

    }
    public void AddCourseWithComment()
    {
        Course course = new Course
        {
            Name = "Modular Monolith",
            Price = 1000,
            Description = "Modular Monolith Course",
            Comments = new List<Comment>
            {
                new Comment
                {
                    CommentBy = "First Student",
                    CommentText = "That was good",
                    IsApproved = true,
                    StarCount = 5,
                }
            }

        };
        Console.WriteLine($"New Courses State is:{_context.Entry(course).State}");
        Console.WriteLine($"New Comment State is:{_context.Entry(course.Comments.First()).State}");
        _context.Courses.Add(course);
        Console.WriteLine($"New Courses State is:{_context.Entry(course).State}");
        Console.WriteLine($"New Comment State is:{_context.Entry(course.Comments.First()).State}");
        _context.SaveChanges();
        Console.WriteLine($"New Courses State is:{_context.Entry(course).State}");
        Console.WriteLine($"New Comment State is:{_context.Entry(course.Comments.First()).State}");
    }

    public void UpdateTag(int tagId, string newName)
    {
        var tag = _context.Tags.Find(tagId);
        tag.Name = newName;
        _context.SaveChanges();
    }

    public CourseShortInfoDto GetCourse(int id)
    {
        return _context.Courses.Where(c=>c.CourseId == id).Select(c=>new CourseShortInfoDto
        {
            Description = c.Description,
            Id = c.CourseId,
            Name = c.Name,

        }).FirstOrDefault();
    }

    public string GetTagName(int id)
    {
       return _context.Tags.FirstOrDefault(c => c.TagId == id).Name;
    }

    public void UpdateTagDisconnected(int id,string name)
    {
        var optionBuilder = new DbContextOptionsBuilder<CourseStoreDbContext>();
        optionBuilder.UseSqlServer("Server=.;Database=CourseDb;User Id=sa; Password=1qaz!QAZ");
        using CourseStoreDbContext disconnectedContext = new CourseStoreDbContext(optionBuilder.Options);
        Tag tag = new Tag
        {
            TagId = id,
            Name = name,
        };

        disconnectedContext.Tags.Update(tag);
        disconnectedContext.SaveChanges(true);

    }

    public void DeleteCourse(int id)
    {
        var course = _context.Courses.SingleOrDefault(c => c.CourseId == id);
        course.IsDeleted = true;
        _context.SaveChanges();
    }

    public void DisplayAllCourse()
    {
        var courses = _context.Courses.ToList();

        foreach (var course in courses)
        {
            Console.WriteLine($"{course.CourseId},{course.Name}");
        }
    }
    public void DeleteTag(int id)
    {
        var tag = _context.Tags.SingleOrDefault(c => c.TagId == id);
        _context.Remove(tag);
        _context.SaveChanges();
    }

    public void DeleteTagv2(int id)
    {
        var tag = new Tag { TagId = id };
        _context.Remove(tag);
        _context.SaveChanges();
    }
}
