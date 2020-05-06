using System;
using System.Collections.Generic;
using System.Linq;

namespace p0.UI
{
    /// <summary>
    /// User Interface presented upon valid login
    /// </summary>
    class CustomerUI : UserInterface
    {
        // Options list public due to interface
        public List<string> options { get; set; }
        private Customer customer { get; set; }

        /// <summary>
        /// Sets up the customer user interface menu
        /// </summary>
        /// <param name="customer">The customer object representing the user after login</param>
        public CustomerUI(Customer customer)
        {
            build();
            this.customer = customer;
        }

        /// <summary>
        /// Initializes the choice selection list with customer specific options
        /// </summary>
        public void build()
        {
            options = new List<string>()
            {
                "Logout",
                "Place an Order",
                "Order History",
                "Order Details"
            };
        }

        /// <summary>
        /// Prints the options list's contents to the screen and awaits valid user input
        /// </summary>
        public void prompt()
        {
            int choice = 0;
            do
            {
                for (int i = 1; i < options.Count; i++)
                {
                    Console.WriteLine("{0} : {1}", i, options[i]);
                }
                Console.WriteLine("{0} : {1}", 0, options[0]);
                choice = Prompter.validatedInputInteger("selection", options.Count);
                if (choice != 0)
                {
                    select(choice);
                }
            } while (choice != 0);
        }

        /// <summary>
        /// Primary selector following valid user choice from available options
        /// </summary>
        /// <param name="choice">Integer value of user choice</param>
        public void select(int choice)
        {
            using (var bc = new BusinessContext())
            {
                InfoManager infoManager = new InfoManager(bc);
                switch (choice)
                {
                    case 1:
                        // Place an order
                        OrderManager manager = new OrderManager(customer, bc);
                        manager.prompt();
                        break;
                    case 2:
                        // Order History
                        var orders = infoManager.customerOrders(customer.CustomerId);
                        if (orders.Count > 0)
                        {
                            var columns = typeof(Order).GetProperties().Select(property => property.Name).ToList();
                            for (int i = 0; i < columns.Count - 1; i++)
                            {
                                Console.Write("{0} ", columns[i]);
                            }
                            Console.WriteLine();
                            foreach (var o in orders)
                            {
                                Console.WriteLine(o.ToString());
                            }
                        } else
                        {
                            Console.WriteLine("No results found");
                        }
                        break;
                    case 3:
                        // Order Details
                        var details = infoManager.orderDetails(Prompter.InputString("order id"), customer.CustomerId);
                        if (details != null)
                        {
                            var columns = typeof(OrderItem).GetProperties().Select(property => property.Name).ToList();
                            for (int i = 0; i < columns.Count; i++)
                            {
                                Console.Write("{0} ", columns[i]);
                            }
                            Console.WriteLine();
                            foreach (var detail in details)
                            {
                                Console.WriteLine(detail.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No results found");
                        }
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
            } Console.WriteLine();
        }
    }
}
