using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string AddressType { get; set; }
        public string StreetAddress { get; set; }
        public string Surburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}