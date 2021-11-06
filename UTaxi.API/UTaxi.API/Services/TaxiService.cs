using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;

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
    }
}