using CodingChallengeWeek3;
using System;
using System.Collections.Generic;

namespace p0
{
    /// <summary>
    /// Basic UI for presenting options, ferrying selections
    /// </summary>
    class BaseUI : UserInterface
    {
        public List<string> options { get; set; }
        private BaseController bc { get; set; }

        public BaseUI()
        {
            bc = new BaseController();
            Console.Clear();
            build();
        }

        /// <summary>
        /// Initalizes the UI's list with desired options
        /// </summary>
        public void build()
        {
            options = new List<string>()
            {
                "Exit",
                "Is the number even?",
                "Multiplication Table",
                "Alternating Elements"
            };
        }

        /// <summary>
        /// Prints the options from the options list and gathers user choice
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
        /// Switch logic for decision making based on choice value
        /// </summary>
        /// <param name="choice">Number of choice selected by user</param>
        public void select(int choice)
        {
            switch (choice)
            {
                // isEven(), checks if a valid input integer is even
                case 1:
                    int value = Prompter.validatedInputInteger("integer", Int32.MaxValue);
                    bool isEven = bc.isEven(value);
                    Console.WriteLine("It is {0} that the input value {1} is even", isEven, value);
                    break;
                // MultTable(), takes input integer and prints its multiplication table
                case 2:
                    int input = Prompter.validatedInputInteger("integer", Int32.MaxValue);
                    List<string> table = bc.MultTable(input);
                    for (int i = 0; i < table.Count; i++)
                    {
                        Console.WriteLine(table[i]);
                    }
                    break;
                // Shuffle(), creates two lists populated with non-empty input strings and prints their elements in alternating order
                case 3:
                    int limit = 5;
                    List<string> listA = new List<string>();
                    List<string> listB = new List<string>();
                    for (int i = 0; i < limit; i++)
                    {
                        int index = i + 1;
                        listA.Add(Prompter.InputString("value " + index + " for first list"));
                    }
                    for (int i = 0; i < limit; i++)
                    {
                        int index = i + 1;
                        listB.Add(Prompter.InputString("value " + index + " for second list"));
                    }
                    List<string> intersected = bc.Shuffle(listA, listB, limit);
                    foreach (string s in intersected)
                    {
                        Console.Write("{0} ", s);
                    }
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }
}