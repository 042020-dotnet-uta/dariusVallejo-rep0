using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace p0
{
    /// <summary>
    /// Manages order creation
    /// </summary>
    class OrderManager
    {
        private Customer customer;
        private BusinessContext bc;

        /// <summary>
        /// Builds the manager with a specific customer and database context
        /// </summary>
        /// <param name="customer">The customer that is making the orders</param>
        /// <param name="bc">The databse context to use</param>
        public OrderManager(Customer customer, BusinessContext bc)
        {
            this.customer = customer;
            this.bc = bc;

        }

        /// <summary>
        /// Prompts the console with a list of store locations, awaits valid input
        /// </summary>
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

        /// <summary>
        /// Main order placing logic, presents options for placing order based on location
        /// </summary>
        /// <param name="locationId">The location id for matching store inventory</param>
        public void search(string locationId)
        {
            List<Inventory> inventories = bc.Inventory.ToList();
            List<Product> products = bc.Products.ToList();
            string orderId = Guid.NewGuid().ToString();

            // Create new order
            Order order = new Order()
            {
                OrderId = orderId,
                CustomerId = customer.CustomerId,
                LocationId = locationId,
                OrderItems = new List<OrderItem>(),
                Total = 0
            };

            // While we're still placing an order...
            while (true)
            {
                // Show available inventory, await user choice
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

                inventory = available[index - 1];
                product = products.Where(p => p.ProductId == inventory.ProductId).FirstOrDefault(); 
                int quantity = Prompter.validatedInputInteger("quantity", inventory.Quantity);
                
                // If we've added an item...
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
