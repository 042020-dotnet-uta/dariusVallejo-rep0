using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace p0
{
    /// <summary>
    /// Manages / Updates database context for customer models
    /// </summary>
    public class CustomerManager
    {
        private BusinessContext bc;

        /// <summary>
        /// Constructor accepting the database context to use
        /// </summary>
        /// <param name="bc">The database context to use</param>
        public CustomerManager(BusinessContext bc)
        {
            this.bc = bc;
        }

        /// <summary>
        /// Creates a customer from valid input parameters if no matching customer exists
        /// </summary>
        /// <param name="firstName">The first name of the customer</param>
        /// <param name="lastName">The last name of the customer</param>
        /// <returns>A customer model if creation successful, null otherwise</returns>
        public Customer create(string firstName, string lastName)
        {
            Customer customer = bc.Customers.Where(c => (c.FirstName == firstName) && (c.LastName == lastName)).Include(c => c.Orders).FirstOrDefault();
            if (customer == null)
            {
                customer = new Customer { CustomerId = Guid.NewGuid().ToString(), FirstName = firstName, LastName = lastName, Orders = new List<Order>() };
                bc.Customers.Add(customer);
                bc.SaveChanges();
                return customer;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Provides the customer model matching the provided inputs
        /// </summary>
        /// <param name="firstName">The first name of the customer to match</param>
        /// <param name="lastName">The last name of the customer to match</param>
        /// <returns>The customer model if it exists, null otherwise</returns>
        public Customer login(string firstName, string lastName)
        {
            Customer customer = bc.Customers.Where(c => (c.FirstName == firstName) && (c.LastName == lastName)).Include(c => c.Orders).FirstOrDefault();
            return customer;
        }
    }
}
