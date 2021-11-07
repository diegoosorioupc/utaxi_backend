using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Persistence.Contexts;

namespace UTaxi.API.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository,IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _context.Payments.ToListAsync();
        }
    }
}