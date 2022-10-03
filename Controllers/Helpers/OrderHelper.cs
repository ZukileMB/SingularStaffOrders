using SingularStaffOrders.Models.MyDBContext;
using System;
using SingularStaffOrders.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SingularStaffOrders.Models.ViewModels;

namespace SingularStaffOrders.Controllers.Helpers
{
    public class OrderHelper
    {
        private DatabaseContext db = new DatabaseContext();

        /// <summary>
        /// Method that creates an order for the specific customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int CreateOrder(int customerId)
        {
            Orders orders = new Orders();

            orders.CustomerID = customerId;
            orders.OrderDate = DateTime.Now;
            db.Orders.Add(orders);
            db.SaveChanges();

            return (orders.OrderNo);
        }

        /// <summary>
        /// Called once the order placed to stored the details of the order in the DB
        /// </summary>
        /// <param name="cartItems"></param>
        /// <param name="orderNo"></param>
        public void AddOrderDetails(List<CartItem> cartItems, int orderNo)
        {
            List<OrderDetails> ordersDetails = new List<OrderDetails>();
            foreach (var item in cartItems)
            {
                ordersDetails.Add(new OrderDetails
                {
                    OrderNo = orderNo,
                    ProductID = item.Product.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalAmountToPay
                });
            }
            db.OrderDetails.AddRange(ordersDetails);
            db.SaveChanges();
        }
    }
}