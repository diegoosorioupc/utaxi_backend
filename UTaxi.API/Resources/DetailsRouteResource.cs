namespace UTaxi.API.Resources
{
    public class DetailsRouteResource
    {
        public int Id { get; set; }
        public int RouteCode { get; set; }
        public string Date { get; set; }
        public string RouteStart { get; set; }
        public string RouteEnd { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}