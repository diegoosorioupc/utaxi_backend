using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>>ListAsync();
        Task AddAsync(Payment payment);
        Task<Payment> FindByIdAsync(int id);
        void Update(Payment payment);
        void Remove(Payment payment);
    }
}