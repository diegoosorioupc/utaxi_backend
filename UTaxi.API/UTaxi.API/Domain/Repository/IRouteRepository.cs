using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;


namespace UTaxi.API.Domain.Repository
{
    public interface IRouteRepository
    {
        Task<IEnumerable<Route>>ListAsync();
        Task AddAsync(Route route);
    }
}