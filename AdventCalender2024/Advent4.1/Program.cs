using System;

class Program
{
    static void Main(string[] args)
    {
        // Puzzle input
        string[] grid = File.ReadAllLines("C:\\Users\\justi\\Documents\\Github\\AdventCal\\AdventCalender2024\\TextFile4.1.txt"); ;

        string target = "XMAS";
        int count = CountOccurrences(grid, target);
        Console.WriteLine("The word " + target + " appears " + count + " times in the grid.");
    }

    static int CountOccurrences(string[] grid, string target)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int targetLength = target.Length;
        int count = 0;

        // Directions to check: (rowOffset, colOffset)
        int[][] directions = {
            new[] { 0, 1 },  // Right
            new[] { 1, 0 },  // Down
            new[] { 1, 1 },  // Diagonal Down-Right
            new[] { 1, -1 }, // Diagonal Down-Left
            new[] { 0, -1 }, // Left
            new[] { -1, 0 }, // Up
            new[] { -1, -1 }, // Diagonal Up-Left
            new[] { -1, 1 }   // Diagonal Up-Right
        };

        // Traverse the grid
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                foreach (var direction in directions)
                {
                    if (CheckWord(grid, target, row, col, direction[0], direction[1]))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    static bool CheckWord(string[] grid, string target, int row, int col, int rowOffset, int colOffset)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int targetLength = target.Length;

        for (int i = 0; i < targetLength; i++)
        {
            int newRow = row + i * rowOffset;
            int newCol = col + i * colOffset;

            // Check bounds
            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
            {
                return false;
            }

            // Check character match
            if (grid[newRow][newCol] != target[i])
            {
                return false;
            }
        }

        return true;
    }
}