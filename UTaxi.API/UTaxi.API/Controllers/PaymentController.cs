using Microsoft.AspNetCore.Mvc;
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
    }
}