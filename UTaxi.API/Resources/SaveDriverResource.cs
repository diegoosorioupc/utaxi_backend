using System.ComponentModel.DataAnnotations;

namespace UTaxi.API.Resources
{
    public class SaveDriverResource
    {
        [Required]
        [MaxLength(50)]
        public string Name;
        
        [Required]
        public int LicensedNumber { get; set; }
        
        [Required]
        public string Birth { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string UniversityName { get; set; }
        
        [Required]
        public string UniversityCard { get; set; }
    }
}