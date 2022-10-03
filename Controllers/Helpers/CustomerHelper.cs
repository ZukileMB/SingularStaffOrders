using SingularStaffOrders.Models;
using SingularStaffOrders.Models.MyDBContext;
using SingularStaffOrders.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingularStaffOrders.Controllers.Helpers
{
    public class CustomerHelper 
    {
        private DatabaseContext db = new DatabaseContext();

        /// <summary>
        /// Get all Customers from the customer table
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            customers = db.Customer.ToList();
            return customers;
        }

        /// <summary>
        /// Add new Customer details 
        /// </summary>
        /// <param name="customerView"></param>
        public void SaveCutomer( CustomerViewModel customerView)
        {
            Customer customer = new Customer();
            customer.FirstName =customerView.FirstName;
            customer.Surname = customerView.Surname;
            customer.AddressType = customerView.AddressType;
            customer.StreetAddress = customerView.StreetAddress;
            customer.City = customerView.City;  
            customer.PostalCode = customerView.PostalCode;  

            db.Customer.Add(customer);
            db.SaveChanges();
        }

        /// <summary>
        /// Update customer details
        /// </summary>
        /// <param name="customerID"></param>
        public void UpdateCustomer(int customerID)
        {
            CustomerViewModel customerView = new CustomerViewModel();
            Customer customer = (from x in db.Customer where x.CustomerID == customerID select x).FirstOrDefault();
             if (customer != null)
            {
                customer.FirstName = customerView.FirstName;
                customer.Surname = customerView.Surname;
                customer.AddressType = customerView.AddressType;
                customer.StreetAddress = customerView.StreetAddress;
                customer.City = customerView.City;
                customer.PostalCode= customerView.PostalCode;

                db.SaveChanges();
            }

        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="customerID"></param>
        public void DeleteCustomer(int customerID)
        {
            var update = (from x in db.Customer where x.CustomerID == customerID select x).First();
        }
    }
}