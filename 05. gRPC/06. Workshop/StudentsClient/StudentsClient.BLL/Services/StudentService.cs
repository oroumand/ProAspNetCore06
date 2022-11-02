using Microsoft.Extensions.Logging;
using StudentsClient.Domain.Model;
using StudentsClient.Domain.Repositories;
using StudentsClient.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsClient.BLL.Services;
public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<StudentService> _logger;

    public StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }
    public async Task Create(IEnumerable<StudentCreateModel> students)
    {
        await foreach (var item in _studentRepository.Create(students))
        {
            _logger.LogInformation("Student Created by Id: {StudentId} at {DateTime}", item, DateTime.Now);
        }
        await Task.CompletedTask;
    }

    public async Task Delete(int id)
    {
        await _studentRepository.Delete(id);
    }

    public async Task<List<StudentModel>> GetAll()
    {
        List<StudentModel> result = new List<StudentModel>();
        await foreach (var student in _studentRepository.GetAll())
        {
            result.Add(student);
        }
        return result;
    }

    public async Task<StudentModel> GetById(int id)
    {
        return await _studentRepository.GetById(id);
    }

    public async Task Update(StudentUpdateModel student)
    {
        await _studentRepository.Update(student);
    }

}
