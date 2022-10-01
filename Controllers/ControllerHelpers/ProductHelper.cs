using SingularStaffOrders.Models.MyDBContext;
using SingularStaffOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingularStaffOrders.Controllers.ControllerHelpers
{
    public class ProductHelper
    {
        private DatabaseContext db = new DatabaseContext();
       
        public  Models.ViewModels.ProductsViewModel GetProducts()
        {
            Models.ViewModels.ProductsViewModel productsViewModel = new Models.ViewModels.ProductsViewModel();

            productsViewModel.selectListItems = (from a in db.Products
                                                 select new SelectListItem() {
                                                     Text = a.ProductTitle,
                                                     Value = a.ProductId.ToString(),
                                                     Selected = true
                                                 });


            return (productsViewModel);
        }


        /// <summary>
        /// Add Product to the Database
        /// </summary>
        /// <param name="productsViewModel"></param>
        public void SaveProducts(SingularStaffOrders.Models.ViewModels.ProductsViewModel productsViewModel )
        {
            Products products = new Products();
            products.ProductTitle = productsViewModel.ProductTitle;
            products.Description = productsViewModel.Description;
            products.UnitPrice = productsViewModel.Price;
            products.Image = productsViewModel.Image;
           
            db.Products.Add(products);
            db.SaveChanges();
        }
    }
}