using System.ComponentModel.DataAnnotations;

namespace DanilaWebApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Country can't be null'")]
        public string Country { get; set; }
        [Required(ErrorMessage = "City can't be null'")]
        public string City { get; set; }
        [StringLength(125, ErrorMessage = "Please, make your string shorter")]
        public string AdditionalLocation { get; set; }
        
        [RegularExpression("^[0-9]{6}", ErrorMessage = "Wrong Zip Code")]
        public string ZipCode { get; set; }
        
        public bool SelfExport { get; set; }

        public Order Order { get; set; }
    }
}