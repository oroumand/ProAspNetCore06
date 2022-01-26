using EfSample.Dal;
using EfSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSample.UI;
public class EntityStatePrinter
{
    private readonly CourseStoreDbContext _context;

    public EntityStatePrinter(CourseStoreDbContext context)
    {
        _context = context;
    }

    public void PrintDetachedState()
    {
        Tag tag = new Tag();

        var tagState = _context.Entry(tag).State;

        Console.WriteLine($"New Tag object sate is: {tagState}");
    }
    public void PrintAddedState()
    {
        Tag tag = new Tag();
        _context.Add(tag);
        var tagState = _context.Entry(tag).State;

        Console.WriteLine($"Added Tag object sate is: {tagState}");
    }


    public void PrintDeletedState()
    {
        Tag tag = new Tag
        {
            TagId = 1
        };
        _context.Remove(tag);
        var tagState = _context.Entry(tag).State;

        Console.WriteLine($"Deleted Tag object sate is: {tagState}");
    }

    public void PrintUpdatedState()
    {
        Tag tag = new Tag
        {
            TagId = 1
        };
        _context.Update(tag);
        var tagState = _context.Entry(tag).State;
        Console.WriteLine($"Updated Tag object sate is: {tagState}");
    }


    public void PrintUnchangedState()
    {
        Tag tag = _context.Tags.FirstOrDefault(c=>c.TagId==2);
        var tagState = _context.Entry(tag).State;

        Console.WriteLine($"Unchanged Tag object sate is: {tagState}");
    }
}
