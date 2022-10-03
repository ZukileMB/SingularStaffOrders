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
        public List<CustomerViewModel> GetAllCustomers()
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            var customer = db.Customer;

            foreach (Customer cust in customer)
            {
                CustomerViewModel viewModel = new CustomerViewModel
                {
                    CustomerId = cust.CustomerID,
                    FirstName = cust.FirstName,
                    Surname = cust.Surname,
                    AddressType = cust.AddressType,
                    City = cust.City,
                    PostalCode = cust.PostalCode,
                    StreetAddress = cust.StreetAddress,
                    Surburb = cust.Surburb,
                };
                customers.Add(viewModel);
            }

            return customers;
        }

        /// <summary>
        /// Add new Customer details 
        /// </summary>
        /// <param name="customerView"></param>
        public void SaveCutomer(CustomerViewModel customerView)
        {
            Customer customer = new Customer();
            customer.FirstName = customerView.FirstName;
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
        public void UpdateCustomer(CustomerViewModel customerView)
        {
            Customer customer = db.Customer.Where(x => x.CustomerID == customerView.CustomerId).FirstOrDefault();
            if (customer != null)
            {
                customer.FirstName = customerView.FirstName;
                customer.Surname = customerView.Surname;
                customer.AddressType = customerView.AddressType;
                customer.StreetAddress = customerView.StreetAddress;
                customer.City = customerView.City;
                customer.PostalCode = customerView.PostalCode;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="customerID"></param>
        public void DeleteCustomer(int customerID)
        {
            Customer customer = db.Customer.Where(x => x.CustomerID == customerID).FirstOrDefault();
            if (customer != null)
            {
                throw new Exception("Error when deleting customer");
            }
            db.Customer.Remove(customer);
            db.SaveChanges();
        }
    }
}