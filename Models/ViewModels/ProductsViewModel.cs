using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingularStaffOrders.Models.ViewModels
{
    public class ProductsViewModel
    {
        public int ProductId { get; set; }
        [Display(Name = "Title")]
        public string ProductTitle { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Unit Price")]
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}