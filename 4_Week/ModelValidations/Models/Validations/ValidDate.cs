using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidations.Models.Validations
{
    public class OldEnoughAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // check value (the subbmitted data)
            DateTime dob = (DateTime)value;
            // decide what valid is
            if((DateTime.Now - dob).Days / 365 < 13)
            {
            // if not return new ValidationResult("ERROR MESSAGE")
                return new ValidationResult("Must be 13 or older.");
            }
            // if valid return ValidationResult.Success
            return ValidationResult.Success;
        }
    }
}