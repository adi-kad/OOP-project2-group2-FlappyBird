using System;
using System.Threading;

namespace FlappyBird
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //Menu menu = new Menu();
            //menu.StartMenu();
            //Obstacle Obstacle1 = new Obstacle("Obstacle1", 10, 50);
            //Obstacle Obstacle2 = new Obstacle("Obstacle2", 8, 70);
            //Obstacle Obstacle3 = new Obstacle("Obstacle3", 14, 90);
            //Obstacle Obstacle4 = new Obstacle("Obstacle4", 18, 110);
            //Obstacle[] obstacles = { Obstacle1, Obstacle2, Obstacle3, Obstacle4 };
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
