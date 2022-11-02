using StudentsClient.Domain.Model;

namespace StudentsClient.Domain.Services;
public interface IStudentService
{
    Task Create(IEnumerable<StudentCreateModel> students);
    Task Delete(int id);
    Task Update(StudentUpdateModel student);
    Task<StudentModel> GetById(int id);
    Task<List<StudentModel>> GetAll();
}
