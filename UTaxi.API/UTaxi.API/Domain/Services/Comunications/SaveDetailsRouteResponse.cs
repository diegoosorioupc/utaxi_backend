using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class SaveDetailsRouteResponse : BaseResponse
    {
        public DetailsRoute DetailsRoute { get; private set; }
        public SaveDetailsRouteResponse(bool success, string message, DetailsRoute detailsRoute) : base(success, message)
        {
            DetailsRoute = detailsRoute;
        }

        public SaveDetailsRouteResponse(DetailsRoute detailsRoute) : this(true, string.Empty, detailsRoute){}
        public SaveDetailsRouteResponse(string message) : this(false, message, null){}
    }
}