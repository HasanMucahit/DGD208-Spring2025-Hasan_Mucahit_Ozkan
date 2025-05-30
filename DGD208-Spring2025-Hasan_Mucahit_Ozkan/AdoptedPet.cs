using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_Spring2025_Hasan_Mucahit_Ozkan
{
    internal class AdoptedPet
    {

        PetType petType;
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
    }
}
