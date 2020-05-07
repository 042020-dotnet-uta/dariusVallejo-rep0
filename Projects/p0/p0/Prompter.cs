using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace p0
{
    /// <summary>
    /// Helper class for prompting user input and returning the converted input
    /// </summary>
    class Prompter
    {
        /// <summary>
        /// Prompts the console for an integer, then awaits valid integer input from user
        /// </summary>
        /// <param name="prompt">The input prompt to print to the console</param>
        /// <param name="limit">The limit of the input value + 1</param>
        /// <returns>A valid integer</returns>
        public static int validatedInputInteger(string prompt, int limit)
        {
            bool valid;
            int input;
            do
            {
                Console.WriteLine("Please input " + prompt);
                valid = Int32.TryParse(Console.ReadLine(), out input);
                if (!valid || (input > limit))
                {
                    Console.WriteLine("Please input a valid option.");
                }
                else
                {
                    return input;
                }
            } while (!valid);
            return 0;
        }

        /// <summary>
        /// Prompts the console for a string and awaits valid alphabetic string input
        /// </summary>
        /// <param name="prompt">The input prompt to print to the console</param>
        /// <returns>A valid alphabetic string from the console</returns>
        public static string validatedInputString(string prompt)
        {
            bool valid;
            string input;
            do
            {
                Console.WriteLine("Please input " + prompt);
                input = Console.ReadLine();
                valid = Regex.IsMatch(input, "^[a-zA-Z]+$");
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

        /// <summary>
        /// Prompts the console for a string, the awaits a valid alphanumeric and/or hyphenated string
        /// </summary>
        /// <param name="prompt">The input prompt to print to the console</param>
        /// <returns>A valid alphanumeric and/or hyphenated string</returns>
        public static string InputString(string prompt)
        {
            bool valid;
            string input;
            do
            {
                Console.WriteLine("Please input " + prompt);
                input = Console.ReadLine();
                valid = Regex.IsMatch(input, "^[a-zA-Z0-9\\-]+$");
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
