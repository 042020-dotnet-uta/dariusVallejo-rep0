using p0.UI;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p0
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main function, serves as entry point for business application
        /// </summary>
        /// <param name="args">Irrelevant argument list</param>
        static void Main(string[] args)
        {
            new BaseUI().prompt();
        }
    }
}
