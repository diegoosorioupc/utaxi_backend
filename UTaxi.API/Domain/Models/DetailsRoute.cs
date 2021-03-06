namespace UTaxi.API.Domain.Models
{
    public class DetailsRoute
    {
        public int Id { get; set; }
        public int RouteCode { get; set; }
        public string Date { get; set; }
        public string RouteStart { get; set; }
        public string RouteEnd { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        
        //Relationships
        public Route Route { get; set; }
        public Payment Payment { get; set; }
        public int PaymentId { get; set; }
    }
}