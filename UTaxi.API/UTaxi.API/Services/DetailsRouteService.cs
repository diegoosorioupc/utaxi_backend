using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;

namespace UTaxi.API.Services
{
    public class DetailsRouteService : IDetailsRouteService
    {
        private readonly IDetailsRouteRepository _detailsRouteRepository;

        public DetailsRouteService(IDetailsRouteRepository detailsRouteRepository)
        {
            _detailsRouteRepository = detailsRouteRepository;
        }

        public async Task<IEnumerable<DetailsRoute>> ListAsync()
        {
            return await _detailsRouteRepository.ListAsync();
        }
    }
}