using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace p0
{
    /// <summary>
    /// Manages making simple informational queries from the database
    /// </summary>
    public class InfoManager
    {
        private BusinessContext bc;

        /// <summary>
        /// Creates this object with a database context to set
        /// </summary>
        /// <param name="bc">The database context to use for queries</param>
        public InfoManager(BusinessContext bc)
        {
            this.bc = bc;
        }

        /// <summary>
        /// Finds all the orders belonging to a particular location name
        /// </summary>
        /// <param name="locationName">The name of the location to search for</param>
        /// <returns>A list of orders belonging to a valid location, null if invalid</returns>
        public List<Order> locationDetails(string locationName)
        {
            List<Order> orders;
            Location location = bc.Locations.Where(l => l.LocationName == locationName).FirstOrDefault();
            try
            {
                orders = bc.Orders.Where(o => o.LocationId == location.LocationId).ToList();
            }
            catch (InvalidOperationException exception)
            {
                orders = null;
            }
            return orders;
        }

        /// <summary>
        /// Finds all the orders belonging to a particular customer
        /// </summary>
        /// <param name="customerId">The customer id used to find matching orders</param>
        /// <returns>A list of orders for a customer if valid, null otherwise</returns>
        public List<Order> customerOrders(string customerId)
        {
            List<Order> orders;
            Customer customer = bc.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            try
            {
                orders = bc.Orders.Where(o => o.CustomerId == customer.CustomerId).ToList();
            }
            catch (InvalidOperationException exception)
            {
                orders = null;
            }
            return orders;
        }

        /// <summary>
        /// Finds a customer that matches the input parameters
        /// </summary>
        /// <param name="firstName">The first name of the customer</param>
        /// <param name="lastName">The second name of the customer</param>
        /// <returns>The customer matching the inputs if found, null otherwise</returns>
        public Customer customersLike(string firstName, string lastName)
        {
            return bc.Customers.Where(c => c.FirstName == firstName && c.LastName == lastName).FirstOrDefault();
        }

        /// <summary>
        /// Finds all the order items belonging to a particular order
        /// </summary>
        /// <param name="orderId">The order id to search for</param>
        /// <param name="customerId">The customer id to search for</param>
        /// <returns>A list of the order items if valid order id and customer id, null otherwise</returns>
        public List<OrderItem> orderDetails(string orderId, string customerId)
        {
            List<OrderItem> orderItems;
            if (customerId != null)
            {

                Order orders = bc.Orders.Where(o => o.OrderId == orderId && o.CustomerId == customerId).Include(o => o.OrderItems).FirstOrDefault();
                if (orders != null)
                {
                    orderItems = orders.OrderItems;

                }
                else
                {
                    orderItems = null;

                }
            }
            else
            {
                orderItems = bc.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
            }
            return orderItems;
        }
    }
}
