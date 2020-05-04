using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace p0
{
    class CustomerManager
    {
        public Customer create(string firstName, string lastName)
        {
            using (var bc = new BusinessContext())
            {
                Customer customer = new Customer { CustomerId = Guid.NewGuid().ToString(), firstName = firstName, lastName = lastName, orders = new List<Order>() };
                bc.Customers.Add(customer);
                bc.SaveChanges();
                return customer;
            }
        }

        public Customer login(string firstName, string lastName)
        {
            using (var bc = new BusinessContext())
            {
                Customer customer = bc.Customers.Where(c => (c.firstName == firstName) && (c.lastName == lastName)).Include(c => c.orders).FirstOrDefault();
                return customer;
            }
        }
    }
}
