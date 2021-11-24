using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class SavePaymentResponse : BaseResponse
    {
        public Payment Payment { get; private set; }
        public SavePaymentResponse(bool success, string message, Payment payment) : base(success, message)
        {
            Payment = payment;
        }
        public SavePaymentResponse(Payment payment) : this(true, string.Empty, payment){}
        public SavePaymentResponse(string message) : this(false, message, null){}
    }
}