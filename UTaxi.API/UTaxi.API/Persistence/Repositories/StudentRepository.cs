using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Persistence.Contexts;

namespace UTaxi.API.Persistence.Repositories
{
    public class StudentRepository: BaseRepository, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}