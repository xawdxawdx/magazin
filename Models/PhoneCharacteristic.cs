using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanilaWebApp.Models
{
    public class PhoneCharacteristic
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cant be null")]
        public string type { get; set; }
        [Required(ErrorMessage = "Cant be null")]
        public string opSystem { get; set; }
        [Required(ErrorMessage = "Cant be null")]
        [StringLength(20)]
        public string ScreenType { get; set; }
        [Range(320, 2560)]
        public int PhoneWidth { get; set; }
        [Range(480, 2560)]
        public int PhoneHeight { get; set; }
        [Range(1, 11)]
        public int PhoneDepth { get; set; }
        [Required(ErrorMessage = "Cant be null")]
        public string CpuModel { get; set; }
        
        public ICollection<SupportedCommunicationType> SupportedCommunicationTypes { get; set; }
        
        public Phone Phone { get; set; } 
    }
}