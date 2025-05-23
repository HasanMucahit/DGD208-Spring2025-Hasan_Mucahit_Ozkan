using System;

namespace DGD208_Spring2025_Hasan_Mucahit_Ozkan
{
    internal class Pet
    {
        List<AdoptedPet> adoptedPets = new List<AdoptedPet>();

        PetType petType;
        int hunger;
        int sleep;
        int fun;

        public void AdoptPet(PetType type)
        {
            AdoptedPet adoptedPet = new AdoptedPet();
            adoptedPets.Add(adoptedPet);
            adoptedPet.AdoptPet(type);
        }
        public void ShowPetCondition()
        {
            foreach (var _adoptedPet in adoptedPets)
            {

                _adoptedPet.ShowPetCondition();
            }
        }

    }
}
