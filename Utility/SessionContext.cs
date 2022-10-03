﻿using SingularStaffOrders.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Utility
{
    public class SessionContext
    {
        public static int NoOfItemsInCart
        {
            get
            {
                return HttpContext.Current.Session["NoOfItemsInCart"] == null ? 0 : (int)HttpContext.Current.Session["NoOfItemsInCart"];
            }
            set
            {
                HttpContext.Current.Session["NoOfItemsInCart"] = value;
            }
        }

        public static List<ProductsViewModel> ProductsInCart
        {
            get
            {
                return HttpContext.Current.Session["ProductsInCart"] as List<ProductsViewModel> ?? new List<ProductsViewModel>();
            }
            set
            {
                HttpContext.Current.Session["ProductsInCart"] = value;
            }
        }
    }
}