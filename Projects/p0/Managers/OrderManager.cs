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
                Console.WriteLine("{0}: {1}", (i + 1), locations[i].LocationId);
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
            string orderId = Guid.NewGuid().ToString();

            Order order = new Order()
            {
                OrderId = orderId,
                CustomerId = customer.CustomerId,
                LocationId = locationId,
                orderItems = new List<OrderItem>(),
                total = 0
            };


            while (true)
            {
                var availableInventory = inventories.Where(i => i.LocationId.Equals(locationId)).ToList();
                for (int i = 0; i < availableInventory.Count(); i++)
                {
                    var inventory = availableInventory[i];
                    Console.WriteLine("{0} : {1} : {2} : {3}", i + 1, inventory.productName, inventory.productPrice, inventory.quantity);

                }
                Console.WriteLine("0 : Finish");

                int index = Prompter.validatedInputInteger("selection", availableInventory.Count());
                if (index == 0)
                {
                    break;

                }
                Inventory selectedProduct = availableInventory[index - 1];

                int selectedQuantity = Prompter.validatedInputInteger("quantity", selectedProduct.quantity + 1);
                if (selectedQuantity > 0)
                {
                    // Check if there is an existing order item for this product...
                    OrderItem orderItem = order.orderItems.Where(oi => (oi.OrderId == orderId) && (oi.ProductName == selectedProduct.productName)).FirstOrDefault();

                    // If there isn't, create one
                    if (orderItem == null)
                    {
                        orderItem = new OrderItem
                        {
                            OrderItemId = Guid.NewGuid().ToString(),
                            OrderId = orderId,
                            ProductName = selectedProduct.productName,
                            quantity = selectedQuantity
                        };
                        order.orderItems.Add(orderItem);
                        bc.OrderItems.Add(orderItem);
                    }

                    // Otherwise, just update the quantity of the order item
                    else
                    {
                        orderItem.quantity = orderItem.quantity + selectedQuantity;
                    }
                    order.total = order.total + (selectedQuantity * selectedProduct.productPrice);
                    selectedProduct.quantity = selectedProduct.quantity - selectedQuantity;
                    bc.Update(selectedProduct);
                }
            }

            // If we've added items to our order...
            if (order.orderItems.Count > 0)
            {
                order.orderDate = DateTime.Now.ToString();
                customer.orders.Add(order);
                bc.Add(order);
                bc.SaveChanges();
                Console.WriteLine("Placed Order: {0} for {1} under Customer: {2} {3} at {4}", order.OrderId, order.total, customer.firstName, customer.lastName, order.orderDate);
            }
            prompt();
        }
    }
}
