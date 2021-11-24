using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<Route>> ListAsync()
        {
            return await _routeRepository.ListAsync();
        }

        public async  Task<SaveRouteResponse> SaveAsync(Route route)
        {
            try
            {
                await _routeRepository.AddAsync(route);

                return new SaveRouteResponse(route);
            }
            catch (Exception e)
            {
                return new SaveRouteResponse($"An error occurred while saving the route: {e.Message}");
            }
        }
    }
}