using System;
using System.Collections.Generic;

namespace p0.UI
{
    /// <summary>
    /// Simple UI presenting login / account creation options
    /// </summary>
    class LoginUI : UserInterface
    {
        // Options list required public by interface
        public List<string> options { get; set; }

        /// <summary>
        /// Builds the options for the menu
        /// </summary>
        public LoginUI()
        {
            Console.Clear();
            build();
        }

        /// <summary>
        /// Initializes the options selection menu with choices
        /// </summary>
        public void build()
        {
            options = new List<string>()
            {
                "Go Back",
                "Login",
                "Create Account"
            };
        }

        /// <summary>
        /// Prints the contents of the options list to the screen and awaits valid user input
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
        /// Primary selector following valid user choice input
        /// </summary>
        /// <param name="choice">Integer choice value from user</param>
        public void select(int choice)
        {
            using (var bc = new BusinessContext())
            {
                switch (choice)
                {
                    case 1:
                        Customer returnCustomer = new CustomerManager(bc).login(Prompter.validatedInputString("First Name"), Prompter.validatedInputString("Last Name"));
                        if (returnCustomer == null)
                        {
                            Console.WriteLine("Invalid login");
                        }
                        else
                        {
                            new CustomerUI(returnCustomer).prompt();
                        }
                        break;
                    case 2:
                        Customer newCustomer = new CustomerManager(bc).create(Prompter.validatedInputString("First Name"), Prompter.validatedInputString("Last Name"));
                        if (newCustomer == null)
                        {
                            Console.WriteLine("Customer already exists");
                        }
                        else
                        {
                            new CustomerUI(newCustomer).prompt();
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
