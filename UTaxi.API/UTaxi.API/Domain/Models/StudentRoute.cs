namespace UTaxi.API.Domain.Models
{
    public class StudentRoute
    {
        public int StudentRouteId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Route Route { get; set; }
        public int RouteId { get; set; }
    }
}