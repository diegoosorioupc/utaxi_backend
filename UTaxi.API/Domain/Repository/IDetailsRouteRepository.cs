using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Repository
{
    public interface IDetailsRouteRepository
    {
        Task<IEnumerable<DetailsRoute>> ListAsync();
        Task AddAsync(DetailsRoute detailsRoute);
        Task<DetailsRoute> FindByIdAsync(int id);
        void Update(DetailsRoute detailsRoute);
        void Remove(DetailsRoute detailsRoute);
    }
}