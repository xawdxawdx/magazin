namespace DanilaWebApp.Models
{
    public class SupportedCommunicationType
    {
        public int Id { get; set; }
        
        public PhoneCharacteristic  PhoneCharacteristic { get; set; }
        
        public int PhoneCharacteristicId { get; set; }
        
        public CommunicationType CommunicationType { get; set; }
        
        public int CommunicationTypeId { get; set; }
        
    }
}