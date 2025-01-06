using System;
using System.Text.RegularExpressions;

partial class Program
{
    static void Main()
    {
        string input = File.ReadAllText("C:\\Users\\justi\\Documents\\Github\\AdventCal\\AdventCalender2024\\TextFile3.1.txt");
        // Define the regex pattern for valid mul(X, Y) instructions
        string pattern = @"mul\((\d+),(\d+)\)";
        Regex regex = new Regex(pattern);

        // Initialize the total sum
        long totalSum = 0;

        // Match all valid mul(X, Y) instructions
        MatchCollection matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            // Parse the numbers X and Y
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);

            // Multiply and add to the total sum
            totalSum += x * y;
        }

        // Output the result
        Console.WriteLine("The total sum is: " + totalSum);
    }
}