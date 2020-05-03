using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p0
{
    class Program
    {
        static void Main(string[] args)
        {
            Info info = new Info();
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
                            CustomerManager cm = new CustomerManager(validatedInputString("First Name"), validatedInputString("Last Name"));
                            customer = cm.build();
                            break;
                        case 2:
                            CustomerManager cm2 = new CustomerManager(validatedInputString("First Name"), validatedInputString("Last Name"));
                            cm2.search();
                            break;
                        case 3:
                            var details = info.orderDetails(validatedInputString("order id"));
                            foreach (var detail in details)
                            {
                                Console.WriteLine(detail.ToString());
                            }
                            break;
                        case 4:
                            string locationName = validatedInputString("store location name");
                            var result = info.locationDetails(locationName);
                            foreach (var r in result)
                            {
                                Console.WriteLine(r.ToString());
                            }
                            break;
                        case 5:
                            var orders = info.customerOrders(validatedInputString("First Name"), validatedInputString("Last Name")).ToList();
                            foreach (var o in orders)
                            {
                                Console.WriteLine(o.ToString());
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
        private static string validatedInputString(string prompt)
        {
            bool valid;
            string input;
            do
            {
                Console.WriteLine("Please input " + prompt);
                input = Console.ReadLine();
                valid = Regex.IsMatch(input, "[a-zA-Z]");
                if (!valid)
                {
                    Console.WriteLine("Please input a valid string.");
                }
                else
                {
                    return input;
                }
            } while (!valid);
            return null;
        }

    }
}
