using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsleter { get; set; }
        
        [Display(Name ="Membership Type")]
        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Mempership Type is required")]
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name="Date of Birth")]
        [Min18YearsIfAMeber]
        public Nullable<DateTime> Birthdate { get; set; }

    }
}