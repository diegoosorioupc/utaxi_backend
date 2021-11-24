using System.ComponentModel.DataAnnotations;

namespace UTaxi.API.Resources
{
    public class SaveRouteResource
    {
        [Required]
        public string Status { get; set; }
    }
}