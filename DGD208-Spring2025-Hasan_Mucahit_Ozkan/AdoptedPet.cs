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
        int joy;

        public void AdoptPet(PetType _petType)
        {
            petType = _petType;

            hunger = sleep = joy = 50;
        }

        public void ShowPetCondition()
        {

            Console.WriteLine(petType + "/ Hunger/ " + hunger + "/ Sleep/ " + sleep + "/ Joy/ " + joy);

        }
    }
}
