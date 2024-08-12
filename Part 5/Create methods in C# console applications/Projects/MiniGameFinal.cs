using System;
using System.Threading;

class Game
{
    // Variables for terminal window size
    static int terminalWidth = Console.WindowWidth;
    static int terminalHeight = Console.WindowHeight;

    // Player and food locations
    static int playerX = 5;
    static int playerY = 5;
    static int foodX;
    static int foodY;

    // Arrays for states and foods
    static string[] states = { "😊", "😎", "🤖" };
    static string[] foods = { "🍎", "🍌", "🍔" }; 

    /
    static string currentPlayerState = states[0];
    static string currentFood = foods[0];

    static void Main()
    {
        SetupGame();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                HandleKeyPress(keyInfo.Key);
            }

            if (IsTerminalResized())
            {
                Console.Clear();
                SetupGame();
            }

            if (IsFoodConsumed())
            {
                HandleFoodConsumption();
                DisplayFood();
            }

            Thread.Sleep(100);
        }
    }

    static void SetupGame()
    {
        Console.Clear();
        DisplayFood();
        DrawPlayer();
    }

    static void DisplayFood()
    {
        Random rand = new Random();
        foodX = rand.Next(0, Console.WindowWidth);
        foodY = rand.Next(0, Console.WindowHeight);
        Console.SetCursorPosition(foodX, foodY);
        currentFood = foods[rand.Next(foods.Length)];
        Console.Write(currentFood);
    }

    static void DrawPlayer()
    {
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(currentPlayerState);
    }

    static void HandleKeyPress(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                playerY = Math.Max(0, playerY - 1);
                break;
            case ConsoleKey.DownArrow:
                playerY = Math.Min(Console.WindowHeight - 1, playerY + 1);
                break;
            case ConsoleKey.LeftArrow:
                playerX = Math.Max(0, playerX - 1);
                break;
            case ConsoleKey.RightArrow:
                playerX = Math.Min(Console.WindowWidth - 1, playerX + 1);
                break;
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Unsupported key pressed.");
                break;
        }
    }

    static bool IsTerminalResized()
    {
        return Console.WindowWidth != terminalWidth || Console.WindowHeight != terminalHeight;
    }

    static bool IsFoodConsumed()
    {
        return playerX == foodX && playerY == foodY;
    }

    static void HandleFoodConsumption()
    {
        Random rand = new Random();
        currentPlayerState = states[rand.Next(states.Length)];
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(currentPlayerState);
        DisplayFood(); 
    }
}
