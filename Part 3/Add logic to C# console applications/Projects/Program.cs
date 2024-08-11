using System;

class Program
{
    const int MaxPets = 8;
    static Animal[] ourAnimals = new Animal[MaxPets];

    static void Main()
    {
        // Inicializar algunos animales
        InitializeAnimals();

        string menuSelection = "";
        do
        {
            menuSelection = ShowMenu();
            HandleMenuSelection(menuSelection);

        } while (menuSelection != "exit");
    }

    static void InitializeAnimals()
    {
        ourAnimals[0] = new Animal("dog", "d1", "2", "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.", "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.", "lola");
        ourAnimals[1] = new Animal("dog", "d2", "9", "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.", "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.", "loki");
        ourAnimals[2] = new Animal("cat", "c3", "1", "small white female weighing about 8 pounds. litter box trained.", "friendly", "puss");
        ourAnimals[3] = new Animal("cat", "c4", "?", "", "", "");
    }

    static string ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
        Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete.");
        Console.WriteLine(" 5. Edit an animal's age");
        Console.WriteLine(" 6. Edit an animal's personality description");
        Console.WriteLine(" 7. Display all cats with a specified characteristic");
        Console.WriteLine(" 8. Display all dogs with a specified characteristic");
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

        string? readResult = Console.ReadLine();
        return readResult != null ? readResult.ToLower() : "0";
    }

    static void HandleMenuSelection(string menuSelection)
    {
        switch (menuSelection)
        {
            case "1":
                ListAllPets();
                break;
            case "2":
                AddNewAnimal();
                break;
            case "3":
                EnsureAnimalDataComplete(completePhysicalDescription: true);
                break;
            case "4":
                EnsureAnimalDataComplete(completePersonalityDescription: true);
                break;
            case "5":
                EditAnimalData("age");
                break;
            case "6":
                EditAnimalData("personality");
                break;
            case "7":
                DisplayAnimalsWithCharacteristic("cat");
                break;
            case "8":
                DisplayAnimalsWithCharacteristic("dog");
                break;
            case "exit":
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid selection, please try again.");
                break;
        }
    }

    static void ListAllPets()
    {
        foreach (var animal in ourAnimals)
        {
            if (animal != null)
            {
                Console.WriteLine(animal);
            }
        }
    }

    static void AddNewAnimal()
    {
        if (Array.FindIndex(ourAnimals, a => a == null) == -1)
        {
            Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
            return;
        }

        string species = PromptForValidInput("Enter 'dog' or 'cat' to begin a new entry", s => s == "dog" || s == "cat");
        string id = species.Substring(0, 1) + (Array.FindAll(ourAnimals, a => a?.Species == species).Length + 1);
        string age = PromptForValidInput("Enter the pet's age or enter ? if unknown", s => s == "?" || int.TryParse(s, out _));
        string physicalDescription = PromptForInput("Enter a physical description of the pet (size, color, gender, weight, housebroken)", "tbd");
        string personalityDescription = PromptForInput("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)", "tbd");
        string nickname = PromptForInput("Enter a nickname for the pet", "tbd");

        ourAnimals[Array.FindIndex(ourAnimals, a => a == null)] = new Animal(species, id, age, physicalDescription, personalityDescription, nickname);
    }

    static void EnsureAnimalDataComplete(bool completePhysicalDescription = false, bool completePersonalityDescription = false)
    {
        foreach (var animal in ourAnimals)
        {
            if (animal != null)
            {
                if (completePhysicalDescription && string.IsNullOrEmpty(animal.PhysicalDescription))
                {
                    animal.PhysicalDescription = PromptForInput($"Update physical description for {animal.ID}", "tbd");
                }
                if (completePersonalityDescription && string.IsNullOrEmpty(animal.PersonalityDescription))
                {
                    animal.PersonalityDescription = PromptForInput($"Update personality description for {animal.ID}", "tbd");
                }
            }
        }
    }

    static void EditAnimalData(string attribute)
    {
        string id = PromptForInput("Enter the ID of the animal you want to edit");
        Animal? animal = Array.Find(ourAnimals, a => a?.ID == id);

        if (animal != null)
        {
            switch (attribute)
            {
                case "age":
                    animal.Age = PromptForValidInput("Enter the new age", s => s == "?" || int.TryParse(s, out _));
                    break;
                case "personality":
                    animal.PersonalityDescription = PromptForInput("Enter the new personality description", "tbd");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Animal not found.");
        }
    }

    static void DisplayAnimalsWithCharacteristic(string species)
    {
        string characteristic = PromptForInput($"Enter the characteristic to search for in {species}s");
        foreach (var animal in ourAnimals)
        {
            if (animal?.Species == species && (animal.PhysicalDescription.Contains(characteristic) || animal.PersonalityDescription.Contains(characteristic)))
            {
                Console.WriteLine(animal);
            }
        }
    }

    static string PromptForInput(string message, string defaultValue = "")
    {
        Console.WriteLine(message);
        string? input = Console.ReadLine();
        return !string.IsNullOrEmpty(input) ? input : defaultValue;
    }

    static string PromptForValidInput(string message, Func<string, bool> isValid)
    {
        string input;
        do
        {
            input = PromptForInput(message);
        } while (!isValid(input));
        return input;
    }
}

class Animal
{
    public string Species { get; set; }
    public string ID { get; set; }
    public string Age { get; set; }
    public string PhysicalDescription { get; set; }
    public string PersonalityDescription { get; set; }
    public string Nickname { get; set; }

    public Animal(string species, string id, string age, string physicalDescription, string personalityDescription, string nickname)
    {
        Species = species;
        ID = id;
        Age = age;
        PhysicalDescription = physicalDescription;
        PersonalityDescription = personalityDescription;
        Nickname = nickname;
    }

    public override string ToString()
    {
        return $"ID: {ID}\nSpecies: {Species}\nAge: {Age}\nNickname: {Nickname}\nPhysical Description: {PhysicalDescription}\nPersonality: {PersonalityDescription}\n";
    }
}
