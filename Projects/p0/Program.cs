using System;

namespace p0
{
    class Program
    {
        static void Main(string[] args)
        {
            bool selecting = true;
            Customer customer = null;

            Console.WriteLine("Welcome to my store!");

            while (selecting) 
            {
                Console.WriteLine("1. Login / Signup");
                Console.WriteLine("2. Search customers by name");
                Console.WriteLine("3. Display details of an order");
                Console.WriteLine("4. Display all order history of a store location");
                Console.WriteLine("5. Display all order history of a customer");
                //
                Console.WriteLine("6. Place an order");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option: ");

                try
                {
                    string input = Console.ReadLine();
                    int choice = Int32.Parse(input);
                    switch (choice)
                    {
                        case 1:
                            CustomerManager cm = new CustomerManager();
                            customer = cm.build();
                            break;
                        case 2:
                            CustomerManager cm2 = new CustomerManager();
                            cm2.search();
                            break;
                        case 3:
                            // Display details of an order
                            // select
                            // *
                            // from Orders
                            // where OrderId = input();
                            break;
                        case 4:
                            // Display all order history of a store location
                            // select
                            // *
                            // from Orders
                            // where LocationId = input();
                            break;
                        case 5:
                            CustomerManager cm5 = new CustomerManager();
                            Customer search = cm5.find();
                            if (search != null)
                            {
                                OrderManager om5 = new OrderManager(search);
                                om5.print();
                            } else
                            {
                                Console.WriteLine("No results found.");
                            }

                            break;
                        case 6:
                            if (customer == null)
                            {
                                Console.WriteLine("You must be logged in to do that. ");
                            } else
                            {
                                OrderManager om6 = new OrderManager(customer);
                                om6.prompt();
                            }
                            break;
                        case 0:
                            Console.WriteLine("Exiting...");
                            selecting = false;
                            break;
                        default:
                            Console.WriteLine("Please select a valid option");
                            break;
                    }
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
            
    }
}
