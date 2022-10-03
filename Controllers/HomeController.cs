using SingularStaffOrders.Controllers.Helpers;
using SingularStaffOrders.Models;
using SingularStaffOrders.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SingularStaffOrders.Controllers
{
    public class HomeController : Controller
    {
        ProductHelper productHelper = new ProductHelper();

        public ActionResult Index()
        {
            List<ProductsViewModel> products = new List<ProductsViewModel>();
            products = productHelper.GetProducts();
            return View(products);
        }

        /// <summary>
        /// Get product details for the specific product
        /// i.e when you click the product image
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public ActionResult ViewProduct(int ProductID)
        {
            ProductsViewModel products = new ProductsViewModel();
            products = productHelper.GetProductById(ProductID);
            return View(products);
        }

        /// <summary>
        /// Add products to Cart
        /// </summary>
        /// <param name="productsViewModel"></param>
        /// <returns></returns>
        public ActionResult AddToCart(ProductsViewModel productsViewModel)
        {
            ProductsViewModel product = new ProductsViewModel();
            product = productHelper.GetProductById(productsViewModel.ProductId);

            List<ProductsViewModel> products = Utility.SessionContext.ProductsInCart;
            products.Add(product);
            Utility.SessionContext.ProductsInCart = products;
            Utility.SessionContext.NoOfItemsInCart = products.Count();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK,"Item Added to cart");
        }

        /// <summary>
        /// Update Cart quantity this happens on the browser
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateQuantity(CartItem model)
        {
            string buttonValue = Request["submitButton"];

            if (buttonValue == "minus")
            {
                var cart = Utility.SessionContext.ProductsInCart.Where(c => c.ProductId == model.Product.ProductId);
                var item = cart.LastOrDefault();
                Utility.SessionContext.ProductsInCart.Remove(item);
            }
            else if (buttonValue == "plus")
            {
                List<ProductsViewModel> li = Utility.SessionContext.ProductsInCart?.ToList();

                li.Add(model.Product);

                Utility.SessionContext.ProductsInCart = li;
            }

            Utility.SessionContext.NoOfItemsInCart = Utility.SessionContext.ProductsInCart.Count();

            return new HttpStatusCodeResult(HttpStatusCode.OK, "Cart updated");
        }

        /// <summary>
        /// Remove Item on the cart 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RemoveFromCart(int productId)
        {
            try
            {
                Utility.SessionContext.ProductsInCart.RemoveAll(X => X.ProductId == productId);
                Utility.SessionContext.NoOfItemsInCart = Utility.SessionContext.ProductsInCart.Count();
            }
            catch (Exception)
            {
                //Some Logging
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}