namespace UTaxi.API.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string TypePayment { get; set; }
        public float Mont { get; set; }
        public float Discount { get; set; }
        public bool CheckPayment { get; set; }
        
        //Relationships
        public DetailsRoute DetailsRoute { get; set; }
    }
}