using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Persistence.Contexts;

namespace UTaxi.API.Persistence.Repositories
{
    public class DriverRepository :BaseRepository, IDriverRepository
    {
        public DriverRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Driver>> ListAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task AddAsync(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
        }

        public async Task<Driver> FindByIdAsync(int id)
        {
            return await _context.Drivers.FindAsync(id);
        }

        public void Update(Driver driver)
        {
            _context.Drivers.Update(driver);
        }

        public void Remove(Driver driver)
        {
            _context.Drivers.Remove(driver);
        }
    }
}