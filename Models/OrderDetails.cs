using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetaisId { get; set; } 
        public int Quantity { get; set; } 
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; } 
        public int OrderNo { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
        [ForeignKey("OrderNo")]
        public virtual Orders Orders { get; set; }  
    }
}