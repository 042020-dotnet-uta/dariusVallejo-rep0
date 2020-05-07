using System;
using System.Collections.Generic;

namespace lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            string p1Name;
            string p2Name;
            Console.Write("Please input player 1 name: ");
            p1Name = Console.ReadLine();
            Console.Write("Please input player 2 name: ");
            p2Name = Console.ReadLine();

            Console.WriteLine(p1Name);
        }
    }
}
