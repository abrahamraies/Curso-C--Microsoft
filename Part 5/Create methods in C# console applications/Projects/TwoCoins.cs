using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int target = 30;
        int[] coins = new int[] { 5, 5, 50, 25, 25, 10, 5 };
        List<(int, int)> result = TwoCoins(coins, target);

        if (result.Count == 0)
        {
            Console.WriteLine("No two coins make change");
        }
        else
        {
            Console.WriteLine("Change found at positions:");
            foreach (var (first, second) in result)
            {
                Console.WriteLine($"{first},{second}");
            }
        }
    }

    static List<(int, int)> TwoCoins(int[] coins, int target)
    {
        List<(int, int)> result = new List<(int, int)>();

        for (int curr = 0; curr < coins.Length; curr++)
        {
            for (int next = curr + 1; next < coins.Length; next++)
            {
                if (coins[curr] + coins[next] == target)
                {
                    result.Add((curr, next));
                }
            }
        }
        return result;
    }
}
