﻿using System.Collections.Generic;
using System.Linq;

namespace p0
{
    class Info
    {
        public static List<Order> locationDetails(string locationName)
        {
            using (var bc = new BusinessContext())
            {
                string locationId = bc.Locations.Where(l => l.locationName == locationName).FirstOrDefault().LocationId;
                List<Order> orders = bc.Orders.Where(o => o.LocationId == locationId).ToList();
                return orders;
            }
        }

        public static List<Order> customerOrders(string firstName, string lastName)
        {
            using (var bc = new BusinessContext())
            {
                string customerId = bc.Customers.Where(c => (c.firstName == firstName && c.lastName == lastName)).FirstOrDefault().CustomerId;
                List<Order> orders = bc.Orders.Where(o => o.CustomerId == customerId).ToList();
                return orders;
            }
        }

        public static List<Customer> customersLike(string firstName, string lastName)
        {
            using (var bc = new BusinessContext())
            {
                return bc.Customers.Where(c => (c.firstName.Contains(firstName) || c.lastName.Contains(lastName))).ToList();
            }
        }

        public static List<OrderItem> orderDetails(string orderId)
        {
            using (var bc = new BusinessContext())
            {
                return bc.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
            }
        }
    }
}
