namespace UTaxi.API.Domain.Models
{
    public class Payment
    {
        public string TypePayment { get; set; }
        public float Mont { get; set; }
        public float Discount { get; set; }
        public bool CheckPayment { get; set; }
        
        //Relationships
        public Route Route { get; set; }
    }
}