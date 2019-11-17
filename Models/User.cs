using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanilaWebApp.Models
{
    public class User : IValidatableObject
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Login can\'t be null")]
        public string Login { get; set; }
        
        [PasswordError(ErrorMessage = "Password is not valid")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Registration Date can't be null'")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public Profile Profile { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Login == "Danila")
            {
                yield return new ValidationResult(
                    $"Too many Danila for one program!",
                    new[] { "Login" });
            }
        }
    }
}