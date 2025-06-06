using DGD208_Spring2025_Hasan_Mucahit_Ozkan;

public class Game
{
    //It needs to show data from items
    //Item needs to affect sleep too

    Pet petScript = new Pet();

    private bool _isRunning;
    public async Task GameLoop()
    {
        // Initialize the game
        Initialize();

        // Main game loop
        _isRunning = true;
        while (_isRunning)
        {
            // Display menu and get player input
            string userChoice = GetUserInput();

            // Process the player's choice
            await ProcessUserChoice(userChoice);
        }

        Console.WriteLine("Thanks for playing!");
    }

    private void Initialize()
    {
        Console.Clear();
        Console.WriteLine("TAMAGOTCHI");
        Console.WriteLine("Hasan Mücahit Özkan - 2305041016");
        Console.WriteLine("Thanks to Chatgpt too.");
        Console.WriteLine("Press enter to start");
        Console.ReadKey();
    }

    private string GetUserInput()
    {
        Console.Clear();
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Adopt new Pet");
        Console.WriteLine("2. Take a look at your pet(s)");
        Console.WriteLine("3. Items");
        Console.WriteLine("4. Exit");

        Console.Write("Enter your choice: ");
        string input = Console.ReadLine().ToString();
        return input;
    }

    private async Task ProcessUserChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                Console.WriteLine("You chose to adopt a new pet.");
                var petTypeMenu = new Menu<PetType>("Choose a New Pet to Adopt", Enum.GetValues(typeof(PetType)).Cast<PetType>().ToList(), type => type.ToString());

                PetType? selectedType = petTypeMenu.ShowAndGetSelection();
                if (!selectedType.HasValue)
                    break;

                //Pet newPet = new Pet();
                //newPet.AdoptPet(selectedType.Value);

                petScript.AdoptPet((PetType)selectedType);
                //_pets.Add(newPet);

                Console.WriteLine($"You adopted a {selectedType}");
                await Task.Delay(1500);
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Here are your pets and their stats:");
                for (int i = 0; i < petScript.adoptedPets.Count; i++)
                {
                    petScript.adoptedPets[i].ShowPetCondition();
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                break;
            case "3":
                if (petScript.adoptedPets.Count == 0)
                {
                    Console.WriteLine("No adopted pets available.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    break;
                }

                // Display adopted pets
                Console.WriteLine("Select a pet:");
                for (int i = 0; i < petScript.adoptedPets.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {petScript.adoptedPets[i].petType}");
                }
                if (!int.TryParse(Console.ReadLine(), out int petIndex) || petIndex < 1 || petIndex > petScript.adoptedPets.Count)
                {
                    Console.WriteLine("Invalid selection.");
                    break;
                }
                var selectedPet = petScript.adoptedPets[petIndex - 1];

                // Filter items usable by the selected pet (example with LINQ)
                var usableItems = ItemDatabase.AllItems
                    .Where(item => item.CompatibleWith.Contains(selectedPet.petType))
                    .ToList();

                if (usableItems.Count == 0)
                {
                    Console.WriteLine("No usable items for this pet.");
                    break;
                }

                Console.WriteLine("Select an item to use:");
                for (int i = 0; i < usableItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {usableItems[i].Name} -> {usableItems[i].AffectedStat} + {usableItems[i].EffectAmount}");
                }
                if (!int.TryParse(Console.ReadLine(), out int itemIndex) || itemIndex < 1 || itemIndex > usableItems.Count)
                {
                    Console.WriteLine("Invalid selection.");
                    break;
                }

                var selectedItem = usableItems[itemIndex - 1];

                // Use the item asynchronously and wait
                await selectedPet.UseItemAsync(selectedItem);

                break;
            case "4":
                Console.WriteLine("Exiting the game...");
                _isRunning = false;
                break;

        }

    }

}
