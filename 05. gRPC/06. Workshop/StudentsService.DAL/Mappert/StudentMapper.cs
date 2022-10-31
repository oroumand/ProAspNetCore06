using StudentsService.DAL.Entities;
using StudentsService.Domain.Models;

namespace StudentsService.DAL.Mappert;
public static class StudentMapper
{
    public static StudentModel ToModel(this Student student)
    {
        return new StudentModel
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Description = student.Description,
            StudentNumber = student.StudentNumber,
            PhoneNumbers = student.PhoneNumbers.Select(d => d.Value).ToList()
        };
    }
}
