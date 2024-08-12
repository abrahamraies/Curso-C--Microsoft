using System;
using System.Collections.Generic;

class Program
{
    private static readonly string[] pettingZoo = 
    {
        "alpacas", "capybaras", "chickens", "ducks", "emus", "geese", 
        "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws", 
        "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
    };

    static void Main()
    {
        PlanSchoolVisit("School A");
        PlanSchoolVisit("School B", 3);
        PlanSchoolVisit("School C", 2);
    }

    static void PlanSchoolVisit(string schoolName, int groups = 6)
    {
        var randomizedAnimals = RandomizeAnimals();
        var groupAssignments = AssignGroups(randomizedAnimals, groups);
        
        Console.WriteLine(schoolName);
        PrintGroups(groupAssignments);
    }

    static string[] RandomizeAnimals()
    {
        var animalsList = new List<string>(pettingZoo);
        Random random = new Random();
        int count = animalsList.Count;

        // Fisher-Yates shuffle algorithm
        for (int i = count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            var temp = animalsList[i];
            animalsList[i] = animalsList[j];
            animalsList[j] = temp;
        }

        return animalsList.ToArray();
    }

    static string[,] AssignGroups(string[] animals, int groupCount)
    {
        int animalsPerGroup = animals.Length / groupCount;
        string[,] groups = new string[groupCount, animalsPerGroup];
        
        for (int i = 0; i < groupCount; i++)
        {
            for (int j = 0; j < animalsPerGroup; j++)
            {
                groups[i, j] = animals[i * animalsPerGroup + j];
            }
        }

        return groups;
    }

    static void PrintGroups(string[,] groups)
    {
        int numberOfGroups = groups.GetLength(0);
        int animalsPerGroup = groups.GetLength(1);

        for (int i = 0; i < numberOfGroups; i++)
        {
            Console.Write($"Group {i + 1}: ");
            for (int j = 0; j < animalsPerGroup; j++)
            {
                Console.Write($"{groups[i, j]}  ");
            }
            Console.WriteLine();
        }
    }
}
