using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Persistence.Contexts;

namespace UTaxi.API.Persistence.Repositories
{
    public class StudentRouteRepository: BaseRepository, IStudentRouteRepository
    {
        public StudentRouteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StudentRoute>> ListAsync()
        {
            return await _context.StudentRoutes.ToListAsync();
        }

        public async Task AddAsync(StudentRoute studentRoute)
        {
            await _context.StudentRoutes.AddAsync(studentRoute);
        }
    }
}