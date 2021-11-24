using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class TaxiResponse : BaseResponse
    {
        public Taxi Taxi { get; set; }
        public TaxiResponse(bool success, string message, Taxi taxi) : base(success, message)
        {
            Taxi = taxi;
        }
        public TaxiResponse(Taxi taxi):this(true,string.Empty,taxi){}
        public TaxiResponse(string message):this(false,message,null){}
    }
}