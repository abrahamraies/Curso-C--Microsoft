using System;
using System.Timers;

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

    // Arrays for player states and food types
    static string[] states = { "😊", "😎", "🤖" };
    static string[] foods = { "🍎", "🍌", "🍔" };

    // Current appearance of player and food
    static string currentPlayerState = states[0];
    static string currentFood = foods[0];

    // Game state variables
    static bool isPaused = false;
    static System.Timers.Timer gameTimer;

    static void Main()
    {
        SetupGame();

        gameTimer = new System.Timers.Timer(100); // Set game speed
        gameTimer.Elapsed += (sender, e) => GameLoop();
        gameTimer.Start();

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
        }
    }

    // Initializes the game setup
    static void SetupGame()
    {
        Console.Clear();
        DisplayFood();
        DrawPlayer();
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.Write("Use Arrow keys to move. Press ESC to exit. Press P to pause.");
    }

    // Displays food at a random location
    static void DisplayFood()
    {
        Random rand = new Random();
        foodX = rand.Next(0, Console.WindowWidth);
        foodY = rand.Next(0, Console.WindowHeight - 1);  // Leave space for the message
        Console.SetCursorPosition(foodX, foodY);
        currentFood = foods[rand.Next(foods.Length)];
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(currentFood);
        Console.ResetColor();
    }

    // Draws the player at the current location
    static void DrawPlayer()
    {
        Console.SetCursorPosition(playerX, playerY);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(currentPlayerState);
        Console.ResetColor();
    }

    // Clears a specific position in the console
    static void ClearPosition(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(' ');  // Clear the current position
    }

    // Handles key press events
    static void HandleKeyPress(ConsoleKey key)
    {
        if (key == ConsoleKey.P)
        {
            isPaused = !isPaused;
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine(isPaused ? "Game Paused. Press P to resume." : "Game Resumed.");
            return;
        }

        if (isPaused) return;

        ClearPosition(playerX, playerY);

        switch (key)
        {
            case ConsoleKey.UpArrow:
                playerY = Math.Max(0, playerY - 1);
                break;
            case ConsoleKey.DownArrow:
                playerY = Math.Min(Console.WindowHeight - 2, playerY + 1);
                break;
            case ConsoleKey.LeftArrow:
                playerX = Math.Max(0, playerX - 1);
                break;
            case ConsoleKey.RightArrow:
                playerX = Math.Min(Console.WindowWidth - 1, playerX + 1);
                break;
            case ConsoleKey.Escape:
                Console.Clear();
                Console.WriteLine("Thank you for playing! Press Enter to exit.");
                Console.ReadLine();
                Environment.Exit(0);
                break;
            default:
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.WriteLine("Unsupported key pressed.");
                break;
        }

        DrawPlayer();
    }

    // Main game loop
    static void GameLoop()
    {
        if (IsFoodConsumed())
        {
            HandleFoodConsumption();
            DisplayFood();
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

    // Handles the food consumption by the player
    static void HandleFoodConsumption()
    {
        Random rand = new Random();
        currentPlayerState = states[rand.Next(states.Length)];
        Console.SetCursorPosition(playerX, playerY);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(currentPlayerState);
        Console.ResetColor();
    }
}
