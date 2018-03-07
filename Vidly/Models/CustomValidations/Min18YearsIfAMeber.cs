using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Dtos;

namespace Vidly.Models
{
    public class Min18YearsIfAMeber:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            
            if(customer.MembershipTypeId==(byte)Membership.Unknown || 
                customer.MembershipTypeId == (byte)Membership.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate ==null)
            {
                return new ValidationResult("Birthdate is required");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success :
                new ValidationResult("Customer should be at least 18 years old to go on a membership ");
        }
    }
}