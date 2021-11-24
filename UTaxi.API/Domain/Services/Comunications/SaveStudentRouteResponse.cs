using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class SaveStudentRouteResponse : BaseResponse
    {
        public StudentRoute StudentRoute { get; private set; }
        public SaveStudentRouteResponse(bool success, string message, StudentRoute studentRoute) : base(success, message)
        {
            StudentRoute = studentRoute;
        }
        public SaveStudentRouteResponse(StudentRoute studentRoute) : this(true, string.Empty, studentRoute){}
        public SaveStudentRouteResponse(string message) : this(false, message, null){}
    }
}