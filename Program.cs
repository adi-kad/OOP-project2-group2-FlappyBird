using System;
using System.Threading;

namespace FlappyBird
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.SetUp();

            while (!game.isOver)
            {
                game.Run();
            }

            Console.Clear();
        }

    }
}
