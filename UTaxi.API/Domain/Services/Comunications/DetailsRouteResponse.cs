using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class DetailsRouteResponse: BaseResponse
    {
        public DetailsRoute DetailsRoute { get; set; }
        public DetailsRouteResponse(bool success, string message, DetailsRoute detailsRoute) : base(success, message)
        {
            DetailsRoute = detailsRoute;
        }
        
        public DetailsRouteResponse(DetailsRoute detailsRoute):this(true,string.Empty,detailsRoute){}
        public DetailsRouteResponse(string message):this(false,message,null){}
    }
}