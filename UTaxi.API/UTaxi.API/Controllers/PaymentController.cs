using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services;

namespace UTaxi.API.Controllers
{
    [Route("/api/v1/[controller]")]
    public class PaymentController :ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            var payments = await _paymentService.ListAsync();
            return payments;
        }
    }
}