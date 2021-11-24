using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Domain.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAsync();
        Task<SaveStudentResponse> SaveAsync(Student student);
        Task<SaveStudentResponse> UpdateAsync(int id,Student student);
        Task<StudentResponse> DeleteAsync(int id);
    }
}