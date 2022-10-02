using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace SingularStaffOrders.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}