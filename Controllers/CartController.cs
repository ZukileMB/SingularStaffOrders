using SingularStaffOrders.Controllers.Helpers;
using SingularStaffOrders.Models;
using SingularStaffOrders.Models.ViewModels;
using SingularStaffOrders.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingularStaffOrders.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Cart cart = new Cart().GetCart(SessionContext.ProductsInCart);
            return View(cart);
        }

        /// <summary>
        /// Partial that handles the activities in the cart 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult AddToCartAction(ProductsViewModel product)
        {
            return PartialView("~/Views/Cart/PartialViews/_AddToCartPartial.cshtml", product);
        }

        /// <summary>
        /// Update cart with the quantity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult UpdateQuantityAction(CartItem model)
        {
            return PartialView("~/Views/Cart/PartialViews/_UpdateQuantityInCart.cshtml", model);
        }

        /// <summary>
        /// when you click place order method this create order
        /// update the cart quantity once the order has been placed
        /// in Here i am not sure whether to link the customer with ID for now setting 1 as Customer 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ActionResult Checkout()
        {
            OrderHelper orderHelper = new OrderHelper();

            int orderNo = orderHelper.CreateOrder(1);
            if (orderNo == 0)
            {
                throw new Exception("Unable to create the order");
            }
            Cart cart = new Cart().GetCart(SessionContext.ProductsInCart);
            orderHelper.AddOrderDetails(cart.Items, orderNo);
            Utility.SessionContext.ProductsInCart = new List<ProductsViewModel>();
            Utility.SessionContext.NoOfItemsInCart =0;
            return new HttpStatusCodeResult (System.Net.HttpStatusCode.OK);
        }

    }
}