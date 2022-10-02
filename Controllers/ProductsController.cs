using SingularStaffOrders.Controllers.ControllerHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingularStaffOrders.Controllers
{
    public class ProductsController : Controller
    {
        ProductHelper productHelper = new ProductHelper();
        public ProductsController()
        { }

        // GET: Products
        public ActionResult Index()
        {
            Models.ViewModels.ProductsViewModel products = new Models.ViewModels.ProductsViewModel();
            products = productHelper.GetProducts();
            return View(products);
        }

    }
} 