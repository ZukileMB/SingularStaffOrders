using SingularStaffOrders.Models.MyDBContext;
using SingularStaffOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SingularStaffOrders.Models.ViewModels;

namespace SingularStaffOrders.Controllers.Helpers
{
    public class ProductHelper
    {
        private DatabaseContext db = new DatabaseContext();

        /// <summary>
        ///  Get all products 
        /// </summary>
        /// <returns></returns>
        public List<ProductsViewModel> GetProducts()
        {
            List<ProductsViewModel> productsViewModel = new List<ProductsViewModel>();
            productsViewModel = db.Products.ToList().Select(product => MapProductViewModel(product)).ToList();

            return productsViewModel;
        }

        /// <summary>
        /// Get selected product 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public ProductsViewModel GetProductById(int ProductId)
        {
            Product product = new Product();
            product = db.Products.Where(a => a.ProductId == ProductId).FirstOrDefault();
            if (product != null)
            {
                return MapProductViewModel(product);
            }
            throw new Exception("No products found for the selected ID");
        }

        /// <summary>
        /// Get all products from Products Table 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            products = db.Products.ToList();
            return products;
        }

        /// <summary>
        /// Transferring data from DB object to viewModel
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private ProductsViewModel MapProductViewModel(Product product)
        {
            return new ProductsViewModel
            {
                ProductId = product.ProductId,
                Description = product.Description,
                Image = product.Image,
                ProductTitle = product.ProductTitle,
                Price = product.UnitPrice
            };
        }

        /// <summary>
        /// Add Product to the Database
        /// </summary>
        /// <param name="productsViewModel"></param>
        public void SaveProducts(SingularStaffOrders.Models.ViewModels.ProductsViewModel productsViewModel)
        {
            Product products = new Product();
            products.ProductTitle = productsViewModel.ProductTitle;
            products.Description = productsViewModel.Description;
            products.UnitPrice = productsViewModel.Price;
            products.Image = productsViewModel.Image;

            db.Products.Add(products);
            db.SaveChanges();
        }

        /// <summary> 
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string ConvertToCurrency(decimal amount)
        {
            return string.Format("{0:#.00}", amount);
        }
    }
}