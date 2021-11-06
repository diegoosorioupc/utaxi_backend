using System.Collections.Generic;

namespace UTaxi.API.Domain.Models
{
    public class RouteList
    {
        //Relationships
        public IList<Route> Routes { get; set; } = new List<Route>();
    }
}