using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DanilaWebApp.Models
{
    public class Profile
    {
        public int Id { get; set; }
        
        [Remote(action: "IsMe", controller: "Profile", ErrorMessage = "Can\'t be another me!")]
        public string Name { get; set; }
        [Range(18, 65)]
        public int Age { get; set; }
        
        public int UserId { get; set; }
        
        public User User { get; set; }
        
        public Order Order { get; set; }
    }
}