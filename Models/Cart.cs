using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Models
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
        }
        public List<CartItem> Items { get; set; }
        public int TotalItemsInCart { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }

        public Cart GetCart(List<Product> products)
        {
            List<CartItem> items = products.GroupBy(c => c.ProductId)
                .Select(prod => new CartItem
                {
                    Product = prod.First(),
                    Quantity = prod.Count(),
                    TotalAmountToPay = prod.Sum(c => c.UnitPrice)
                }).ToList();

            return new Cart
            {
                Items = items,
                TotalItemsInCart = items.Select(x => x.Quantity).Sum(),
                TotalAmount = items.Select(x => x.TotalAmountToPay).Sum()
            };
        }
    }
}