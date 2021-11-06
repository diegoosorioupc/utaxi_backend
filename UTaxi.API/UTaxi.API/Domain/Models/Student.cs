using System.Collections.Generic;

namespace UTaxi.API.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birth { get; set; }
        public int Phone { get; set; }
        public string UniversityName { get; set; }
        public string UniversityCard { get; set; }
        
        //Relationships
        public IList<Route> Routes { get; set; } = new List<Route>();
    }
}