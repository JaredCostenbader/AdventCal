using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

partial class Program
{
    static void Main()
    {
        string[] lines =
            File.ReadAllLines("C:\\Users\\justi\\Documents\\Github\\AdventCal\\AdventCalender2024\\TextFile2.1.txt");

        var answer = 0;
        foreach (var line in lines)
        {
            var report = line.Split(' ').Select(int.Parse).ToArray();
            if (isSafe(report, true))
                answer++;
        }

        Console.WriteLine(answer);

        static bool isSafe(int[] report, bool problemDampener)
        {
            int ups = 0, downs = 0, nboWrongSteps = 0;

            for (var i = 1; i < report.Length; i++)
            {
                if (report[i] > report[i - 1])
                    ups++;
                else if (report[i] < report[i - 1])
                    downs++;

                var diff = Math.Abs(report[i] - report[i - 1]);
                if (diff == 0 || diff > 3)
                    nboWrongSteps++;
            }

            if ((ups == 0 || downs == 0) && nboWrongSteps == 0)
                return true;

            for (var indexToRemove = 0; problemDampener && indexToRemove < report.Length; indexToRemove++)
            {
                var newReport = new List<int>();
                for (var i = 0; i < report.Length; i++)
                    if (i != indexToRemove)
                        newReport.Add(report[i]);

                if (isSafe([.. newReport], false))
                    return true;
            }

            return false;
        }

    }
}
// tried to figure this out and i cannot get it 