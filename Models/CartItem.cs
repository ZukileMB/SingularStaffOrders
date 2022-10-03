using SingularStaffOrders.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Product = new ProductsViewModel();
        }
        public ProductsViewModel Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmountToPay { get; set; }
    }
}