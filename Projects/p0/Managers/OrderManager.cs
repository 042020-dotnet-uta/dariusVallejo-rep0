using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace p0
{
    class OrderManager
    {
        private Customer customer;
        private BusinessContext bc;

        public OrderManager(Customer customer, BusinessContext bc)
        {
            this.customer = customer;
            this.bc = bc;

        }

        public void prompt()
        {
            List<Location> locations = bc.Locations.ToList();
            for (int i = 0; i < locations.Count(); i++)
            {
                Console.WriteLine("{0}: {1}", (i + 1), locations[i].LocationName);
            }
            Console.WriteLine("0: Go Back");

            int input = Prompter.validatedInputInteger("store choice", locations.Count());
            if (input == 0)
            {
                return;
            }
            search(locations[input - 1].LocationId);
        }

        public void search(string locationId)
        {
            List<Inventory> inventories = bc.Inventory.ToList();
            List<Product> products = bc.Products.ToList();
            string orderId = Guid.NewGuid().ToString();

            Order order = new Order()
            {
                OrderId = orderId,
                CustomerId = customer.CustomerId,
                LocationId = locationId,
                OrderItems = new List<OrderItem>(),
                Total = 0
            };

            while (true)
            {
                var available = inventories.Where(i => i.LocationId.Equals(locationId)).ToList();
                Inventory inventory;
                Product product;
                for (int i = 0; i < available.Count(); i++)
                {
                    inventory = available[i];
                    product = products.Where(p => p.ProductId == inventory.ProductId).FirstOrDefault();
                    Console.WriteLine("{0} : {1} : {2} : {3}", i + 1, product.ProductName, product.ProductPrice, inventory.Quantity);
                }
                Console.WriteLine("0 : Finish");

                int index = Prompter.validatedInputInteger("selection", available.Count());
                if (index == 0)
                {
                    break;

                }

                // new method?
                inventory = available[index - 1];
                product = products.Where(p => p.ProductId == inventory.ProductId).FirstOrDefault(); 

                int quantity = Prompter.validatedInputInteger("quantity", inventory.Quantity);
                if (quantity > 0)
                {
                    // Check if there is an existing order item for this product...
                    OrderItem orderItem = order.OrderItems.Where(oi => (oi.OrderId == orderId) && (oi.ProductId == product.ProductId)).FirstOrDefault();

                    // If there isn't, create one
                    if (orderItem == null)
                    {
                        orderItem = new OrderItem
                        {
                            OrderItemId = Guid.NewGuid().ToString(),
                            OrderId = orderId,
                            ProductId = product.ProductId,
                            Quantity = quantity
                        };
                        order.OrderItems.Add(orderItem);
                        bc.OrderItems.Add(orderItem);
                    }

                    // Otherwise, just update the quantity of the order item
                    else
                    {
                        orderItem.Quantity = orderItem.Quantity + quantity;
                    }
                    order.Total = order.Total + (quantity * product.ProductPrice);
                    inventory.Quantity = inventory.Quantity - quantity;
                    bc.Update(inventory);
                }
            }

            // If we've added items to our order...
            if (order.OrderItems.Count > 0)
            {
                order.OrderDate = DateTime.Now.ToString();
                customer.Orders.Add(order);
                bc.Add(order);
                bc.SaveChanges();
                Console.WriteLine("Placed Order: {0} for {1} under Customer: {2} {3} at {4}", order.OrderId, order.Total, customer.FirstName, customer.LastName, order.OrderDate);
            }
            prompt();
        }
    }
}
