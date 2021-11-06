using System.Collections.Generic;

namespace UTaxi.API.Domain.Models
{
    public class Route
    {
        public string Status { get; set; }
        
        //Relationships 
        public Driver Driver { get; set; }
        public IList<Student> Students { get; set; } = new List<Student>();
        public Payment Payment { get; set; }
        public DetailsRoute DetailsRoute { get; set; }

        //ID Relationships
        public int DriverId { get; set; }
        public int StudentId { get; set; }
        public int DetailsRouteId { get; set; }
    }
}