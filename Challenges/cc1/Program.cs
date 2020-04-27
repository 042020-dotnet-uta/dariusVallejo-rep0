using System;			

// Print all the numbers starting from 1 to 100.
// When the number is multiple of three, print "sweet" instead of a number on the console.
// If the number is a multiple of five then print "salty" on the console.
// For the numbers which are multiples of three and fie, print "sweet'nSalty" on the console.
// At the end, tell how many sweet's, how many salty's, and how many sweet'nSalty's
public class Program
{
	public static void Main()
	{
		// Declares variables for each counter
		int sweet = 0;
		int salty = 0;
		int both = 0;
		
		// Loops through integers 1-100
		for (int i = 1; i <= 100; i++) {
			// If the current value is divisible by 15...
			// Output relevant message and increment counter
			if (i % 15 == 0) {
				Console.WriteLine("sweet'nSalty");
				both++;
			}
			// Otherwise if the current value is divisible by 3...
			// Output relevant message and increment counter
			else if (i % 3 == 0) {
				sweet++;
				Console.WriteLine("sweet");
			}	
			// Otherwise if the current value is divisible by 5...
			// Output relevant message and increment counter
			else if (i % 5 == 0) {
				salty++;
				Console.WriteLine("salty");
			}
			// Otherwise output the current value of i
			else {
				Console.WriteLine(i);
			}
		}
		
		// For each counter, print relevant message and count of each variable
		Console.WriteLine();
		Console.WriteLine("Sweet: {0}", sweet);
		Console.WriteLine("Salty: {0}", salty);
		Console.WriteLine("Sweet'nSalty: {0}", both);
	}
}