using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Address Type")]
        public string AddressType { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        [Display(Name = "Surburb")]
        public string Surburb { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be {2} characters long.", MinimumLength = 4)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
    }
}
