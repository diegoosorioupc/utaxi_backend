using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>>ListAsync();
        Task AddAsync(Student student);
        Task<Student> FindByIdAsync(int id);
        void Update(Student student);
        void Remove(Student student);
    }
}