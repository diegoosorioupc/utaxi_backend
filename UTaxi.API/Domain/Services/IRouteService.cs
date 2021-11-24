using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Domain.Services
{
    public interface IRouteService
    {
        Task<IEnumerable<Route>> ListAsync();
        Task<SaveRouteResponse> SaveAsync(Route route);
        Task<SaveRouteResponse> UpdateAsync(int id, Route route);
        Task<RouteResponse> DeleteAsync(int id);
    }
}