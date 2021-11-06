using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Repository
{
    public interface ITaxiRepository
    {
        Task<IEnumerable<Taxi>>ListAsync();
    }
}