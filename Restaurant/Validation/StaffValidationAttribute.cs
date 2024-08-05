using Restaurant.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Restaurant.Validation
{
    public class NIDAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Staff staff = validationContext.ObjectInstance as Staff;
            String NID = value.ToString();
            if (NID.Length != 14)
            {
                return new ValidationResult("Invalid NID ");
            }
            return ValidationResult.Success;
        }
    }
}