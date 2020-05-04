using System;
using System.Text.RegularExpressions;

namespace CodingChallengeWeek3
{
    /// <summary>
    /// Static helper for validating different types of user input and returning the correct value
    /// </summary>
    class Prompter
    {
        /// <summary>
        /// Continually Pompts the Console for a valid Int32 input value
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="limit">Value that the input integer must be less than to validate</param>
        /// <returns>A valid Int32 value from Console</returns>
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
        /// Continually prompts the user for a valid alphanumeric input string
        /// </summary>
        /// <param name="prompt">The prompt to print to the console</param>
        /// <returns>A valid alphanumeric string from Console</returns>
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
        /// Continually prompts the Console for a valid non-empty string input value
        /// </summary>
        /// <param name="prompt">The prompt to print to the console</param>
        /// <returns>A valid non-empty string from the Console</returns>
        public static string InputString(string prompt)
        {
            bool valid;
            string input;
            do
            {
                Console.WriteLine("Please input " + prompt);
                input = Console.ReadLine();
                valid = Regex.IsMatch(input, "^(?!\\s*$).+");
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
