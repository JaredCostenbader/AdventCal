using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.IO;

class Sorting
{
    static void Main(string[] args)
    {
        List<int> leftNumbers = new List<int>();
        List<int> rightNumbers = new List<int>();

        // Read the file line by line
        string[] lines = File.ReadAllLines("TextFile1.1.txt");

        // Loop through each line and extract the left and right numbers
        foreach (string line in lines)
        {
            string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                int leftNumber = int.Parse(parts[0]);
                int rightNumber = int.Parse(parts[1]);

                leftNumbers.Add(leftNumber);
                rightNumbers.Add(rightNumber);
            }
        }

        leftNumbers.Sort();
        rightNumbers.Sort();


        int distance = 0;

        for (int i = 0; i < leftNumbers.Count; i++)
        {
            distance += Math.Abs(rightNumbers[i] - leftNumbers[i]);
        }

        // Calculate the similarity score
        int similarityScore = 0;

        foreach (int leftNumber in leftNumbers)
        {
            // Count how many times the leftNumber appears in the right list
            int count = rightNumbers.Count(x => x == leftNumber);
            // Add to the similarity score
            similarityScore += leftNumber * count;
        }




        // Print the sorted numbers
        Console.WriteLine("Sorted left numbers:");
        foreach (int number in leftNumbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("Sorted right numbers:");
        foreach (int number in rightNumbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine($"Total distance: {distance}");

        Console.WriteLine($"Similarity score: {similarityScore}");

    }


}
