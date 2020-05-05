using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace p0
{
    public class CustomerManager
    {
        private BusinessContext bc;

        public CustomerManager(BusinessContext bc)
        {
            this.bc = bc;
        }

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

        public Customer login(string firstName, string lastName)
        {
            Customer customer = bc.Customers.Where(c => (c.FirstName == firstName) && (c.LastName == lastName)).Include(c => c.Orders).FirstOrDefault();
            return customer;
        }
    }
}
