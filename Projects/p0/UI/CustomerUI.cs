﻿using System;
using System.Collections.Generic;
using System.Text;

namespace p0.UI
{
    class CustomerUI : UserInterface
    {
        public List<string> options { get; set; }
        private Customer customer { get; set; }

        public CustomerUI(Customer customer)
        {
            Console.Clear();
            build();
            this.customer = customer;
        }

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
            throw new NotImplementedException();
        }
    }
}
