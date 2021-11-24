namespace UTaxi.API.Resources
{
    public class PaymentResource
    {
        public int Id { get; set; }
        public string TypePayment { get; set; }
        public float Mont { get; set; }
        public float Discount { get; set; }
        public bool CheckPayment { get; set; }
    }
}