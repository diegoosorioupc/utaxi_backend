using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAsync();
    }
}