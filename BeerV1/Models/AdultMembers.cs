using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeerV1.Models
{
    public class AdultMembers : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;

            if (user.BirthDate == null)
                return new ValidationResult("Birthdate is Required");

            var age = DateTime.Now.Year - user.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("User must be an adult");
        }
    }
}