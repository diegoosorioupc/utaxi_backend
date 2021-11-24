using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Domain.Services
{
    public interface ITaxiService
    {
        Task<IEnumerable<Taxi>> ListAsync();
        Task<SaveTaxiResponse> SaveAsync(Taxi taxi);
    }
}