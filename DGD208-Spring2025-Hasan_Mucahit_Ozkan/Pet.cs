using System;
using System.Timers;

namespace DGD208_Spring2025_Hasan_Mucahit_Ozkan
{
    internal class Pet
    {
        List<AdoptedPet> adoptedPets = new List<AdoptedPet>();

        private System.Timers.Timer timer;

        public event EventHandler On1SecPass;


        public Pet()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void AdoptPet(PetType type)
        {
            AdoptedPet adoptedPet = new AdoptedPet();
            adoptedPets.Add(adoptedPet);
            adoptedPet.AdoptPet(type);
            On1SecPass += (sender, e) => adoptedPet.DecreaseStats();
        }
        public void ShowPetCondition()
        {
            foreach (var _adoptedPet in adoptedPets)
            {
                _adoptedPet.ShowPetCondition();
            }
        }
        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            On1SecPass?.Invoke(this, EventArgs.Empty);

            for (int i = adoptedPets.Count - 1; i >= 0; i--)
            {         
                if (adoptedPets[i].IsDead())
                {
                    On1SecPass -= (sender, e) => adoptedPets[i].DecreaseStats();
                    adoptedPets.RemoveAt(i);
                }
            }
        }

    }
}
