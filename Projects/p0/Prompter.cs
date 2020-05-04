using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace p0
{
    class Prompter
    {
        public static int validatedInputInteger(string prompt, int limit)
        {
            int choice;
            bool valid;
            do
            {
                Console.WriteLine("Please input " + prompt);
                valid = Int32.TryParse(Console.ReadLine(), out choice);
                if (!valid || (choice > limit))
                {
                    Console.WriteLine("Please input a valid option.");
                }
                else
                {
                    return choice;
                }
            } while (!valid);
            return 0;
        }

        public static string validatedInputString(string prompt)
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
