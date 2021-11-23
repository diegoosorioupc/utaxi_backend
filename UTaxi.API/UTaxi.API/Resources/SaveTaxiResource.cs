using System.ComponentModel.DataAnnotations;

namespace UTaxi.API.Resources
{
    public class SaveTaxiResource
    {
        [Required]
        public string Model { get; set; }
        
        [Required]
        public int RegistrationNumber { get; set; }
        
        [Required]
        public string VehicleStatus { get; set; }
        
        [Required]
        public int Capacity { get; set; }
    }
}