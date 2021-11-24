using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class SaveRouteResponse : BaseResponse
    {
        public Route Route { get; private set; }
        public SaveRouteResponse(bool success, string message, Route route) : base(success, message)
        {
            Route = route;
        }
        public SaveRouteResponse(Route route) : this(true, string.Empty, route){}
        public SaveRouteResponse(string message) : this(false, message, null){}
    }
}