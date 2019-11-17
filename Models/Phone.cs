using System.ComponentModel.DataAnnotations;

namespace DanilaWebApp.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "There is always must be manufacturer")]
        public string Company { get; set; }
        [Range(1,10000000, ErrorMessage = "Wrong weight of price")]
        public int Price { get; set; }
        
        public PhoneCharacteristic Characteristic { get; set; }
        
        public int CharacteristicId { get; set; }

        public Order Order { get; set; }
        
        public int OrderId { get; set; }
    }
}