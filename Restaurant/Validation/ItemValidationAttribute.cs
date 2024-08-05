using Restaurant.Models;
using System.ComponentModel.DataAnnotations;
using MS.Data.Enums;

namespace Restaurant.Validation
{
    public class ItemValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Item item = validationContext.ObjectInstance as Item;
            if (item.Type == ItemType.Food && item.ExpireDate < System.DateTime.Now)
            {
                return new ValidationResult("Food item is expired");
            }
            return ValidationResult.Success;
        }
    }
}
/*
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
 *           Staff staff = validationContext.ObjectInstance as Staff;
            String NID = value.ToString();
            if (NID.Length != 14)
            {
                return new ValidationResult("Invalid NID ");
            }
            return ValidationResult.Success;
        }
    }
}*/