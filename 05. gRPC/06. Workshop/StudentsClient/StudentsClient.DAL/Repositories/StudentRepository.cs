using Grpc.Core;
using StudentsClient.DAL.Protos.v1;
using StudentsClient.Domain.Model;
using StudentsClient.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static StudentsClient.DAL.Protos.v1.StudentService;

namespace StudentsClient.DAL.Repositories;
public class StudentRepository : IStudentRepository
{
    private readonly StudentServiceClient _studentServiceClient;

    public StudentRepository(StudentService.StudentServiceClient studentServiceClient)
    {
        _studentServiceClient = studentServiceClient;
    }
    public async IAsyncEnumerable<int> Create(IEnumerable<StudentCreateModel> students)
    {
        var request = _studentServiceClient.CreateStudent();
        foreach (var student in students)
        {
            StudentCreateRequest studentRequest = new StudentCreateRequest
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Description = student.Description,
                StudentNumber = student.StudentNumber
            };
            student.PhoneNumbers.AddRange(student.PhoneNumbers);
            await request.RequestStream.WriteAsync(studentRequest);
        }
        await request.RequestStream.CompleteAsync();
        while (await request.ResponseStream.MoveNext())
        {
            var studentResponse = request.ResponseStream.Current;
            yield return studentResponse.Id;
        }
    }

    public async Task Delete(int id)
    {
        await _studentServiceClient.DeleteStudentAsync(new StudentByIdRequest
        {
            ID = id
        });
    }

    public async IAsyncEnumerable<StudentModel> GetAll()
    {
        var requst = _studentServiceClient.GetAll(new Google.Protobuf.WellKnownTypes.Empty());
        while (await requst.ResponseStream.MoveNext())
        {
            var reply = requst.ResponseStream.Current;
            var student = new StudentModel
            {
                Id = reply.Id,
                FirstName = reply.FirstName,
                LastName = reply.LastName,
                Description = reply.Description,
                StudentNumber = reply.StudentNumber
            };
            student.PhoneNumbers.AddRange(reply.PhoneNumbers);
            yield return student;
        }
    }

    public async Task<StudentModel> GetById(int id)
    {
        var result = await _studentServiceClient.GetByIdAsync(new StudentByIdRequest
        {
            ID = id
        });
        var finalResult = new StudentModel
        {
            FirstName = result.FirstName,
            Description = result.Description,
            LastName = result.LastName,
            StudentNumber = result.StudentNumber,
            Id = result.Id
            
        };
        finalResult.PhoneNumbers.AddRange(result.PhoneNumbers);
        return finalResult;
    }

    public async Task Update(StudentUpdateModel student)
    {
        await _studentServiceClient.UpdatePersonAsync(new StudentUpdateRequest
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Description = student.Description
        }); 

    }
}
