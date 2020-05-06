using System;
using System.Collections.Generic;
using System.Linq;

namespace p0.UI
{
    /// <summary>
    /// Main UI, offers standard options and is last stop before exit
    /// </summary>
    class BaseUI : UserInterface
    {
        // Options list public due to interface
        public List<string> options { get; set; }

        /// <summary>
        /// Sets up the user interface console
        /// </summary>
        public BaseUI()
        {
            build();
        }

        /// <summary>
        /// Populates the the list with standard options (login, etc.) 
        /// </summary>
        public void build()
        {
            options = new List<string>()
            {
                "Exit",
                "Login / Signup",
                "Search customers by name",
                "Display all order history of a store location",
            };
        }

        /// <summary>
        /// Prints available options to the screen and awaits user input / selection
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
        /// Primary selector for user options, will either launch new UI or database manager instances depending
        /// </summary>
        /// <param name="choice">The integer choice value selected by the user</param>
        public void select(int choice)
        {
            using (var bc = new BusinessContext())
            {
                InfoManager infoManager = new InfoManager(bc);
                switch (choice)
                {
                    case 1:
                        new LoginUI().prompt();
                        break;
                    case 2:
                        var customer = infoManager.customersLike(Prompter.validatedInputString("First Name"), Prompter.validatedInputString("Last Name"));
                        if (customer != null)
                        {
                            var columns = typeof(Customer).GetProperties().Select(property => property.Name).ToList();
                            for (int i = 0; i < columns.Count - 1; i++) 
                            {
                                Console.Write("{0} ", columns[i]);
                            }
                            Console.WriteLine();
                            Console.WriteLine(customer.ToString());
                        }
                        else
                        {
                            Console.WriteLine("No results found");
                        }
                        break;
                    case 3:
                        var result = infoManager.locationDetails(Prompter.validatedInputString("store location name"));
                        if (result != null)
                        {
                            var columns = typeof(Order).GetProperties().Select(property => property.Name).ToList();
                            for (int i = 0; i < columns.Count - 1; i++) 
                            {
                                Console.Write("{0} ", columns[i]);
                            }
                            Console.WriteLine();

                            foreach (var r in result)
                            {
                                Console.WriteLine(r.ToString());
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
            }
            Console.WriteLine();
        }
    }
}