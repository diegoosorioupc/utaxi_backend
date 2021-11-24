using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class RouteResponse : BaseResponse
    {
        public Route Route { get; set; }
        public RouteResponse(bool success, string message, Route route) : base(success, message)
        {
            Route = route;
        }
        public RouteResponse(Route route):this(true,string.Empty,route){}
        public RouteResponse(string message):this(false,message,null){}
    }
}