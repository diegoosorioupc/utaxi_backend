using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class DriverResponse : BaseResponse
    {
        public Driver Driver { get; set; }
        public DriverResponse(bool success, string message, Driver driver) : base(success, message)
        {
            Driver = driver;
        }
        public DriverResponse(Driver driver):this(true,string.Empty,driver){}
        public DriverResponse(string message):this(false,message,null){}
    }
}