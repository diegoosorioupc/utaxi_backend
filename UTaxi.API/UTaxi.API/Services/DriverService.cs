using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Services
{
    public class DriverService :IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<Driver>> ListAsync()
        {
            return await _driverRepository.ListAsync();
        }

        public async Task<SaveDriverResponse> SaveAsync(Driver driver)
        {
            try
            {
                await _driverRepository.AddAsync(driver);

                return new SaveDriverResponse(driver);
            }
            catch (Exception e)
            {
                return new SaveDriverResponse($"An error occurred while saving the driver: {e.Message}");
            }
        }
    }
}