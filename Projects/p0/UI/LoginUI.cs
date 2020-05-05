using System;
using System.Collections.Generic;

namespace p0.UI
{
    class LoginUI : UserInterface
    {
        public List<string> options { get; set; }

        public LoginUI()
        {
            Console.Clear();
            build();
        }

        public void build()
        {
            options = new List<string>()
            {
                "Go Back",
                "Login",
                "Create Account"
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
            }
        }
    }
}
