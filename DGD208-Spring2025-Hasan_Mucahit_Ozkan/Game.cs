using DGD208_Spring2025_Hasan_Mucahit_Ozkan;

public class Game
{
    private List<Pet> _pets = new List<Pet>();
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
        Console.WriteLine("Press enter to start");
        Console.ReadKey();
    }

    private string GetUserInput()
    {
        Console.Clear();
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Adopt new Pet");
        Console.WriteLine("2. Take a look at your pets");
        Console.WriteLine("3. Spent time with your pets");
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

                Pet newPet = new Pet();
                newPet.AdoptPet(selectedType.Value);
                _pets.Add(newPet);
                Console.WriteLine($"You adopted a {selectedType}");
                await Task.Delay(1500);
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Here are your pets and their stats:");
                for (int i = 0; i < _pets.Count; i++)
                {
                    _pets[i].ShowPetCondition();
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine(); 
                break;
            case "3":

                break;
            case "4":
                Console.WriteLine("Exiting the game...");
                _isRunning = false;
                break;

        }
    }
}
