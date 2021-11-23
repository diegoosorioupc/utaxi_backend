using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;

namespace UTaxi.API.Services
{
    public class StudentRouteService : IStudentRouteService
    {
        private readonly IStudentRouteRepository _studentRouteRepository;

        public StudentRouteService(IStudentRouteRepository studentRouteRepository)
        {
            _studentRouteRepository = studentRouteRepository;
        }

        public async Task<IEnumerable<StudentRoute>> ListAsync()
        {
            return await _studentRouteRepository.ListAsync();
        }
    }
}