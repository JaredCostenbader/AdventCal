/*class Program
{
    static void Main()
    {
        int SafeReportNum = 0;

        string[] lines =
            File.ReadAllLines("C:\\Users\\justi\\Documents\\Github\\AdventCal\\AdventCalender2024\\TextFile2.1.txt");

        foreach (string line in lines)
        {
            // Converts the line to a list of integers (levels)

            List<int> Levels = new();
            string[] nums = line.Split(new string[] { " " }, StringSplitOptions.None);
            for (int i = 0; i < nums.Length; i++)
                Levels.Add(int.Parse(nums[i]));

            if (IsSafeReport(Levels))
            {
                SafeReportNum++;
            }

        }

        Console.WriteLine("Number of safe reports: " + SafeReportNum);
    }

    static bool IsSafeReport(List<int> levels)
    {
        int n = levels.Count;

        if (n < 2)
        {
            return false;
        }

        bool ascending = true;
        bool descending = true;

        for (int i = 0; i < n - 1; i++)
        {
            int difference = levels[i + 1] - levels[i];

            if (difference < 1 || difference > 3)
            {
                return false;
            }

            if (levels[i] < levels[i + 1])
            {
                descending = false;
            }
            else if (levels[i] > levels[i + 1])
            {
                ascending = false;
            }

            // If both flags are false, break early to avoid unnecessary iterations
            if (!ascending && !descending)
            {
                return false;
            }
        }

        return ascending || descending;
    }
}*/
//this didnt work

using System.IO;
using System.Linq; 
    List<bool> SafeReports = new List<bool>();
    int SafeReportNum = 0;
    string[] lines = File.ReadAllLines("C:\\Users\\justi\\Documents\\Github\\AdventCal\\AdventCalender2024\\TextFile2.1.txt");

    foreach (string line in lines)
    {
        string[] nums = line.Split(new string[] { " " }, StringSplitOptions.None);
        List<int> Levels = new List<int>();
        for (int i = 0; i < nums.Length; i++)
            Levels.Add(int.Parse(nums[i]));

        bool? ascending = null;
        bool isSafe = true;
        for (int i = 0; i < Levels.Count - 1; i++)
        {
            if (Levels[i] - Levels[i + 1] > 0)
            {
                ascending = false;
                break;
            }
            else if (Levels[i] - Levels[i + 1] < 0)
            {
                ascending = true;
                break;
            }
        }

        if (ascending == null)
        {
            isSafe = false;
            continue;
        }

        for (int i = 0; i < Levels.Count - 1; i++)
        {
            if (Levels[i] - Levels[i + 1] < 0 && ascending == true || Levels[i] - Levels[i + 1] > 0 && ascending == false) { }
                else
                {
                    isSafe = false;
                    break;
                }
            if (Math.Abs((Levels[i] - Levels[i + 1])) < 4) { }
                else
                {
                 isSafe = false;
                    break;
                }
        }
        SafeReports.Add(isSafe);
    }

    foreach (bool isSafe in SafeReports)
    {
        if (isSafe)
            SafeReportNum++;
    }

    Console.Write(SafeReportNum);


