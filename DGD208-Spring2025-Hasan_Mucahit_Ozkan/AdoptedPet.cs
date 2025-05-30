using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DGD208_Spring2025_Hasan_Mucahit_Ozkan
{
    internal class AdoptedPet
    {

        public PetType petType;
        int hunger;
        int sleep;
        int boredom;

        bool isDead = false;

        public void AdoptPet(PetType _petType)
        {
            petType = _petType;

            hunger = sleep = boredom = 50;
        }

        public void ShowPetCondition()
        {

            Console.WriteLine(petType + "/ Hunger/ " + hunger + "/ Sleep/ " + sleep + "/ Joy/ " + boredom);

        }
        public void DecreaseStats()
        {
            hunger++;
            sleep++;
            boredom++;
        }



        public bool IsDead()
        {
            CheckDeath();
            return isDead;
        }

        public void CheckDeath()
        {
            if (hunger <= 0 || sleep <= 0 || boredom <= 0)
            {
                isDead = true;
            }
        }
        public async Task UseItemAsync(Item item)
        {
            Console.WriteLine($"Using {item.Name} on {petType}...");
            await Task.Delay((int)(item.Duration * 1000));  // Wait for the duration the item takes to be used

            // Increase stats based on item type
            switch (item.Type)
            {
                case ItemType.Food:
                    hunger = Math.Min(100, hunger - item.EffectAmount);
                    break;
                case ItemType.Toy:
                    boredom = Math.Min(100, boredom - item.EffectAmount);
                    break;
                    // Add other item types if necessary
            }

            Console.WriteLine($"{petType}'s stats updated: Hunger={hunger}, Boredom={boredom}");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
