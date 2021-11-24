using System.ComponentModel.DataAnnotations;

namespace UTaxi.API.Resources
{
    public class SaveDetailsRouteResource
    {
        [Required]
        public int RouteCode { get; set; }
        
        [Required]
        public string Date { get; set; }
        
        [Required]
        public string RouteStart { get; set; }
        
        [Required]
        public string RouteEnd { get; set; }
        
        [Required]
        public float Price { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}