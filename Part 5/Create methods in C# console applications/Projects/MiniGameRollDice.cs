using System;

class Program
{
    private static readonly Random random = new Random();

    static void Main()
    {
        Console.WriteLine("Would you like to play? (Y/N)");
        if (ShouldPlay())
        {
            PlayGame();
        }
    }

    static bool ShouldPlay()
    {
        string response = Console.ReadLine().Trim().ToLower();
        return response == "y" || response == "yes";
    }

    static void PlayGame()
    {
        bool play = true;

        while (play)
        {
            int target = GetTarget();
            int roll = RollDice();

            Console.WriteLine($"Roll a number greater than {target} to win!");
            Console.WriteLine($"You rolled a {roll}");
            Console.WriteLine(WinOrLose(roll, target));

            Console.WriteLine("\nPlay again? (Y/N)");
            play = ShouldPlay();
        }
    }

    static int GetTarget()
    {
        return random.Next(1, 6);
    }

    static int RollDice()
    {
        return random.Next(1, 7);
    }

    static string WinOrLose(int roll, int target)
    {
        return roll > target ? "You win!" : "You lose!";
    }
}
