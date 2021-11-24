using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class StudentRouteResponse : BaseResponse
    {
        public StudentRoute StudentRoute { get; set; }
        public StudentRouteResponse(bool success, string message, StudentRoute studentRoute) : base(success, message)
        {
            StudentRoute = studentRoute;
        }
        public StudentRouteResponse(StudentRoute studentRoute):this(true,string.Empty,studentRoute){}
        public StudentRouteResponse(string message):this(false,message,null){}
    }
}