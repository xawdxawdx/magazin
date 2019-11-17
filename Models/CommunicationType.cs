using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanilaWebApp.Models
{
    public class CommunicationType
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Cant be null'")]
        public string CommunicationName { get; set; }
        [Required(ErrorMessage = "Cant be null'")]
        public string CommunicationSubType { get; set; }
        
        public ICollection<SupportedCommunicationType> SupportedCommunicationTypes { get; set; }
    }
}