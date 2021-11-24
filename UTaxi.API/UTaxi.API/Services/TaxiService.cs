using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Services
{
    public class TaxiService : ITaxiService
    {
        private readonly ITaxiRepository _taxiRepository;


        public TaxiService(ITaxiRepository taxiRepository)
        {
            _taxiRepository = taxiRepository;
        }

        public async Task<IEnumerable<Taxi>> ListAsync()
        {
            return await _taxiRepository.ListAsync();
        }

        public async Task<SaveTaxiResponse> SaveAsync(Taxi taxi)
        {
            try
            {
                await _taxiRepository.AddAsync(taxi);

                return new SaveTaxiResponse(taxi);
            }
            catch (Exception e)
            {
                return new SaveTaxiResponse($"An error occurred while saving the taxi: {e.Message}");
            }
        }

        public async Task<SaveTaxiResponse> UpdateAsync(int id, Taxi taxi)
        {
            var existingTaxi = await _taxiRepository.FindByIdAsync(id);

            if (existingTaxi == null)
            {
                return new SaveTaxiResponse("Taxi not found");
            }

            existingTaxi.RegistrationNumber = taxi.RegistrationNumber;
            try
            {
                _taxiRepository.Update(existingTaxi);

                return new SaveTaxiResponse(existingTaxi);
            }
            catch (Exception e)
            {
                return new SaveTaxiResponse($"An error occurred while updating the taxi: {e.Message}");
            }
        }

        public async Task<TaxiResponse> DeleteAsync(int id)
        {
            var existingTaxi = await _taxiRepository.FindByIdAsync(id);

            if (existingTaxi == null)
            {
                return new TaxiResponse("Taxi not found");
            }
            try
            {
                _taxiRepository.Update(existingTaxi);

                return new TaxiResponse(existingTaxi);
            }
            catch (Exception e)
            {
                return new TaxiResponse($"An error occurred while deleting the taxi: {e.Message}");
            }
        }
    }
}