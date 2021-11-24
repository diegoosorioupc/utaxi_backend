using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Domain.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task<SavePaymentResponse> SaveAsync(Payment payment);
        Task<SavePaymentResponse> UpdateAsync(int id, Payment payment);
        Task<PaymentResponse> DeleteAsync(int id);
    }
}