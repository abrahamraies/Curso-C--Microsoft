using System;

class Program
{
    static void Main()
    {
        int[] times = { 800, 1200, 1600, 2000 };
        int diff = 0;

        Console.WriteLine("Enter current GMT");
        int currentGMT = GetValidatedGMT();

        Console.WriteLine("Current Medicine Schedule:");
        DisplayTimes(times);

        Console.WriteLine("Enter new GMT");
        int newGMT = GetValidatedGMT();

        if (IsValidGMT(newGMT) && IsValidGMT(currentGMT))
        {
            diff = CalculateTimeDifference(currentGMT, newGMT);
            AdjustTimes(times, diff);

            Console.WriteLine("New Medicine Schedule:");
            DisplayTimes(times);
        }
        else
        {
            Console.WriteLine("Invalid GMT");
        }
    }

    static int GetValidatedGMT()
    {
        int gmt = 0;
        bool isValid = false;

        while (!isValid)
        {
            if (int.TryParse(Console.ReadLine(), out gmt) && IsValidGMT(gmt))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid GMT. Please enter a GMT between -12 and +12.");
            }
        }

        return gmt;
    }

    static bool IsValidGMT(int gmt)
    {
        return Math.Abs(gmt) <= 12;
    }

    static int CalculateTimeDifference(int currentGMT, int newGMT)
    {
        if ((newGMT <= 0 && currentGMT <= 0) || (newGMT >= 0 && currentGMT >= 0))
        {
            return 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
        }
        else
        {
            return 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
        }
    }

    static void DisplayTimes(int[] times)
    {
        foreach (int val in times)
        {
            string time = val.ToString("D4"); // Ensures the time has at least 4 digits
            time = time.Insert(time.Length - 2, ":");
            Console.Write($"{time} ");
        }
        Console.WriteLine();
    }

    static void AdjustTimes(int[] times, int diff)
    {
        for (int i = 0; i < times.Length; i++)
        {
            times[i] = (times[i] + diff) % 2400;
            if (times[i] < 0)
            {
                times[i] += 2400;
            }
        }
    }
}