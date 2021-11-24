using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class PaymentResponse : BaseResponse
    {
        public Payment Payment { get; set; }
        public PaymentResponse(bool success, string message, Payment payment) : base(success, message)
        {
            Payment = payment;
        }
        public PaymentResponse(Payment payment):this(true,string.Empty,payment){}
        public PaymentResponse(string message):this(false,message,null){}
    }
}