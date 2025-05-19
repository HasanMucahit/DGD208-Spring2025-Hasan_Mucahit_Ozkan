using System;

namespace DGD208Spring2025HasanMucahitOzkan
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Game game = new Game();
            await game.GameLoop();
        }
    }

}
