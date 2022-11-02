using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using StudentsService.Domain.Services;
using StudentsService.Grpc.Protos.v1;

namespace StudentsService.Grpc.Services.v1;

public class StudentService: Protos.v1.StudentService.StudentServiceBase
{
	private readonly IStudentService _studentService;

	public StudentService(IStudentService studentService)
	{
		_studentService = studentService;
	}
	public override async Task CreateStudent(IAsyncStreamReader<StudentCreateRequest> requestStream, IServerStreamWriter<StudentCreateReply> responseStream, ServerCallContext context)
	{
		await foreach (var item in requestStream.ReadAllAsync())
		{
			var serviceResult= await _studentService.CreateAsync(new Domain.Models.StudentModel
			{
				FirstName = item.FirstName,
				LastName = item.LastName,
				StudentNumber = item.StudentNumber,
				Description = item.Description,
				PhoneNumbers = new List<string>(item.PhoneNumbers)
			});
			await responseStream.WriteAsync(new StudentCreateReply
			{
				Id = serviceResult
			});

        }
		await Task.CompletedTask;

	}
	public override async Task<StudentDeleteReply> DeleteStudent(StudentByIdRequest request, ServerCallContext context)
	{
		var serviceResult = await _studentService.DeleteAsync(request.ID);
		return new StudentDeleteReply
		{
			Success = serviceResult
		};
    }
	public override async Task<StudentUpdateReply> UpdatePerson(StudentUpdateRequest request, ServerCallContext context)
	{
        var serviceResult = await _studentService.UpdateAsync(new Domain.Models.StudentForUpdateModel
		{
			Id = request.Id,
			FirstName = request.FirstName,
			LastName = request.LastName,
			Description = request.Description
		});
		return new StudentUpdateReply
		{
			Success = serviceResult
		};
	}
	public override async Task<StudentReply> GetById(StudentByIdRequest request, ServerCallContext context)
	{
		var student = await _studentService.GetByIdAsync(request.ID);
		if(student is null)
		{
			throw new RpcException(new Status(StatusCode.NotFound, $"Student with id {request.ID} not found"));
		}
		var  reply = new StudentReply
		{
			Id = student.Id,
			Description = student.Description,
			FirstName = student.FirstName,
			LastName = student.LastName,
			StudentNumber = student.StudentNumber,
			
		};
		reply.PhoneNumbers.AddRange(student.PhoneNumbers);
		return reply;
	}
	public override async Task GetAll(Empty request, IServerStreamWriter<StudentReply> responseStream, ServerCallContext context)
	{
		var students = await _studentService.GetAllAsync();
		foreach (var student in students)
		{
            var reply = new StudentReply
            {
                Id = student.Id,
                Description = student.Description,
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentNumber = student.StudentNumber,

            };
            reply.PhoneNumbers.AddRange(student.PhoneNumbers);
			await responseStream.WriteAsync(reply);
        }
		await Task.CompletedTask;
	}
}
