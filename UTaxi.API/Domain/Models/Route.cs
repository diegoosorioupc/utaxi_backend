using System.Collections.Generic;

namespace UTaxi.API.Domain.Models
{
    public class Route
    {
        public string Status { get; set; }
        public int Id { get; set; }
        //Relationships 
        public Driver Driver { get; set; }
        public IList<StudentRoute> StudentRoutes { get; set; } = new List<StudentRoute>();
       
        public DetailsRoute DetailsRoute { get; set; }

        //ID Relationships
        public int DriverId { get; set; }
        public int DetailsRouteId { get; set; }
    }
}