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
        int fun;

        bool isDead = false;

        public void AdoptPet(PetType _petType)
        {
            petType = _petType;

            hunger = sleep = fun = 50;
        }

        public void ShowPetCondition()
        {

            Console.WriteLine(petType + "=> Hunger -> " + hunger + " -> Sleep " + sleep + " -> Joy " + fun);

        }
        public void DecreaseStats()
        {
            hunger--;
            sleep--;
            fun--;
        }



        public bool IsDead()
        {
            CheckDeath();
            return isDead;
        }

        public void CheckDeath()
        {
            if (hunger <= 0 || sleep <= 0 || fun <= 0)
            {
                isDead = true;
            }
        }
        public async Task UseItemAsync(Item item)
        {
            Console.WriteLine($"Using {item.Name} on {petType}...");
            await Task.Delay((int)(item.Duration * 1000)); 

            // Increase stats based on item type
            switch (item.AffectedStat)
            {
                case PetStat.Hunger:
                    hunger = Math.Min(100, hunger + item.EffectAmount);
                    break;

                case PetStat.Sleep:
                   sleep = Math.Min(100, sleep + item.EffectAmount);
                    break;

                case PetStat.Fun:
                    fun = Math.Min(100, fun + item.EffectAmount);
                    break;

            }

            Console.WriteLine($"{petType}'s stats updated: Hunger=> {hunger}, Sleep=> {sleep} , Boredom=> {fun}");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }
    }
}
