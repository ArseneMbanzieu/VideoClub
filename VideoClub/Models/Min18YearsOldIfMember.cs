using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoClub.Models
{
    public class Min18YearsOldIfMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)            
                return ValidationResult.Success;
            if (customer.Birthdate == null)

                return new ValidationResult("BirthDate is required");
            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return (age >= 18 
                ? ValidationResult.Success 
                : new ValidationResult("Customer sould be at least 18"));

   
            
        }
    }
}