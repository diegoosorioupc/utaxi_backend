using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Repository
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> ListAsync();
        Task AddAsync(Driver driver);
        Task<Driver> FindByIdAsync(int id);
        void Update(Driver driver);
        void Remove(Driver driver);
    }
}