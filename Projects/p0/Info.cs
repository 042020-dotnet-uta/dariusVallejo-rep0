using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public static List<Order> customerOrders(string customerId)
        {
            using (var bc = new BusinessContext())
            {
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

        public static List<OrderItem> orderDetails(string orderId, string customerId)
        {
            using (var bc = new BusinessContext())
            {
                List<OrderItem> orderItems;
                if (customerId != null)
                {
                    Order orders = bc.Orders.Where(o => o.OrderId == orderId && o.CustomerId == customerId).Include(o => o.orderItems).FirstOrDefault();
                    if (orders == null)
                    {
                        orderItems = null;
                    } else
                    {
                        orderItems = orders.orderItems;
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
}
