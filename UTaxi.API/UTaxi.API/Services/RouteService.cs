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

        public async Task<SaveRouteResponse> UpdateAsync(int id, Route route)
        {
            var existingRoute = await _routeRepository.FindByIdAsync(id);

            if (existingRoute == null)
            {
                return new SaveRouteResponse("Route not found");
            }

            existingRoute.Id = route.Id;
            try
            {
                _routeRepository.Update(existingRoute);

                return new SaveRouteResponse(existingRoute);
            }
            catch (Exception e)
            {
                return new SaveRouteResponse($"An error occurred while updating the route: {e.Message}");
            }
        }

        public async Task<RouteResponse> DeleteAsync(int id)
        {
            var existingRoute = await _routeRepository.FindByIdAsync(id);

            if (existingRoute == null)
            {
                return new RouteResponse("Route not found");
            }
            try
            {
                _routeRepository.Remove(existingRoute);

                return new RouteResponse(existingRoute);
            }
            catch (Exception e)
            {
                return new RouteResponse($"An error occurred while deleting the route: {e.Message}");
            }
        }
    }
}