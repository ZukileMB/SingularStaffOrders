using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string Surname { get; set; }
        [Display(Name = "Address Type")]
        public string AddressType { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Surburb")]
        public string Surburb { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
    }
}
