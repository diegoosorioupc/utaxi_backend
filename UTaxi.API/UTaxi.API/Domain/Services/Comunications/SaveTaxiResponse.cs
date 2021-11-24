using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class SaveTaxiResponse : BaseResponse
    {
        public Taxi Taxi { get; private set; }
        public SaveTaxiResponse(bool success, string message, Taxi taxi) : base(success, message)
        {
            Taxi = taxi;
        }
        public SaveTaxiResponse(Taxi taxi) : this(true, string.Empty, taxi){}
        public SaveTaxiResponse(string message) : this(false, message, null){}
    }
}