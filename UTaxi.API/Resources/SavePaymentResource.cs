using System.ComponentModel.DataAnnotations;

namespace UTaxi.API.Resources
{
    public class SavePaymentResource
    {
        [Required]
        public string TypePayment { get; set; }
        
        [Required]
        public float Mont { get; set; }
        
        [Required]
        public float Discount { get; set; }
        
        [Required]
        public bool CheckPayment { get; set; }
    }
}