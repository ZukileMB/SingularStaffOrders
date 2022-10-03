using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderDetaisId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int OrderNo { get; set; }
    }
}