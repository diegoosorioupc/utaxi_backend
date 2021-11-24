using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class SaveDriverResponse : BaseResponse
    {
        public Driver Driver { get; private set; }
        public SaveDriverResponse(bool success, string message, Driver driver) : base(success, message)
        {
            Driver = driver;
        }
        public SaveDriverResponse(Driver driver) : this(true, string.Empty, driver){}
        public SaveDriverResponse(string message) : this(false, message, null){}
    }
}