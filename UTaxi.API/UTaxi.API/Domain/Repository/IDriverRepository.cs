using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Repository
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> ListAsync();
    }
}