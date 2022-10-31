using StudentsService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsService.Domain.Services;
public interface IStudentService
{
    Task<IEnumerable<StudentModel>> GetAllAsync();
    Task<StudentModel> GetByIdAsync(int id);
    Task<int> CreateAsync(StudentModel studentForCreate);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(StudentForUpdateModel studentForUpdate);
}
