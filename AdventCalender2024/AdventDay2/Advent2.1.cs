class Program
{
    static void Main()
    {
        int SafeReportNum = 0;

        string[] lines = File.ReadAllLines("TextFile2.1.txt");

        foreach (string line in lines)
        {
            // Converts the line to a list of integers (levels)
            List<int> Levels = line.Split(' ').Select(int.Parse).ToList();

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
}