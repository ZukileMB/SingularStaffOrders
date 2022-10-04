using System;
using System.Collections.Generic;
using SingularStaffOrders.Models.ViewModels;
using SingularStaffOrders.Models;
using SingularStaffOrders.Controllers.Helpers;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using SingularStaffOrders.Models.MyDBContext;

namespace SingularStaffOrders.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerHelper customerHelper = new CustomerHelper();
        // GET: Customer
        public ActionResult Index()
        {
            List<CustomerViewModel> customerList = new List<CustomerViewModel>();
            try
            {
                customerList = customerHelper.GetAllCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured when loading customer details " + ex.Message);
            }
            return View(customerList);
        }

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerHelper.SaveCutomer(customerViewModel);
                    return RedirectToAction("Index", "Customer");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to add new customer please try again" + ex.Message);
            }
            return View(customerViewModel);
        }

        public ActionResult Edit(int CustomerId)
        {
            CustomerViewModel CustomerViewModel = new CustomerViewModel();
            try
            {
                DatabaseContext DbContext = new DatabaseContext();
                Customer customer = DbContext.Customer.Where(n => n.CustomerID == CustomerId).FirstOrDefault();

                if (customer != null)
                {
                    CustomerViewModel.CustomerId = customer.CustomerID;
                    CustomerViewModel.Surname = customer.Surname;
                    CustomerViewModel.FirstName = customer.FirstName;
                    CustomerViewModel.AddressType = customer.AddressType;
                    CustomerViewModel.Surburb = customer.Surburb;
                    CustomerViewModel.StreetAddress = customer.StreetAddress;
                    CustomerViewModel.City = customer.City;
                    CustomerViewModel.PostalCode = customer.PostalCode;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("An error when trying to edit customer" + ex.Message);
            }

            return View(CustomerViewModel);     
        }

        /// <summary>
        /// Edit customer
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerHelper.UpdateCustomer(customerViewModel);
                    return RedirectToAction("Index", "Customer");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to add new customer please try again" + ex.Message);
            }
            return View(customerViewModel);
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ActionResult Delete (int CustomerId)
        {
            try
            {
                customerHelper.DeleteCustomer(CustomerId);
            }catch (Exception ex)
            {
                throw new Exception("Cannot delete customer"+ex.Message);   
            }
            return RedirectToAction("Index");
        }
    }
}