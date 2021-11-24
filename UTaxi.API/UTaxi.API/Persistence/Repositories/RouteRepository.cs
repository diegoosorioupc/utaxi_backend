using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Persistence.Contexts;

namespace UTaxi.API.Persistence.Repositories
{
    public class RouteRepository : BaseRepository, IRouteRepository
    {
        public RouteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Route>> ListAsync()
        {
            return await _context.Routes.ToListAsync();
        }

        public async Task AddAsync(Route route)
        {
            await _context.Routes.AddAsync(route);
        }

        public async Task<Route> FindByIdAsync(int id)
        {
            return await _context.Routes.FindAsync(id);
        }

        public void Update(Route route)
        {
            _context.Routes.Update(route);
        }

        public void Remove(Route route)
        {
            _context.Routes.Remove(route);
        }
    }
}