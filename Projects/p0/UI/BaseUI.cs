using p0.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace p0
{
    class BaseUI : UserInterface
    {
        public List<string> options { get; set; }

        public BaseUI()
        {
            Console.Clear();
            build();
        }

        public void build()
        {
            options = new List<string>()
            {
                "Exit",
                "Login / Signup",
                "Search customers by name",
                "Display details of an order",
                "Display all order history of a store location",
                "Display all order history of a customer",
                "Place an order"
            };
        }

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

        public void select(int choice)
        {
            switch (choice)
            {
                case 1:
                    new LoginUI().prompt();
                    break;
                case 2:
                    var customers = Info.customersLike(Prompter.validatedInputString("First Name"), Prompter.validatedInputString("Last Name"));
                    foreach (var c in customers)
                    {
                        Console.WriteLine(c.ToString());
                    }
                    break;
                case 3:
                    var details = Info.orderDetails(Prompter.validatedInputString("order id"), null);
                    foreach (var detail in details)
                    {
                        Console.WriteLine(detail.ToString());
                    }
                    break;
                case 4:
                    var result = Info.locationDetails(Prompter.validatedInputString("store location name"));
                    foreach (var r in result)
                    {
                        Console.WriteLine(r.ToString());
                    }
                    break;
                case 5:
                    var orders = Info.customerOrders(null);
                    foreach (var o in orders)
                    {
                        Console.WriteLine(o.ToString());
                    }
                    break;
                case 6:
                    Console.WriteLine("You must be logged in to do that. ")
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }
}