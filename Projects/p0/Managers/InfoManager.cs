using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace p0
{
    public class InfoManager
    {
        private BusinessContext bc;

        public InfoManager(BusinessContext bc)
        {
            this.bc = bc;
        }
        public List<Order> locationDetails(string locationName)
        {
            List<Order> orders;
            Location location = bc.Locations.Where(l => l.locationName == locationName).FirstOrDefault();
            if (location != null)
            {
                orders = bc.Orders.Where(o => o.LocationId == location.LocationId).ToList();
            } else
            {
                orders = null;
            }
            return orders;
        }

        public List<Order> customerOrders(string customerId)
        {
            List<Order> orders;
            Customer customer = bc.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            if (customer != null)
            {
                orders = bc.Orders.Where(o => o.CustomerId == customer.CustomerId).ToList();
            }
            else
            {
                orders = null;
            }
            return orders;
        }

        public List<Customer> customersLike(string firstName, string lastName)
        {
            return bc.Customers.Where(c => (c.firstName.Contains(firstName) || c.lastName.Contains(lastName))).ToList();
        }

        public List<OrderItem> orderDetails(string orderId, string customerId)
        {
            List<OrderItem> orderItems;
            if (customerId != null)
            {
                Order orders = bc.Orders.Where(o => o.OrderId == orderId && o.CustomerId == customerId).Include(o => o.orderItems).FirstOrDefault();
                if (orders != null)
                {
                    orderItems = orders.orderItems;
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
