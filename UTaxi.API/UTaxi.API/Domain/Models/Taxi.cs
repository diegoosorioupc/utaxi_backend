namespace UTaxi.API.Domain.Models
{
    public class Taxi
    {
        public string Model { get; set; }
        public int RegistrationNumber { get; set; }
        public string VehicleStatus { get; set; }
        public int Capacity { get; set; }
        
        //Relationships
        public Driver Driver { get; set; }
    }
}