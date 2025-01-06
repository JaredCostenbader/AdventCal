using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


string[] lines = File.ReadAllLines("C:\\Users\\justi\\Documents\\Github\\AdventCal\\AdventCalender2024\\TextFile3.1.txt");

// Define the regex pattern to match mul(X, Y), do(), and don't() instructions
var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)");

// Initialize the total sum and the state of the mul instruction (enabled/disabled)
var totalSum = 0;
var enabled = true;

// Process each line from the input file
foreach (var line in lines)
{
    // Match all relevant instructions in the current line
    foreach (var match in regex.Matches(line))
    {
        var instruction = $"{match}";

        if (enabled && instruction.StartsWith("mul"))
        {
            // Extract the numbers from the mul instruction and calculate the result
            var numbers = instruction[4..^1].Split(',').Select(int.Parse).ToArray();
            totalSum += numbers[0] * numbers[1];
        }
        // Handle the 'do()' instruction to enable mul
        else if (instruction.Equals("do()"))
        {
            enabled = true;
        }
        // Handle the 'don't()' instruction to disable mul
        else if (instruction.Equals("don't()"))
        {
            enabled = false;
        }
    }
}

// Output the final total sum
Console.WriteLine("The total sum is: " + totalSum);







