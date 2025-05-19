using System;

namespace DGD208_Spring2025_Hasan_Mucahit_Ozkan
{
    internal class Pet
    {
        PetType petType;
        int hunger;
        int sleep;
        int fun;

        public void AdoptPet(PetType type)
        {
            petType = type;
            hunger = 50;
            sleep = 50;
            fun = 50;
        }
        public void ShowPetCondition()
        {
            Console.WriteLine(petType + "/ Hunger/ " + hunger + "/ Sleep/ " + sleep + "/ Fun/ " + fun);
        }

    }
}
