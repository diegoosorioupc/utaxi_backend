using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _paymentRepository.ListAsync();
        }

        public async Task<SavePaymentResponse> SaveAsync(Payment payment)
        {
            try
            {
                await _paymentRepository.AddAsync(payment);

                return new SavePaymentResponse(payment);
            }
            catch (Exception e)
            {
                return new SavePaymentResponse($"An error occurred while saving the payment: {e.Message}");
            }
        }
    }
}