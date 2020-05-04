using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallengeWeek3
{
    /// <summary>
    /// Handles the calculation logic behind user inputs
    /// </summary>
    class BaseController
    {
        /// <summary>
        /// Returns if an input value is even
        /// </summary>
        /// <param name="value">The value to be checked</param>
        /// <returns>True if divisible by 0, false otherwise</returns>
        public bool isEven(int value)
        {
            return (value % 2 == 0);
        } 

        /// <summary>
        /// Takes an input value and creates a list of factors
        /// </summary>
        /// <param name="value">The value to create the table for</param>
        /// <returns>A list containing strings of multiplication tables</returns>
        public List<string> MultTable(int value)
        {
            List<string> table = new List<string>();
            for (int i = 1; i <= value; i++)
            {
                for (int k = 1; k <= value; k++)
                {
                    table.Add(i + " x " + k + " = " + i*k);
                }
            }
            return table;
        }

        /// <summary>
        /// Takes two lists and alternates their elements
        /// </summary>
        /// <param name="listA">The first list to use</param>
        /// <param name="listB">The second list to use</param>
        /// <param name="limit">The number of elements to alternate</param>
        /// <returns>A list of elements of both lists with alternating order</returns>
        public List<string> Shuffle(List<string> listA, List<string> listB, int limit)
        {
            List<string> alternated = new List<string>();
            for (int i = 0; i < limit; i++)
            {
                alternated.Add(listA[i]);
                alternated.Add(listB[i]);
            }
            return alternated;
        }
    }
}
