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

        public async Task<SavePaymentResponse> UpdateAsync(int id, Payment payment)
        {
            var existingPayment = await _paymentRepository.FindByIdAsync(id);

            if (existingPayment == null)
            {
                return new SavePaymentResponse("Payment not found");
            }

            existingPayment.Id = payment.Id;
            try
            {
                _paymentRepository.Update(existingPayment);

                return new SavePaymentResponse(existingPayment);
            }
            catch (Exception e)
            {
                return new SavePaymentResponse($"An error occurred while updating the payment: {e.Message}");
            }
        }

        public async Task<PaymentResponse> DeleteAsync(int id)
        {
            var existingPayment = await _paymentRepository.FindByIdAsync(id);

            if (existingPayment == null)
            {
                return new PaymentResponse("Payment not found");
            }
            
            try
            {
                _paymentRepository.Remove(existingPayment);

                return new PaymentResponse(existingPayment);
            }
            catch (Exception e)
            {
                return new PaymentResponse($"An error occurred while deleting the payment: {e.Message}");
            }
        }
    }
}