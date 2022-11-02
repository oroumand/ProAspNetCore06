using StudentsClient.Domain.Model;

namespace StudentsClient.Domain.Repositories;
public interface IStudentRepository
{
    IAsyncEnumerable<int> Create(IEnumerable<StudentCreateModel> students);
    Task Delete(int id);
    Task Update(StudentUpdateModel student);
    Task<StudentModel> GetById(int id);
    IAsyncEnumerable<StudentModel> GetAll();
}
