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

        public async Task<SaveDetailsRouteResponse> UpdateAsync(int id, DetailsRoute detailsRoute)
        {
            var existingDetailsRoute = await _detailsRouteRepository.FindByIdAsync(id);

            if (existingDetailsRoute == null)
            {
                return new SaveDetailsRouteResponse("Details of Route not found");
            }

            existingDetailsRoute.Id = detailsRoute.Id;
            try
            {
                _detailsRouteRepository.Update(existingDetailsRoute);

                return new SaveDetailsRouteResponse(existingDetailsRoute);
            }
            catch (Exception e)
            {
                return new SaveDetailsRouteResponse($"An error occurred while updating the details: {e.Message}");
            }
        }

        public async Task<DetailsRouteResponse> DeleteAsync(int id)
        {
            var existingDetailsRoute = await _detailsRouteRepository.FindByIdAsync(id);

            if (existingDetailsRoute == null)
            {
                return new DetailsRouteResponse("Details of Route not found");
            }
            try
            {
                _detailsRouteRepository.Remove(existingDetailsRoute);

                return new DetailsRouteResponse(existingDetailsRoute);
            }
            catch (Exception e)
            {
                return new DetailsRouteResponse($"An error occurred while deleting the details: {e.Message}");
            }
        }
    }
}