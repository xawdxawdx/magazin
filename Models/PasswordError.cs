using System.ComponentModel.DataAnnotations;

namespace DanilaWebApp.Models
{
    public class PasswordError : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((value as string) == "xawdxawdx")
            {
                return false;
            }
            return true;
        }
    }
}