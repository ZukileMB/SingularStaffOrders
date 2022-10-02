using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models
{
    public class Orders
    {
        [Key]
        public int OrderNo { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}