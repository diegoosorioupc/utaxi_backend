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

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task<Payment> FindByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public void Update(Payment payment)
        {
            _context.Payments.Update(payment);
        }

        public void Remove(Payment payment)
        {
            _context.Payments.Remove(payment);
        }
    }
}