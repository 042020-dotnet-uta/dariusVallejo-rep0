using System;
using System.Collections.Generic;
using System.Linq;

namespace p0
{
    class OrderManager
    {
        private Customer customer;

        public OrderManager(Customer customer)
        {
            this.customer = customer;
        }

        public void prompt()
        {
            using (var bc = new BusinessContext())
            {
                List<Location> locations = bc.Locations.ToList();
                Console.WriteLine("Select from list of stores");
                for (int i = 0; i < locations.Count(); i++)
                {
                    Console.WriteLine("{0}: {1}", (i + 1), locations[i].LocationId);
                }
                Console.WriteLine("0: Go Back");
                int choice;
                bool valid;
                do
                {
                    valid = Int32.TryParse(Console.ReadLine(), out choice);
                    Console.WriteLine(choice);
                    valid = valid && (choice < locations.Count());
                    if (!valid)
                    {
                        Console.WriteLine("Please input a valid option.");
                    }
                    else if (choice == 0)
                    {
                        return;
                    }
                } while (!valid);
                search(locations[choice - 1].LocationId);
            }
            
        }

        public void search(string locationId)
        {
            using (var bc = new BusinessContext())
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


                bool ordering = true;
                while (ordering)
                {
                    Console.WriteLine("Select an option: ");
                    var availableInventory = inventories.Where(i => i.LocationId.Equals(locationId)).ToList();
                    Inventory selectedProduct;
                    foreach (Inventory inventory in availableInventory)
                    {
                        Console.WriteLine("{0} : {1} : {2}", inventory.productName, inventory.productPrice, inventory.quantity);

                    }
                    Console.WriteLine("0 : Finalize Order");

                    // Selecting Product
                    string choice;
                    bool valid;
                    do
                    {
                        choice = Console.ReadLine();
                        selectedProduct = inventories.Where(i => i.productName.Equals(choice)).FirstOrDefault();
                        valid = (selectedProduct != null);
                        if (choice.Equals("0"))
                        {
                            ordering = false;
                            break;
                        }
                        else if (!valid)
                        {
                            Console.WriteLine("Please input a valid option.");
                        }
                    } while (!valid);

                    // Selecting Quantity
                    if (!ordering)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Select quantity: ");
                        int selectedQuantity;
                        do
                        {
                            valid = Int32.TryParse(Console.ReadLine(), out selectedQuantity);
                            valid = valid && (selectedQuantity <= selectedProduct.quantity);
                            if (!valid)
                            {
                                Console.WriteLine("Please input a valid option.");
                            }
                        } while (!valid);

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
            }
        }
    }
}
