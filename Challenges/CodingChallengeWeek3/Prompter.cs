using System;
using System.Text.RegularExpressions;

namespace CodingChallengeWeek3
{
    class Prompter
    {
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
