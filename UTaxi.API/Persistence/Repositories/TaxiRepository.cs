using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Persistence.Contexts;

namespace UTaxi.API.Persistence.Repositories
{
    public class TaxiRepository : BaseRepository,ITaxiRepository
    {
        public TaxiRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Taxi>> ListAsync()
        {
            return await _context.Taxis.ToListAsync();
        }

        public async Task AddAsync(Taxi taxi)
        {
            await _context.Taxis.AddAsync(taxi);
        }

        public async Task<Taxi> FindByIdAsync(int id)
        {
            return await _context.Taxis.FindAsync(id);
        }

        public void Update(Taxi taxi)
        {
            _context.Taxis.Update(taxi);
        }

        public void Remove(Taxi taxi)
        {
            _context.Taxis.Remove(taxi);
        }
    }
}