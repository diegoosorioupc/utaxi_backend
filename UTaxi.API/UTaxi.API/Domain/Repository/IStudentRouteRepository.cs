using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Repository
{
    public interface IStudentRouteRepository
    {
        Task<IEnumerable<StudentRoute>>ListAsync();
        Task AddAsync(StudentRoute studentRoute);
        Task<StudentRoute> FindByIdAsync(int id);
        void Update(StudentRoute studentRoute);
        void Remove(StudentRoute studentRoute);
    }
}