using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;
using UTaxi.API.Domain.Services.Comunications;

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

        public async Task<SaveDetailsRouteResponse> SaveAsync(DetailsRoute detailsRoute)
        {
            try
            {
                await _detailsRouteRepository.AddAsync(detailsRoute);

                return new SaveDetailsRouteResponse(detailsRoute);
            }
            catch (Exception e)
            {
                return new SaveDetailsRouteResponse($"An error occurred while saving the details: {e.Message}");
            }
        }
    }
}